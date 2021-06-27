using System.ComponentModel.DataAnnotations;

using Entity;
using System;
namespace Proyecto.Models
{
    public class RestauranteInputModel
    {
        [Required(ErrorMessage = "El codigo es requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La direccion es requerida")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Se requiere telefono")]  
        [Display(Name = "Contact Number")]  
        [DataType(DataType.PhoneNumber)] 
        public string Telefono { get; set; }
        
    }

    public class RestauranteViewModel : RestauranteInputModel
    {
        public RestauranteViewModel()
        {

        }
        public RestauranteViewModel(Restaurante restaurante)
        {   
            Codigo = restaurante.Codigo;
            Nombre = restaurante.Nombre;
            Direccion = restaurante.Direccion;
            Telefono = restaurante.Telefono;
        }
    }
}