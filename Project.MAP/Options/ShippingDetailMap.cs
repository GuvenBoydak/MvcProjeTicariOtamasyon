using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ShippingDetailMap:BaseMap<ShippingDetail>
    {
        public ShippingDetailMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(250).IsRequired();
            Property(x => x.TrackingCode).HasColumnType("nvarchar").HasMaxLength(10).IsRequired();
            Property(x => x.Employee).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
            Property(x => x.Receiver).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
        }
    }
}
