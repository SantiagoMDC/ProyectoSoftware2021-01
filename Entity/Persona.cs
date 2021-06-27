using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Persona
    {
        [Key]
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
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
}
