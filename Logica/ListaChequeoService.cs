using System;
using Datos;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class ListaChequeoService
    {
        private readonly PersonasContext _context;
        

        public ListaChequeoService(PersonasContext context)
        {
            _context = context;
        }

        public class GuardarListaChequeoResponse
        {
            public GuardarListaChequeoResponse(ListaChequeo listaChequeo)
            {
                Error = false;
                ListaChequeo = listaChequeo;
            }

            public GuardarListaChequeoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public ListaChequeo ListaChequeo { get; set; }
        }

        public GuardarListaChequeoResponse Guardar(ListaChequeo listaChequeo)
        {
            try
            {
                var listaChequeoBuscada = BuscarxIdentificacion(listaChequeo.CodigoRestaurante);
                if (listaChequeoBuscada != null)
                {
                    return new GuardarListaChequeoResponse("Error: Ya se realizó el chequeo del establecimiento");
                }
                _context.listaChequeos.Add(listaChequeo);
                
                _context.SaveChanges();
                return new GuardarListaChequeoResponse(listaChequeo);
               
            }
            catch (Exception e)
            {
                return new GuardarListaChequeoResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }

        public List<ListaChequeo> ConsultarTodos()
        {
            
            List<ListaChequeo> listaChequeos = _context.listaChequeos.ToList();
           
            return listaChequeos;
        }


         public ListaChequeo BuscarxIdentificacion(string codigo)
        {
            ListaChequeo listaChequeo = _context.listaChequeos.Find(codigo);
            return listaChequeo;
        }

    }
}