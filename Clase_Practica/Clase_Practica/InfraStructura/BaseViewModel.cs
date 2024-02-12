using Clase_Practica.Models;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Clase_Practica.Services.ApiService;

namespace Clase_Practica.InfraStructura
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected HttpClient _client;

        public BaseViewModel()
        {
            _client = HttpClientSingleton.Instance;
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task<HttpResponseMessage> AddClinicaAsync(Clinica clinica)
        {
            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(clinica);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await _client.PostAsync(Constants.ClinicasUrl, content);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la clínica: {ex.Message}");
            }

            return response;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        // Método para actualizar una clínica existente
        public async Task<HttpResponseMessage> UpdateClinicaAsync(int id, Clinica clinica)
        {
            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(clinica);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = await _client.PutAsync($"{Constants.ClinicasUrl}/{id}", content);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la clínica: {ex.Message}");
            }

            return response;
        }
    }

    public static class HttpClientSingleton
    {
        private static readonly Lazy<HttpClient> lazyHttpClient = new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Instance => lazyHttpClient.Value;
    }
}


/*
namespace Clase_Practica.InfraStructura
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected HttpClient _client;

        public BaseViewModel()
        {
            _client = new HttpClient();
        }
        //add
        public async Task<HttpResponseMessage> AddClinicaAsync(Clinica clinica)
        {
            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(clinica);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                response = await _client.PostAsync(Constants.ClinicasUrl, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la clínica: {ex.Message}");
            }

            return response;
        }


    }
}

 */