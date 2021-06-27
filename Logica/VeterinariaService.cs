using System;
using Datos;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class VeterinariaService
    {
        private readonly PersonasContext _context;
        

        public VeterinariaService(PersonasContext context)
        {
            _context = context;
        }

        public class GuardarVeterinariaResponse
        {
            public GuardarVeterinariaResponse(Veterinaria veterinaria)
            {
                Error = false;
                Veterinaria = veterinaria;
            }

            public GuardarVeterinariaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Veterinaria Veterinaria { get; set; }
        }

        public GuardarVeterinariaResponse Guardar(Veterinaria veterinaria)
        {
            try
            {
                var veterinariaBuscada = BuscarxIdentificacion(veterinaria.CodigoManipulador);
                if (veterinariaBuscada != null)
                {
                    return new GuardarVeterinariaResponse("Error: Ya se realizó el componente veterinario del manipulador");
                }
                _context.veterinarias.Add(veterinaria);
                
                _context.SaveChanges();
                return new GuardarVeterinariaResponse(veterinaria);
               
            }
            catch (Exception e)
            {
                return new GuardarVeterinariaResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }

        public List<Veterinaria> ConsultarTodos()
        {
            
            List<Veterinaria> veterinarias = _context.veterinarias.ToList();
           
            return veterinarias;
        }


         public Veterinaria BuscarxIdentificacion(string codigo)
        {
            Veterinaria veterinaria = _context.veterinarias.Find(codigo);
            return veterinaria;
        }

    }
}