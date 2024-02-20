using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmpleados.Models.Domain
{
    public class CatalogosDescripciones
    {
        [Key]
        public int CatalogoDescripcionId { get; set; }
        public int CatalogoId { get; set; }

        [MaxLength(500)]
        [Required(ErrorMessage = "Campo requerido")]
        public string Descripcion { get; set; }

        public int ValorEntero { get; set; }
        public double ValorDouble { get; set; }
        public DateTime ValorFecha { get; set; }
        public string ValorAlfanumerico { get; set; }

        [ForeignKey("CatalogoId")]
        public Catalogos Catalogos { get; set; }

    }
}
