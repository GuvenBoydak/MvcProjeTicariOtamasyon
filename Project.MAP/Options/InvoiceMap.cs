using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class InvoiceMap:BaseMap<Invoice>
    {
        public InvoiceMap()
        {
            HasKey(x=>x.ID);
            Property(x => x.SerialNo).HasColumnType("nvarchar").HasMaxLength(1).IsRequired();
            Property(x => x.Time).HasColumnType("nvarchar").HasMaxLength(5).IsRequired();
            Property(x => x.InvoiceNumber).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x => x.TaxAuthorityNumber).HasColumnType("nvarchar").HasMaxLength(60).IsRequired();
            Property(x => x.Submitter).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
            Property(x => x.Receiver).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
        }
    }
}
