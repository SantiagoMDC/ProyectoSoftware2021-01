using System;
using System.Collections.Generic;
using System.Linq;
using Logica;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Proyecto.Models;
using Datos;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaChequeoController : ControllerBase
    {
        private readonly ListaChequeoService _listaChequeoService;
        public IConfiguration Configuration { get; }
        public ListaChequeoController(PersonasContext context)
        {
            
            _listaChequeoService = new ListaChequeoService(context);
        }
	    private ListaChequeo MapearListaChequeo(ListaChequeoInputModel listaChequeoInputModel)
        {
            var listaChequeo = new ListaChequeo
            {
                CodigoRestaurante = listaChequeoInputModel.CodigoRestaurante,
            NombreRestaurante = listaChequeoInputModel.NombreRestaurante,
            Item1 = listaChequeoInputModel.Item1,
            Item2 = listaChequeoInputModel.Item2,
            Item3 = listaChequeoInputModel.Item3,
            Item4 = listaChequeoInputModel.Item4,
            Item5 = listaChequeoInputModel.Item5,
            Item6 = listaChequeoInputModel.Item6,
            Item7 = listaChequeoInputModel.Item7,
            Item8 = listaChequeoInputModel.Item8,
            Item9 = listaChequeoInputModel.Item9
                
            };    
            return listaChequeo;
        }

       [HttpGet]
        public IEnumerable<ListaChequeoViewModel> Gets()
        {
            var listaChequeos = _listaChequeoService.ConsultarTodos().Select(p=> new ListaChequeoViewModel(p));
            return listaChequeos;
        }

        [HttpPost]
        public ActionResult<ListaChequeoViewModel> Post(ListaChequeoInputModel listaChequeoInputModel)
        {
            ListaChequeo ListaChequeo = MapearListaChequeo(listaChequeoInputModel);
            var response = _listaChequeoService.Guardar(ListaChequeo);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar ListaChequeo", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.ListaChequeo);
        
        }

        [HttpGet("{codigo}")]
        public ListaChequeo Get(string codigo)
        {
            var listaChequeo = _listaChequeoService.BuscarxIdentificacion(codigo);
            return listaChequeo;
        }

        
    }
}