using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class Certificate
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Certificate Name")]
        public string name { get; set; }

        [DisplayName("Certificate Path")]
        public string root_cert_path { get; set; }
    }
}
