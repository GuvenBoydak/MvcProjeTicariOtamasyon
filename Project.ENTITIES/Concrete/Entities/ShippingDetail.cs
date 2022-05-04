using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class ShippingDetail:BaseEntity
    {
        public string Description { get; set; }
        public string TrackingCode { get; set; }
        public string Employee { get; set; }
        public string Receiver { get; set; }
    }
}
