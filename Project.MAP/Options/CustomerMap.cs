using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class CustomerMap:BaseMap<Customer>
    {
        public CustomerMap()
        {
            HasKey(x=>x.ID);
            Property(x=>x.FirstName).HasColumnType("nvarchar").HasMaxLength(40);
            Property(x=>x.LastName).HasColumnType("nvarchar").HasMaxLength(40);
            Property(x=>x.City).HasColumnType("nvarchar").HasMaxLength(40);
            Property(x=>x.Email).HasColumnType("nvarchar").HasMaxLength(50);

        }
    }
}
