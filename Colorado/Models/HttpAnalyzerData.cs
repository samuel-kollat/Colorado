using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class HttpAnalyzerData
    {
        private string _method;

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Source IP")]
        public string SourceIp { get; set; }

        [Required]
        [DisplayName("Destination IP")]
        public string DestinationIp { get; set; }

        [Required]
        [DisplayName("HTTP method")]
        public string Method
        {
            get
            {
                string tmp;
                switch (_method)
                {
                    case "0":
                        tmp = "HEAD";
                        break;
                    case "1":
                        tmp = "GET";
                        break;
                    case "2":
                        tmp = "POST";
                        break;
                    case "3":
                        tmp = "PUT";
                        break;
                    case "4":
                        tmp = "DELETE";
                        break;
                    case "5":
                        tmp = "TRACE";
                        break;
                    case "6":
                        tmp = "CONNECT";
                        break;
                    default:
                        tmp = "(Response)";
                        break;
                }
                return tmp;
            }
            set { _method = value; }
        }

        [Required]
        [DisplayName("Quantity (B)")]
        public int Quantity { get; set; }
    }
}
