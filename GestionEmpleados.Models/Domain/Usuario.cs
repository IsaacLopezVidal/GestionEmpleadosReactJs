using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmpleados.Models.Domain
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public int EmpleadoID { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        // Propiedades de navegación
        [ForeignKey("EmpleadoID")]
        public Empleado Empleado { get; set; }
    }
}
