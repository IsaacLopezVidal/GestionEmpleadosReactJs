using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmpleados.Models.Domain
{
    public class Empleado
    {
        [Key]
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CargoID { get; set; }
        [ForeignKey("CargoID")]
        public CatalogosDescripciones Cargo { get; set; }

        public int DepartamentoID { get; set; }
        [ForeignKey("DepartamentoID")]
        public CatalogosDescripciones Departamento { get; set; }
    }
}
