using System.ComponentModel.DataAnnotations;

using Entity;
using System;
namespace Proyecto.Models
{
    public class VeterinariaInputModel
    {
        [Required(ErrorMessage = "El codigo es requerido")]
        public string CodigoManipulador { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreManipulador { get; set; }
        [Required(ErrorMessage = "El Item 1 es requerido")]
        public string Item1 { get; set; }
        [Required(ErrorMessage = "El Item 2 es requerido")]
        public string Item2 { get; set; }
        [Required(ErrorMessage = "El Item 3 es requerido")]
        public string Item3 { get; set; }
        [Required(ErrorMessage = "El Item 4 es requerido")]
        public string Item4 { get; set; }
        [Required(ErrorMessage = "El Item 5 es requerido")]
        public string Item5 { get; set; }
        [Required(ErrorMessage = "El Item 6 es requerido")]
        public string Item6 { get; set; }
        
    }

    public class VeterinariaViewModel : VeterinariaInputModel
    {
        public VeterinariaViewModel()
        {

        }
        public VeterinariaViewModel(Veterinaria veterinaria)
        {   
            CodigoManipulador = veterinaria.CodigoManipulador;
            NombreManipulador = veterinaria.NombreManipulador;
            Item1 = veterinaria.Item1;
            Item2 = veterinaria.Item2;
            Item3 = veterinaria.Item3;
            Item4 = veterinaria.Item4;
            Item5 = veterinaria.Item5;
            Item6 = veterinaria.Item6;
           
            
        }
    }
}