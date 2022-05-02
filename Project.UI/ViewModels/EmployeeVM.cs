using Project.ENTITIES.Concrete.Entities;
using Project.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class EmployeeVM
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }
        public Employee Employee { get; set; }
        public List<EmployeeDTO> EmployeeDTOs { get; set; }
        public EmployeeDTO EmployeeDTO { get; set; }
    }
}