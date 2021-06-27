using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Ambiental
    {
        [Key]
        public string CodigoManipulador { get; set; }
        public string NombreManipulador { get; set; }
        public string Barrio {get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Item4 { get; set; }
        public string Item5 { get; set; }
        public string Item6 { get; set; }
        public string Item7 { get; set; }
        public string Item8 { get; set; }
        public string Item9 { get; set; }
    
    }
}
