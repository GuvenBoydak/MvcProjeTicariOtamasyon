using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class ShippingDetailVM
    {
        public List<ShippingDetail> ShippingDetails { get; set; }
        public List<ShippingTracking> ShippingTrackings { get; set; }
        public ShippingTracking ShippingTracking { get; set; }
        public ShippingDetail ShippingDetail { get; set; }
    }
}