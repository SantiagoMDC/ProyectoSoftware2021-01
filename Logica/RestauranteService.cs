using System;
using Datos;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class RestauranteService
    {
        private readonly PersonasContext _context;
        

        public RestauranteService(PersonasContext context)
        {
            _context = context;
        }

        public class GuardarRestauranteResponse
        {
            public GuardarRestauranteResponse(Restaurante restaurante)
            {
                Error = false;
                Restaurante = restaurante;
            }

            public GuardarRestauranteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }

            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Restaurante Restaurante { get; set; }
        }

        public GuardarRestauranteResponse Guardar(Restaurante restaurante)
        {
            try
            {
                var restauranteBuscada = BuscarxIdentificacion(restaurante.Codigo);
                if (restauranteBuscada != null)
                {
                    return new GuardarRestauranteResponse("Error: El establecimiento ya se encuentra registrado");
                }
                _context.restaurantes.Add(restaurante);
                
                _context.SaveChanges();
                return new GuardarRestauranteResponse(restaurante);
               
            }
            catch (Exception e)
            {
                return new GuardarRestauranteResponse($"Error de la Aplicacion: {e.Message}");
            }
            
        }

        public List<Restaurante> ConsultarTodos()
        {
            
            List<Restaurante> restaurantes = _context.restaurantes.ToList();
           
            return restaurantes;
        }


         public Restaurante BuscarxIdentificacion(string codigo)
        {
            Restaurante restaurante = _context.restaurantes.Find(codigo);
            return restaurante;
        }

        public RestauranteResponse ActualizarRestaurante(Restaurante restaurante)
        {
            try
            {
              
                Restaurante restauranteEcontrado = _context.restaurantes.Find(restaurante.Codigo);
                if (restauranteEcontrado != null)
                {
                    restauranteEcontrado.Nombre = restaurante.Nombre;
                    restauranteEcontrado.Direccion = restaurante.Direccion;
                    restauranteEcontrado.Telefono = restaurante.Telefono;
                    _context.restaurantes.Update(restauranteEcontrado);
                    _context.SaveChanges();
                    return  new RestauranteResponse(restauranteEcontrado);
                }else
                {
                      return new RestauranteResponse($"El restaurante {restaurante.Nombre} no existe no se encontro"); 
                }
            }
            catch(Exception e)
            {
                return new RestauranteResponse("Error:" + e.Message);
            }           
                  
        }
       
       public class RestauranteResponse
       {
           public RestauranteResponse(Restaurante restaurante)
           {
                Error = false;
                Restaurante = restaurante;
           }
           public RestauranteResponse(string mensaje)
           {
               Error =  true;
               Mensaje = mensaje;
           }

           public string Mensaje { get; set; }
           public bool Error { get; set; }
           public Restaurante Restaurante { get; set; }
       }
    }
}