using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ShippingTrackingMap:BaseMap<ShippingTracking>
    {
        public ShippingTrackingMap()
        {
            HasKey(x=>x.ID);
            Property(x => x.TrackingCode).HasColumnType("nvarchar").HasMaxLength(10).IsRequired();
            Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(150).IsRequired();
        }
    }
}
