using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models
{
    public class UserModel: LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string Username { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string Rol { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string LastName { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string FirstName { get; set; }
    }
}
