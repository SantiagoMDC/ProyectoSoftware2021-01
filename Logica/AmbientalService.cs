using System;
using Datos;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class AmbientalService
    {
        private readonly PersonasContext _context;
        

        public AmbientalService(PersonasContext context)
        {
            _context = context;
        }

        public class GuardarAmbientalResponse
        {
            public GuardarAmbientalResponse(Ambiental ambiental)
            {
                Error = false;
                Ambiental = ambiental;
            }

            public GuardarAmbientalResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Ambiental Ambiental { get; set; }
        }

        public GuardarAmbientalResponse Guardar(Ambiental ambiental)
        {
            try
            {
                var ambientalBuscada = BuscarxIdentificacion(ambiental.CodigoManipulador);
                if (ambientalBuscada != null)
                {
                    return new GuardarAmbientalResponse("Error: Ya se realizó el componente ambiental del manipulador");
                }
                _context.ambientales.Add(ambiental);
                
                _context.SaveChanges();
                return new GuardarAmbientalResponse(ambiental);
               
            }
            catch (Exception e)
            {
                return new GuardarAmbientalResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }

        public List<Ambiental> ConsultarTodos()
        {
            
            List<Ambiental> ambientales = _context.ambientales.ToList();
           
            return ambientales;
        }


         public Ambiental BuscarxIdentificacion(string codigo)
        {
            Ambiental ambiental = _context.ambientales.Find(codigo);
            return ambiental;
        }

    }
}