using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmpleados.Models.Domain
{
    public class UsuarioRol
    {
        public int UsuarioID { get; set; }
        public int RolID { get; set; }

        // Propiedades de navegación
        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }
        [ForeignKey("RolID")]
        public CatalogosDescripciones Rol { get; set; }
    }
}
