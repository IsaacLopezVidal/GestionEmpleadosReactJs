using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models
{
    public class UserRegisterModel: LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public int IdCargo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string FirstName { get; set; }
    }
}
