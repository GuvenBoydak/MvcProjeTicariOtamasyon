using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class ToDo :BaseEntity
    {
        public string Heading { get; set; }
        public bool State { get; set; }

    }
}
