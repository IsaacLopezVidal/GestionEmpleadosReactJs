using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmpleados.Models.Domain
{
    public class Familiar
    {
        [Key]
        public int FamiliarID { get; set; }

        public int EmpleadoID { get; set; }
        [ForeignKey("EmpleadoID")]
        public Empleado Empleado { get; set; }

        public int RelacionID { get; set; }
        [ForeignKey("RelacionID")]
        public CatalogosDescripciones TipoRelacion { get; set; }

        public string Nombre { get; set; }
    }
}
