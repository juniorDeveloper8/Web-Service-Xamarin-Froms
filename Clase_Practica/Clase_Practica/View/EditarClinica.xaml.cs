using Clase_Practica.Models;
using Clase_Practica.Services;
using System;
using Xamarin.Forms;

namespace Clase_Practica.View
{
    public partial class EditarClinica : ContentPage
    {
        private readonly ApiService _apiService;
        private readonly Clinica _clinicaSeleccionada;

        public EditarClinica(ApiService apiService, Clinica clinicaSeleccionada)
        {
            InitializeComponent();
            _apiService = apiService;
            _clinicaSeleccionada = clinicaSeleccionada;

            IdEntry.Text = _clinicaSeleccionada.Id.ToString();
            NuevoClinicaNombreEntry.Text = _clinicaSeleccionada.ClinicaNombre;
            NuevaDireccionEntry.Text = _clinicaSeleccionada.Direccion;
            NuevoRucEntry.Text = _clinicaSeleccionada.Ruc;
        }

        private async void OnActualizarClinicaClicked(object sender, EventArgs e)
        {
            try
            {
                _clinicaSeleccionada.ClinicaNombre = NuevoClinicaNombreEntry.Text;
                _clinicaSeleccionada.Direccion = NuevaDireccionEntry.Text;
                _clinicaSeleccionada.Ruc = NuevoRucEntry.Text;
                var response = await _apiService.PutClinicaAsync(_clinicaSeleccionada.Id, _clinicaSeleccionada);
                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Éxito", "Clínica actualizada correctamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Error al actualizar la clínica", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Se produjo un error: {ex.Message}", "OK");
            }
        }
    }
}
