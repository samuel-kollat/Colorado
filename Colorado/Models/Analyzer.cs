using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class Analyzer
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Analyzer Name")]
        public string name { get; set; }

        [DisplayName("Description")]
        public string description { get; set; }

        [Required]
        [DisplayName("Identification")]
        public string src { get; set; }

        [DisplayName("Arguments")]
        public string args { get; set; }
    }
}
