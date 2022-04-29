using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ProductMap:BaseMap<Product>
    {
        public ProductMap()
        {
            HasKey(x=>x.ID);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
            Property(x => x.Brand).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
            Property(x => x.ProductImage).HasColumnType("nvarchar").HasMaxLength(300);
        }
    }
}
