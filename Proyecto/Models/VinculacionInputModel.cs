using Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class VinculacionInputModel
    {   
        [Required(ErrorMessage = "El codigo es requerido")]
        public string CodigoRestaurante { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreRestaurante { get; set; }
        [Required(ErrorMessage = "El codigo es requerido")]
        public string CodigoPersona { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombrePersona { get; set; }
        
    }

    public class VinculacionViewModel : VinculacionInputModel
    {
        public VinculacionViewModel()
        {

        }
        public VinculacionViewModel(Vinculacion vinculacion)
        {   
            Codigo = vinculacion.Codigo;
            CodigoRestaurante = vinculacion.CodigoRestaurante;
            NombreRestaurante = vinculacion.NombreRestaurante;
            CodigoPersona = vinculacion.CodigoPersona;
            NombrePersona = vinculacion.NombrePersona;
        }
        public string Codigo {get;set;}
    }
}