using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colorado.Models
{
    public class FilterHasNbarProtocol
    {
        [ForeignKey("Filter")]
        public int filter_id { get; set; }

        [ForeignKey("NbarProtocol")]
        public int nbar_protocol_id { get; set; }

        public virtual Filter Filter { get; set; }
        public virtual NbarProtocol NbarProtocol { get; set; }
    }
}
