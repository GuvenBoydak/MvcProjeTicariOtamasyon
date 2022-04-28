using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class DepartmentVM
    {
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }
        public List<Employee> Employees { get; set; }
        public List<SalesMovement> SalesMovements { get; set; }

    }
}