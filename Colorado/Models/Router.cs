using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    public class Router
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Management IP")]
        public string management_ip { get; set; }

        [Required]
        [DisplayName("Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [DisplayName("Interfaces")]
        public string interfaces { get; set; }

        [ForeignKey("Application")]
        [DisplayName("Application")]
        public int application_id { get; set; }
        public Application Application { get; set; }
    }
}
