using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models
{
    public class LoginModel
    {
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resurces.Messages), ErrorMessageResourceName = "FieldRequired")]
        public string Password { get; set; }

    }
}
