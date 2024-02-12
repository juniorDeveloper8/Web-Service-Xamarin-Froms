using Clase_Practica.InfraStructura;
using Clase_Practica.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Clase_Practica.ViewModel
{
    public class EditarClinicaViewModel : BaseViewModel
    {
        private readonly int _id;

        public EditarClinicaViewModel(int id)
        {
            _id = id;
        }

        public async Task<HttpResponseMessage> ActualizarClinicaAsync(Clinica clinica)
        {
            try
            {
                return await UpdateClinicaAsync(_id, clinica);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la clínica: {ex.Message}");
                return null;
            }
        }
    }
}
