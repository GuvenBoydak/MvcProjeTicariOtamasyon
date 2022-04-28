using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class InvoiceBodyMap:BaseMap<InvoiceBody>
    {
        public InvoiceBodyMap()
        {
            HasKey(x=>x.ID);
            Property(x => x.Description).HasColumnType("nvarchar").HasMaxLength(100);
        }
    }
}
