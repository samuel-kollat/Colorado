using System.ComponentModel.DataAnnotations;

namespace Colorado.Models
{
    public class Analyzer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string src { get; set; }
        public string args { get; set; }
    }
}
