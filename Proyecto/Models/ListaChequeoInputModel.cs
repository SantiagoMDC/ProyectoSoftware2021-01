using System.ComponentModel.DataAnnotations;

using Entity;
using System;
namespace Proyecto.Models
{
    public class ListaChequeoInputModel
    {
        [Required(ErrorMessage = "El codigo es requerido")]
        public string CodigoRestaurante { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string NombreRestaurante { get; set; }

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

    public class ListaChequeoViewModel : ListaChequeoInputModel
    {
        public ListaChequeoViewModel()
        {

        }
        public ListaChequeoViewModel(ListaChequeo listaChequeo)
        {   
            CodigoRestaurante = listaChequeo.CodigoRestaurante;
            NombreRestaurante = listaChequeo.NombreRestaurante;
            Item1 = listaChequeo.Item1;
            Item2 = listaChequeo.Item2;
            Item3 = listaChequeo.Item3;
            Item4 = listaChequeo.Item4;
            Item5 = listaChequeo.Item5;
            Item6 = listaChequeo.Item6;
            Item7 = listaChequeo.Item7;
            Item8 = listaChequeo.Item8;
            Item9 = listaChequeo.Item9;
           
            
        }
    }
}