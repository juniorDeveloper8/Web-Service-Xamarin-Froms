using Clase_Practica.InfraStructura;
using Clase_Practica.Models;
using Clase_Practica.Services;
using Clase_Practica.View;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Clase_Practica.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ApiService _apiService = new ApiService();
        private Clinica _selectedClinica;

        public ObservableCollection<Clinica> Clinicas { get; } = new ObservableCollection<Clinica>();

        public Clinica SelectedClinica
        {
            get { return _selectedClinica; }
            set
            {
                SetProperty(ref _selectedClinica, value);
                OnPropertyChanged(nameof(SelectedClinica));
            }
        }

        public HomeViewModel()
        {
            LoadClinicas();
        }

        public async Task LoadClinicas()
        {
            try
            {
                var clinicas = await _apiService.GetClinicasAsync();
                Clinicas.Clear();
                foreach (var clinica in clinicas)
                {
                    Clinicas.Add(clinica);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading clinics: {ex.Message}");
            }
        }

        public async Task EditarClinica()
        {
            if (SelectedClinica != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new EditarClinica(_apiService, SelectedClinica));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, seleccione una clínica para editar", "OK");
            }
        }
    }
}
