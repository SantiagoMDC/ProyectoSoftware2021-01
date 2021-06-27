using Entity;
using System;
using System.ComponentModel.DataAnnotations;
namespace Proyecto.Models
{
    public class PersonaInputModel
    {
        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es requerida")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        public string Apellido { get; set; }

        [Range(1, 99, ErrorMessage = "La edad debe estar en un rango de 1 a 99")]

        public int Edad { get; set; }

        [Required( ErrorMessage="El Sexo de ser Femenino o Masculino")]

        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string PaisDeProcedencia { get; set; }
        public string NivelEducativo { get; set; }
        public string Conocimiento1 { get; set; }
        public string Conocimiento2 { get; set; }
        public string Conocimiento3 { get; set; }
        public string Conocimiento4 { get; set; }
        public string Conocimiento5 { get; set; }
        public string ConocimientoExplicacion { get; set; }
        public string Actitud1 { get; set; }
        public string Actitud2 { get; set; }
        public string Actitud3 { get; set; }
        public string ActitudExplicacion { get; set; }
        public string Actitud5 { get; set; }
        public string Actitud6 { get; set; }
        public string Practica1 { get; set; }
        public string Practica2 { get; set; }
        public string Practica3 { get; set; }
        public string Practica4 { get; set; }
    }

    

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            EstadoCivil = persona.EstadoCivil;
            PaisDeProcedencia = persona.PaisDeProcedencia;
            NivelEducativo = persona.NivelEducativo;
            Conocimiento1 = persona.Conocimiento1;
            Conocimiento2 = persona.Conocimiento2;
            Conocimiento3 = persona.Conocimiento3;
            Conocimiento4 = persona.Conocimiento4;
            Conocimiento5 = persona.Conocimiento5;
            ConocimientoExplicacion = persona.ConocimientoExplicacion;
            Actitud1 = persona.Actitud1;
            Actitud2 = persona.Actitud2;
            Actitud3 = persona.Actitud3;
            ActitudExplicacion = persona.ActitudExplicacion;
            Actitud5 = persona.Actitud5;
            Actitud6 = persona.Actitud6;
            Practica1 = persona.Practica1;
            Practica2 = persona.Practica2;
            Practica3 = persona.Practica3;
            Practica4 = persona.Practica4;
        }
    }
}