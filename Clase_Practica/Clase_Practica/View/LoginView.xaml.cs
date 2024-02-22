using Clase_Practica.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clase_Practica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }
        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            var loginService = new LoginService();

            var isLoggedIn = await loginService.LoginAsync(txtUser.Text, txtClave.Text);

            if (isLoggedIn)
            {
                await Navigation.PushAsync(new Home());
            }
            else
            {
                await DisplayAlert("Mensaje", "datos invalidos", "ok");
            }
        }
    }
}