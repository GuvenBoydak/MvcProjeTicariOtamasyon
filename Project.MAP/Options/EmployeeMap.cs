using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class EmployeeMap:BaseMap<Employee>
    {
        public EmployeeMap()
        {
            HasKey(x=>x.ID);
            Property(x=>x.FirstName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            Property(x=>x.LastName).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            Property(x=>x.Phone).HasColumnType("nvarchar").HasMaxLength(20).IsRequired();
            Property(x=>x.Email).HasColumnType("nvarchar").HasMaxLength(40).IsRequired();
            Property(x=>x.Image).HasColumnType("nvarchar").HasMaxLength(300);


        }
    }
}
