using Project.ENTITIES.Concrete.Entities;
using Project.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class CustomerVM
    {
        public List<Customer> Customers { get; set; }
        public List<SalesMovement> SalesMovements { get; set; }
        public List<Employee> Employees { get; set; }
        public Customer Customer { get; set; }
        public int ID { get; set; }
        public List<CustomerDTO> CustomerDTOs { get; set; }
        public CustomerDTO CustomerDTO { get; set; }
        public List<ShippingDetail> ShippingDetails { get; set; }
        public List<ShippingTracking> ShippingTrackings { get; set; }

    }
}