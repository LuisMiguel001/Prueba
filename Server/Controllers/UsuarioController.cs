using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Server.DAL;
using Prueba.Shared;

namespace Prueba.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
		private readonly Context _context;

		public UsuarioController(Context context)
		{
			_context = context;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(Usuarios user)
		{
			var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == user.Correo);

			if (existingUser != null)
			{
				return BadRequest("El usuario ya existe");
			}

			_context.Usuarios.Add(user);
			await _context.SaveChangesAsync();

			return Ok("Registro exitoso");
		}

		[HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Usuarios login)
        {
            session sesionDTO = new session();

            if (login.Correo == "admin@gmail.com" && login.Clave == "admin")
            {
                sesionDTO.Nombre = "admin";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";
            }
			else
			{
				var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == login.Correo && u.Clave == login.Clave);

				if (existingUser != null)
				{
					sesionDTO.Nombre = "Usuario";
					sesionDTO.Correo = login.Correo;
					sesionDTO.Rol = "Usuarios";
				}
				else
				{
					return NotFound();
				}
			}

			return StatusCode(StatusCodes.Status200OK, sesionDTO);
        }
    }
}
