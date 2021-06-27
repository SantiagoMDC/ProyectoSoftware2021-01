using System.ComponentModel.DataAnnotations;

using Entity;
using System;
namespace Proyecto.Models
{
    public class AmbientalInputModel
    {
        [Required(ErrorMessage = "El codigo es requerido")]
        public string CodigoManipulador { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreManipulador { get; set; }

        [Required(ErrorMessage = "El barrio es requerido")]
        public string Barrio { get; set; }

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
        [Required(ErrorMessage = "El Item 7 es requerido")]
        public string Item7 { get; set; }
        [Required(ErrorMessage = "El Item 8 es requerido")]
        public string Item8 { get; set; }
        [Required(ErrorMessage = "El Item 9 es requerido")]
        public string Item9 { get; set; }
        
    }

    public class AmbientalViewModel : AmbientalInputModel
    {
        public AmbientalViewModel()
        {

        }
        public AmbientalViewModel(Ambiental ambiental)
        {   
            CodigoManipulador = ambiental.CodigoManipulador;
            NombreManipulador = ambiental.NombreManipulador;
            Barrio = ambiental.Barrio;
            Item1 = ambiental.Item1;
            Item2 = ambiental.Item2;
            Item3 = ambiental.Item3;
            Item4 = ambiental.Item4;
            Item5 = ambiental.Item5;
            Item6 = ambiental.Item6;
            Item7 = ambiental.Item7;
            Item8 = ambiental.Item8;
            Item9 = ambiental.Item9;
           
            
        }
    }
}