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
            Property(x=>x.FirstName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            Property(x=>x.LastName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            Property(x=>x.City).HasColumnType("nvarchar").HasMaxLength(25).IsRequired();
            Property(x=>x.Email).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();

        }
    }
}
