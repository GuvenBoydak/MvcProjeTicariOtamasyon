using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class SalesMovementVM
    {
        public List<SalesMovement> SalesMovements { get; set; }
        public SalesMovement SalesMovement { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public List<Employee> Employees { get; set; }

    }
}