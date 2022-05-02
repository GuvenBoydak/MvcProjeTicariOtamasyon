using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        //Relational Property
        public virtual List<SalesMovement> SalesMovements { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}
