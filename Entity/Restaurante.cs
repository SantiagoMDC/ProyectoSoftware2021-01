using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Restaurante
    {
        [Key]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        
    }
}
