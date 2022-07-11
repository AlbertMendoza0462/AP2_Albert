using System.ComponentModel.DataAnnotations;

namespace AP2_Albert.Models
{
    public class VerdurasDetalle
    {
        [Key]
        public int VerdurasDetalleId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Un detalle debe tener a una verdura.")]
        public int VerduraId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Una verdura debe tener a una vitamina.")]
        public int VitaminaId { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "Digite la cantidad.")]
        public double Cantidad { get; set; }
    }
}
