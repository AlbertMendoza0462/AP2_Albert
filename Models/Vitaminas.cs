using System.ComponentModel.DataAnnotations;

namespace AP2_Albert.Models
{
    public class Vitaminas
    {
        [Key]
        public int VitaminaId { get; set; }
        [Required(ErrorMessage = "Digite la descripcion de la vitamina.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Digite la unidad de medida de la vitamina.")]
        public string UnidadMedida { get; set; }
        public double Existencia { get; set; } = 0;
    }
}
