using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class DepartmentMap:BaseMap<Department>
    {
        public DepartmentMap()
        {
            HasKey(x=>x.ID);
            Property(x=>x.Name).HasColumnType("nvarchar").HasMaxLength(40);
        }
    }
}
