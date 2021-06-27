using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Vinculacion
    {
        [Key]
        public string Codigo { get; set; }
        public string CodigoRestaurante { get; set; }
        public string NombreRestaurante { get; set; }
        public string CodigoPersona { get; set; }
        public string NombrePersona { get; set; }


        public void GenerarCodigo(){
            Codigo = CodigoRestaurante + CodigoPersona;
        }
        
    }
}
