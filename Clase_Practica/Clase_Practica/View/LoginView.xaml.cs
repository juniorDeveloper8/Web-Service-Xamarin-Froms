using Clase_Practica.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Clase_Practica.Services;

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