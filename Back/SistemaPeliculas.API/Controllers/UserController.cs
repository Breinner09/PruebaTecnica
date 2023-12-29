using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SistemaPeliculas.Logica.Servicios.Metodos;
using SistemaPeliculas.DTO;
using SistemaPeliculas.API.Utilidad;
using SistemaPeliculas.Logica.Servicios;

namespace SistemaPeliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> login([FromBody] LoginDTO login)
        {
            var rsp = new Response<SesionDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _userService.ValidacionCredenciales(login.UserName, login.Password);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }

        [HttpPost]
        [Route("registro")]

        public async Task<IActionResult> registro([FromBody] UserDTO user)
        {
            var rsp = new Response<UserDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _userService.Registrar(user);


            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.message = ex.Message;
            }

            return Ok(rsp);
        }
    }
}
