using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    public class Filter
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Filter Name")]
        public string name { get; set; }

        [DisplayName("Type")]
        public string type { get; set; }

        [ForeignKey("Application")]
        [DisplayName("Application")]
        public int application_id { get; set; }
        public Application Application { get; set; }

    }
}
