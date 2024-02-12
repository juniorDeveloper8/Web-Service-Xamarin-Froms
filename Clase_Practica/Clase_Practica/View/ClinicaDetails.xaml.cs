using Clase_Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Clase_Practica.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClinicaDetails : TabbedPage
    {
        public ClinicaDetails(Clinica clinica)
        {
            InitializeComponent();
            BindingContext = clinica;
        }
    }
}