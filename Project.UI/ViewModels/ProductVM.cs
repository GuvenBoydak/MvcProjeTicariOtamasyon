using PagedList;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class ProductVM
    {
        public List<Product> Products { get; set; }
        public IPagedList<Product> ProductsPaged { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductDTO> ProductDTOs { get; set; }
        public ProductDTO ProductDTO { get; set; }
        public List<SalesMovement> SalesMovements { get; set; }
        public SalesMovement SalesMovement { get; set; }
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }

    }
}