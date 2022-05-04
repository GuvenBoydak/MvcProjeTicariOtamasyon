using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class ShippingTracking:BaseEntity
    {
        public string TrackingCode { get; set; }
        public string Description { get; set; }
    }
}
