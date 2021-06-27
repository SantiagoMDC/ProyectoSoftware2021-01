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
    public class VinculacionController : ControllerBase
    {
        private readonly VinculacionService _vinculacionService;
        public IConfiguration Configuration { get; }
        public VinculacionController(PersonasContext context)
        {
            
            _vinculacionService = new VinculacionService(context);
        }
	private Vinculacion MapearVinculacion(VinculacionInputModel vinculacionInput)
        {
            var vinculacion = new Vinculacion
            {
                Codigo = vinculacionInput.CodigoRestaurante + vinculacionInput.CodigoPersona,
                CodigoRestaurante = vinculacionInput.CodigoRestaurante,
                NombreRestaurante = vinculacionInput.NombreRestaurante,
                CodigoPersona = vinculacionInput.CodigoPersona,
                NombrePersona = vinculacionInput.NombrePersona
                
            };    
            return vinculacion;
        }

       [HttpGet]
        public IEnumerable<VinculacionViewModel> Gets()
        {
            var vinculaciones = _vinculacionService.ConsultarTodos().Select(p=> new VinculacionViewModel(p));
            return vinculaciones;
        }

        [HttpPost]
        public ActionResult<VinculacionViewModel> Post(VinculacionInputModel vinculacionInput)
        {
            Vinculacion Vinculacion = MapearVinculacion(vinculacionInput);
            var response = _vinculacionService.Guardar(Vinculacion);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Vinculacion", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Vinculacion);
        }

        

        
    }
}