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
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _personaService;
        public IConfiguration Configuration { get; }
        public PersonaController(PersonasContext context)
        {
            
            _personaService = new PersonaService(context);
        }
	private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Identificacion = personaInput.Identificacion,
                Nombre = personaInput.Nombre,
                Edad = personaInput.Edad,
                Sexo = personaInput.Sexo,
                Apellido = personaInput.Apellido,
                EstadoCivil = personaInput.EstadoCivil,
                PaisDeProcedencia = personaInput.PaisDeProcedencia,
                NivelEducativo = personaInput.NivelEducativo,
                Conocimiento1 = personaInput.Conocimiento1,
                Conocimiento2 = personaInput.Conocimiento2,
                Conocimiento3 = personaInput.Conocimiento3,
                Conocimiento4 = personaInput.Conocimiento4,
                Conocimiento5 = personaInput.Conocimiento5,
                ConocimientoExplicacion = personaInput.ConocimientoExplicacion,
                Actitud1 = personaInput.Actitud1,
                Actitud2 = personaInput.Actitud2,
                Actitud3 = personaInput.Actitud3,
                ActitudExplicacion = personaInput.ActitudExplicacion,
                Actitud5 = personaInput.Actitud5,
                Actitud6 = personaInput.Actitud6,
                Practica1 = personaInput.Practica1,
                Practica2 = personaInput.Practica2,
                Practica3 = personaInput.Practica3,
                Practica4 = personaInput.Practica4
            };
            return persona;
        }

       [HttpGet]
        public IEnumerable<PersonaViewModel> Gets()
        {
            var personas = _personaService.ConsultarTodos().Select(p=> new PersonaViewModel(p));
            return personas;
        }

        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _personaService.Guardar(persona);
            if (response.Error) 
            {
               ModelState.AddModelError("Guardar Persona", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                Status = StatusCodes.Status400BadRequest,
                };
                    return BadRequest(problemDetails);

            }
                return Ok(response.Persona);
         }

        [HttpGet("{identificacion}")]
        public Persona Get(string identificacion)
        {
            var persona = _personaService.BuscarxIdentificacion(identificacion);
            return persona;
        }

        
    }
}