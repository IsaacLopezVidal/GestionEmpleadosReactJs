using GestionEmpleados.Models;

namespace GestionEmpleados.BusinessLogic.Services.Auth
{
    public interface IAuth
    {
        public UserRegisterModel UserRegister(UserRegisterModel model);
        public UserLogged UserLogin(LoginModel model);
        public bool ValidUserLogin(LoginModel model);
        public bool ValidUser(LoginModel model);
        public IEnumerable<CombosModel> GetCargos();
        public IEnumerable<CombosModel> GetDepartamento();
    }
}
