using Clase_Practica.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clase_Practica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = MainPage = new NavigationPage (new LoginView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
