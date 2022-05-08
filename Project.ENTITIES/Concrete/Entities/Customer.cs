using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Customer:BaseEntity
    {
        string  authorization;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Authorization
        {
            get
            {
                return authorization;
            }
            set
            {
                if (value != "C")
                {
                    value = "C";
                }
                authorization = value;
            }
        }

        public Customer()
        {
            Authorization = "C";
        }

        //Relational Property
        public virtual List<SalesMovement> SalesMovements { get; set; }

    }
}
