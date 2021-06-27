using System;
using Datos;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class VinculacionService
    {
        private readonly PersonasContext _context;
        

        public VinculacionService(PersonasContext context)
        {
            _context = context;
        }

        public class GuardarVinculacionResponse
        {
            public GuardarVinculacionResponse(Vinculacion vinculacion)
            {
                Error = false;
                Vinculacion = vinculacion;
            }

            public GuardarVinculacionResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Vinculacion Vinculacion { get; set; }
        }

        public GuardarVinculacionResponse Guardar(Vinculacion vinculacion)
        {
            try
            {
                _context.vinculaciones.Add(vinculacion);
                
                _context.SaveChanges();
                return new GuardarVinculacionResponse(vinculacion);
               
            }
            catch (Exception e)
            {
                return new GuardarVinculacionResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }

        public List<Vinculacion> ConsultarTodos()
        {
            
            List<Vinculacion> vinculaciones = _context.vinculaciones.ToList();
           
            return vinculaciones;
        }

    }
}