using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Proyecto.Config;
using Proyecto.Models;


namespace Proyecto.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]  
    public class LoginController : ControllerBase
    {
        PersonasContext _context;
        private readonly UserService _usuarioService;
        JwtService _jwtService;

        public LoginController(PersonasContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
	        var admin = _context.Users.Find("micro");
            if (admin == null) 
            {
		    _context.Users.Add(new User() 
           { 
		         UserName="micro", 
			    Password="Proyecto2020", 
	               Email="admin@gmail.com", 
                    Estado="AC", 
                    FirstName="Adminitrador", 
                    LastName="", 
                    MobilePhone="31800000000"}
		);
		var registrosGuardados=_context.SaveChanges();
	}
	_usuarioService = new UserService(context);
	_jwtService = new JwtService(appSetting);


        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User userP)
        {
            var user = _usuarioService.Validate(userP.UserName,userP.Password);
            if (user == null)return BadRequest("Usuario o contraseña incorrecto");
            var response = _jwtService.GenerateToken(user);
            return Ok(response);
        }
        
        
    }
}


        