using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AdminMap:BaseMap<Admin>
    {
        public AdminMap()
        {
            HasKey(x => x.ID);
            Property(x => x.UserName).HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.Password).HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.Authorization).HasColumnType("nvarchar").HasMaxLength(1);
        }
    }
}
