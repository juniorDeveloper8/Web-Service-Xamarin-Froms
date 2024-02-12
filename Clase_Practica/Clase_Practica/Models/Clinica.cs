namespace Clase_Practica.Models
{
    public class Clinica
    {
        public int Id { get; set; }
        public string ClinicaNombre { get; set; } // Cambiado de Nombre a ClinicaNombre
        public string Direccion { get; set; }
        public string Ruc { get; set; } // Cambiado de Telefono a Ruc
        public int Estado { get; set; }

        // Constructor por defecto
        public Clinica()
        {
        }

        //Constructor que copia los valores de otra instancia de Clinica
        public Clinica(Clinica clinica)
        {
            Id = clinica.Id;
            ClinicaNombre = clinica.ClinicaNombre;
            Direccion = clinica.Direccion;
            Ruc = clinica.Ruc;
            Estado = clinica.Estado;
        }

    }
}

