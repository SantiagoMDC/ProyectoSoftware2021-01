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
    public class AmbientalController : ControllerBase
    {
        private readonly AmbientalService _ambientalService;
        public IConfiguration Configuration { get; }
        public AmbientalController(PersonasContext context)
        {
            
            _ambientalService = new AmbientalService(context);
        }
	    private Ambiental MapearAmbiental(AmbientalInputModel ambientalInputModel)
        {
            var ambiental = new Ambiental
            {
                
            CodigoManipulador = ambientalInputModel.CodigoManipulador,
            NombreManipulador = ambientalInputModel.NombreManipulador,
            Barrio = ambientalInputModel.Barrio,
            Item1 = ambientalInputModel.Item1,
            Item2 = ambientalInputModel.Item2,
            Item3 = ambientalInputModel.Item3,
            Item4 = ambientalInputModel.Item4,
            Item5 = ambientalInputModel.Item5,
            Item6 = ambientalInputModel.Item6,
            Item7 = ambientalInputModel.Item7,
            Item8 = ambientalInputModel.Item8,
            Item9 = ambientalInputModel.Item9
                
            };    
            return ambiental;
        }

       [HttpGet]
        public IEnumerable<AmbientalViewModel> Gets()
        {
            var ambientales = _ambientalService.ConsultarTodos().Select(p=> new AmbientalViewModel(p));
            return ambientales;
        }

        [HttpPost]
        public ActionResult<AmbientalViewModel> Post(AmbientalInputModel ambientalInputModel)
        {
            Ambiental ambiental = MapearAmbiental(ambientalInputModel);
            var response = _ambientalService.Guardar(ambiental);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Ambiental", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Ambiental);
        
        }

        [HttpGet("{codigo}")]
        public Ambiental Get(string codigo)
        {
            var ambiental = _ambientalService.BuscarxIdentificacion(codigo);
            return ambiental;
        }

        
    }
}