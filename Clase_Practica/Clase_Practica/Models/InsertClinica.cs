using System;

namespace Clase_Practica.Models
{
    public class InsertClinica
    {
        public string ClinicaNombre { get; set; }
        public string Direccion { get; set; }
        public string Ruc { get; set; }
        public InsertClinica()
        {
        }
        public InsertClinica(InsertClinica insert)
        {
            ClinicaNombre = insert.ClinicaNombre;
            Direccion = insert.Direccion;
            Ruc = insert.Ruc;
        }
    }
}
