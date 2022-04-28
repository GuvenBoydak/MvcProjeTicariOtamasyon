using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Admin:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Authorization { get; set; }

        //Relational Property
    }
}
