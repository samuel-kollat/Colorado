using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    public class Application
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Application Name")]
        public string name { get; set; }

        [DisplayName("Active")]
        public int? active_flag { get; set; }

        [ForeignKey("Certificate")]
        [DisplayName("Used Certificate")]
        public int certificate_id { get; set; }
        public virtual Certificate Certificate { get; set; }

        [ForeignKey("Analyzer")]
        [DisplayName("Used Analyzer")]
        public int analyzer_id { get; set; }
        public virtual Analyzer Analyzer { get; set; }
    }
}
