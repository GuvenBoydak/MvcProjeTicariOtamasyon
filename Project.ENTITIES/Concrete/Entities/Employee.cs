using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Employee:BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int? DepartmentID { get; set; }

        //Relational Property
        public virtual List<SalesMovement> SalesMovements { get; set; }
        public virtual Department Department { get; set; }
    }
}
