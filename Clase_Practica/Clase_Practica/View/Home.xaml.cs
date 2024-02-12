using Clase_Practica.Services;
using Clase_Practica.View;
using Clase_Practica.ViewModel;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Clase_Practica
{
    public partial class Home : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        private HomeViewModel _viewModel;

        public Home()
        {
            InitializeComponent();
            _viewModel = new HomeViewModel();
            BindingContext = _viewModel;

            MessagingCenter.Subscribe<AddClinicaPage>(this, "RefreshClinicas", async (sender) =>
            {
                await LoadClinicas();
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadClinicas();
        }

        private async Task LoadClinicas()
        {
            var clinicas = await _apiService.GetClinicasAsync();
            _viewModel.Clinicas.Clear();

            foreach (var clinica in clinicas)
            {
                _viewModel.Clinicas.Add(clinica);
            }
        }

        private async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Opciones", "Cancelar", null, "Agregar Clínica", "Editar Clínica", "Eliminar Clínica", "Salir");
            switch (action)
            {
                case "Agregar Clínica":
                    await Navigation.PushAsync(new AddClinicaPage(_apiService));
                    break;
                case "Editar Clínica":
                    if (_viewModel.SelectedClinica != null)
                    {
                        await Navigation.PushAsync(new EditarClinica(_apiService, _viewModel.SelectedClinica));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Por favor, seleccione una clínica para editar", "OK");
                    }
                    break;
                case "Eliminar Clínica":
                    if (_viewModel.SelectedClinica != null)
                    {
                        var confirm = await DisplayAlert("Eliminar Clínica", "¿Está seguro que desea eliminar esta clínica?", "Sí", "No");
                        if (confirm)
                        {
                            var response = await _apiService.DeleteClinicaAsync(_viewModel.SelectedClinica.Id);
                            if (response.IsSuccessStatusCode)
                            {
                                await LoadClinicas();
                            }
                            else
                            {
                                await DisplayAlert("Error", "No se pudo eliminar la clínica", "OK");
                            }
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "Por favor, seleccione una clínica para eliminar", "OK");
                    }
                    break;
                case "Salir":
                    await Navigation.PushAsync(new LoginView());
                    break;
            }
        }

    }
}

