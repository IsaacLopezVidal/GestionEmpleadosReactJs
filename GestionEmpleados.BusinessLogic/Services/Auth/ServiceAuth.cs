using DotNetEnv;
using GestionEmpleados.AccessData;
using GestionEmpleados.Models;
using GestionEmpleados.Models.Domain;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionEmpleados.BusinessLogic.Services.Auth
{
    public class ServiceAuth : IAuth
    {
        private readonly DatabaseContext _dbcontext;
        public ServiceAuth(DatabaseContext database)
        {
            _dbcontext= database; 
        }
        public UserLogged UserLogin(LoginModel model)
        {

            var user = _dbcontext.Usuario.Include(e=>e.Empleado).First(e => e.EmailAddress == model.EmailAddress);
            var roles = _dbcontext.UsuarioRol.Include(e => e.Rol).Where(e => e.UsuarioID == user.UsuarioID && e.Rol.CatalogoId==3).Select(s => new Roles(){ Id= s.Rol.CatalogoDescripcionId,Rol=s.Rol.Descripcion });
            
            return new UserLogged()
            {
                user = new DataUser
                {
                    id=user.UsuarioID,
                    username = $"{user.Empleado.Nombre} {user.Empleado.Apellido}",
                    Roles = roles,
                },
                token = GetToken()
            };

        }
        private string GetToken()
        {
            Env.Load();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Env.GetString("CLAVE_SECRETA")));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(signingCredentials: credentials,expires: DateTime.Now.AddHours(1));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string GethashedPassword(string Password,string Salt)=> BCrypt.Net.BCrypt.HashPassword(Password + Salt, Salt, true, hashType: BCrypt.Net.HashType.SHA384);
        private bool GethashedVerify(string Password, string Salt, string HashedPassword) => BCrypt.Net.BCrypt.Verify(Password+Salt, HashedPassword,true,hashType:BCrypt.Net.HashType.SHA384);
        public UserModel UserRegister(UserModel model)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = GethashedPassword(model.Password, salt);
            Empleado empleado = new Empleado()
            {
                Nombre = model.FirstName,
                Apellido = model.LastName,
                CargoID = 1000,
                DepartamentoID = 2000
            };
            _dbcontext.Add(empleado);
            _dbcontext.SaveChanges();

            Usuario usuario = new Usuario()
            {
                EmpleadoID = empleado.EmpleadoID,
                EmailAddress = model.EmailAddress,
                HashedPassword = hashedPassword,
                Salt = salt
            };
            _dbcontext.Add(usuario);
            _dbcontext.SaveChanges();
            model.Password = string.Empty;
            return model;
        }

        public bool ValidUser(LoginModel model)
        {
            return _dbcontext.Usuario.Any(e => e.EmailAddress == model.EmailAddress);
        }

        public bool ValidUserLogin(LoginModel model)
        {
            var user = _dbcontext.Usuario.First(e => e.EmailAddress == model.EmailAddress);
            return GethashedVerify(model.Password,user.Salt, user.HashedPassword);
        }
    }
}
