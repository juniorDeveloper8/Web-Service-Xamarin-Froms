using Clase_Practica.Services;
using Clase_Practica.ViewModel;
using System;
using System.Linq;
using Xamarin.Forms;

namespace Clase_Practica.View
{
    public partial class AddClinicaPage : ContentPage
    {
        public AddClinicaPage(ApiService apiService)
        {
            InitializeComponent();
            BindingContext = new AddClinicaViewModel(apiService);
        }

        private void OnInsertClinicaButtonClicked(object sender, EventArgs e)
        {
            if (BindingContext is AddClinicaViewModel viewModel)
            {
                viewModel.AddClinicaCommand.Execute(null);

                if (viewModel.IsInsertSuccessful)
                {
                    Navigation.PopAsync();

                    MessagingCenter.Send(this, "RefreshClinicas");
                }
                else
                {
                    DisplayAlert("Error", "Hubo un problema al agregar la clínica", "OK");
                }
            }
        }
    }
}
