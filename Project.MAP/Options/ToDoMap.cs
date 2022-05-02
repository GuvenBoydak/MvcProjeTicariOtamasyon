using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class ToDoMap:BaseMap<ToDo>
    {
        public ToDoMap()
        {
            HasKey(x => x.ID);
            Property(x => x.Heading).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
        }
    }
}
