using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class EmployeeVM
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}