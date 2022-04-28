using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }

        //Relational Property
        public virtual List<Employee> Employees { get; set; }
    }
}
