using GestionEmpleados.Models;
using GestionEmpleados.Models.Domain;

namespace GestionEmpleados.BusinessLogic.Services.Auth
{
    public interface IAuth
    {
        public UserModel UserRegister(UserModel model);
        public UserLogged UserLogin(LoginModel model);
        public bool ValidUserLogin(LoginModel model);
        public bool ValidUser(LoginModel model);
    }
}
