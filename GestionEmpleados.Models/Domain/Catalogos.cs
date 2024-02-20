using System.ComponentModel.DataAnnotations;

namespace GestionEmpleados.Models.Domain
{
    public class Catalogos
    {
        [Key]
        public int CatalogoId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(50)]
        public string Catalogo { get; set; }
    }
}
