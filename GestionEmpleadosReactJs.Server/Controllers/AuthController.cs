using GestionEmpleados.BusinessLogic.Services.Auth;
using GestionEmpleados.Models;
using GestionEmpleados.Models.Resurces;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;


namespace GestionEmpleadosReactJs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth) {
            _auth = auth;
        }
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_auth.ValidUser(model))
            {
                return Conflict(Messages.UserNotExists);
            }
            if (!_auth.ValidUserLogin(model))
            {
                return Unauthorized(Messages.AuthenticationFailure);
            }
            var Usurio = _auth.UserLogin(model);
            return Ok(Usurio);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_auth.ValidUser(model))
            {
                return Conflict(Messages.UserExist);
            }
            var UsuarioNuevo = _auth.UserRegister(model);
            return Ok();
        }

        [HttpGet("GetCargos")]
        public IActionResult GetCargos() => Ok(_auth.GetCargos());

        [HttpGet("GetDepartamentos")]
        public IActionResult gGtDepartamentos() => Ok(_auth.GetDepartamento());
    }
}
