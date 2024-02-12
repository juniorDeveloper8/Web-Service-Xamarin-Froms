using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Clase_Practica.InfraStructura;
using Clase_Practica.Models;
using Clase_Practica.Services;
using Xamarin.Forms;

namespace Clase_Practica.ViewModel
{
    public class AddClinicaViewModel : BaseViewModel
    {
        private readonly ApiService _apiService;

        public AddClinicaViewModel(ApiService apiService)
        {
            _apiService = apiService;
            AddClinicaCommand = new Command(async () => await AddClinicaAsync());
        }

        private bool _isInsertSuccessful;
        public bool IsInsertSuccessful
        {
            get { return _isInsertSuccessful; }
            set { SetProperty(ref _isInsertSuccessful, value); }
        }

        public ICommand AddClinicaCommand { get; }

        private async Task AddClinicaAsync()
        {
            try
            {
                var nuevaClinica = new InsertClinica
                {
                    ClinicaNombre = ClinicaNombre,
                    Direccion = Direccion,
                    Ruc = Ruc
                };

                var response = await _apiService.PostClinicaAsync(nuevaClinica);

                IsInsertSuccessful = response != null && response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la clínica: {ex.Message}");
            }
        }

        // Propiedades enlazadas en la vista
        public string ClinicaNombre { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
    }
}
