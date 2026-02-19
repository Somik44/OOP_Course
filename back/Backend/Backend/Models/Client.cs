using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int ClientID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public float Balance { get; set; }

        [Required]
        public string Password { get; set; } = "0000";
    }
}
