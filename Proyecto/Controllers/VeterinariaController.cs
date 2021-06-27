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
    public class VeterinariaController : ControllerBase
    {
        private readonly VeterinariaService _veterinariaService;
        public IConfiguration Configuration { get; }
        public VeterinariaController(PersonasContext context)
        {
            
            _veterinariaService = new VeterinariaService(context);
        }
	    private Veterinaria MapearVeterinaria(VeterinariaInputModel veterinariaInputModel)
        {
            var veterinaria = new Veterinaria
            {
                
            CodigoManipulador = veterinariaInputModel.CodigoManipulador,
            NombreManipulador = veterinariaInputModel.NombreManipulador,
            Item1 = veterinariaInputModel.Item1,
            Item2 = veterinariaInputModel.Item2,
            Item3 = veterinariaInputModel.Item3,
            Item4 = veterinariaInputModel.Item4,
            Item5 = veterinariaInputModel.Item5,
            Item6 = veterinariaInputModel.Item6
                
            };    
            return veterinaria;
        }

       [HttpGet]
        public IEnumerable<VeterinariaViewModel> Gets()
        {
            var veterinarias = _veterinariaService.ConsultarTodos().Select(p=> new VeterinariaViewModel(p));
            return veterinarias;
        }

        [HttpPost]
        public ActionResult<VeterinariaViewModel> Post(VeterinariaInputModel veterinariaInputModel)
        {
            Veterinaria veterinaria = MapearVeterinaria(veterinariaInputModel);
            var response = _veterinariaService.Guardar(veterinaria);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Veterinaria", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Veterinaria);
        
        }

        [HttpGet("{codigo}")]
        public Veterinaria Get(string codigo)
        {
            var veterinaria = _veterinariaService.BuscarxIdentificacion(codigo);
            return veterinaria;
        }

        
    }
}