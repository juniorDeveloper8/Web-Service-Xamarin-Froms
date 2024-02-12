using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Clase_Practica.Models;
using Xamarin.Forms;
using System.Linq;
using System.Text;

namespace Clase_Practica.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public static class Constants
        {
            public const string ClinicasUrl = "http://192.168.1.6/api/Clinicas";
        }
        public ApiService()
        {
            try
            {
                _client = new HttpClient();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing HttpClient: {ex.Message}");
                throw;
            }
        }
        //listar clinica
        public async Task<IEnumerable<Clinica>> GetClinicasAsync()
        {
            try
            {
                var response = await _client.GetAsync(Constants.ClinicasUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<Clinica>>(content);
                }

                return Enumerable.Empty<Clinica>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return Enumerable.Empty<Clinica>();
            }
        }
        //insertar clinica
        public async Task<HttpResponseMessage> PostClinicaAsync(InsertClinica insertclinica)
        {
            HttpResponseMessage response = null;

            try
            {
                var json = JsonConvert.SerializeObject(insertclinica);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                response = await _client.PostAsync(Constants.ClinicasUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error al insertar la clínica: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error al insertar la clínica: {ex.Message}", ex);
            }

            return response;
        }
        // actualizar clinica
        public async Task<HttpResponseMessage> PutClinicaAsync(int id, Clinica clinica)
        {
            try
            {
                var json = JsonConvert.SerializeObject(clinica);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                return await _client.PutAsync($"{Constants.ClinicasUrl}/{id}", content);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error de deserialización JSON: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
       // eliminar clinica
        public async Task<HttpResponseMessage> DeleteClinicaAsync(int id)
        {
            try
            {
                return await _client.DeleteAsync($"{Constants.ClinicasUrl}/{id}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la clínica: {ex.Message}");
                return null;
            }
        }
    }
}

