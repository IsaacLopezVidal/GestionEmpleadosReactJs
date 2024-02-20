using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmpleados.Models.Domain
{
    public class SolicitudVacaciones
    {
        [Key]
        public int SolicitudID { get; set; }
        public int EmpleadoID { get; set; }
        public int EstatusID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string ComentarioJefe { get; set; }

        // Propiedades de navegación
        [ForeignKey("EmpleadoID")]
        public Empleado Empleado { get; set; }
        [ForeignKey("EstatusID")]
        public CatalogosDescripciones EstatusVacaciones { get; set; }
    }
}
