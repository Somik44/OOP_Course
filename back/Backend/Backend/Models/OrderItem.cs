using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Backend.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; }

        [Required]
        [ForeignKey("Заказы")]
        public int OrderID { get; set; }

        [Required]
        [ForeignKey("Товары")]
        public int ProductID { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
