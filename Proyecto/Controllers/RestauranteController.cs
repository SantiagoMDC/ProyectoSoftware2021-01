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
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Proyecto.Hubs;

namespace Proyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteService _restauranteService;
        private readonly IHubContext<SignalHub> _hubContext;
        public IConfiguration Configuration { get; }
        public RestauranteController(PersonasContext context, IHubContext<SignalHub> hubContext)
        {
            _hubContext = hubContext;
            _restauranteService = new RestauranteService(context);
        }
	private Restaurante MapearRestaurante(RestauranteInputModel restauranteInput)
        {
            var restaurante = new Restaurante
            {
                Codigo = restauranteInput.Codigo,
                Nombre = restauranteInput.Nombre,
                Direccion = restauranteInput.Direccion,
                Telefono = restauranteInput.Telefono
                
            };    
            return restaurante;
        }

       [HttpGet]
        public IEnumerable<RestauranteViewModel> Gets()
        {
            var restaurantes = _restauranteService.ConsultarTodos().Select(p=> new RestauranteViewModel(p));
            return restaurantes;
        }

        [HttpPost]
        public async Task<ActionResult<RestauranteViewModel>> PostAsync(RestauranteInputModel restauranteInput)
        {
            Restaurante Restaurante = MapearRestaurante(restauranteInput);
            var response = _restauranteService.Guardar(Restaurante);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Restaurante", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            await _hubContext.Clients.All.SendAsync("RegistrarRestaurante", response.Restaurante);
            return Ok(response.Restaurante);
        }

        [HttpGet("{codigo}")]
        public Restaurante Get(string codigo)
        {
            var restaurante = _restauranteService.BuscarxIdentificacion(codigo);
            return restaurante;
        }

        private Restaurante MapearRestaurante(Restaurante restaurante){
            var _restaurante = new Restaurante{
                Codigo = restaurante.Codigo,
                Nombre = restaurante.Nombre,
                Direccion = restaurante.Direccion,
                Telefono = restaurante.Telefono
            };
            return _restaurante;
        }

        
    }
}