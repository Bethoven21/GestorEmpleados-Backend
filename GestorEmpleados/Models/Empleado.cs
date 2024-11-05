using System.ComponentModel.DataAnnotations;

namespace MiWebAPI.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public string Precio { get; set; }
        public int Total { get; set; }
        public int Subtotal { get; set; }
        public string Cliente { get; set; }
    }
}
