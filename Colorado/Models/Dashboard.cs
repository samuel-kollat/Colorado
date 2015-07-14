using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class Dashboard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Src { get; set; }
    }
}
