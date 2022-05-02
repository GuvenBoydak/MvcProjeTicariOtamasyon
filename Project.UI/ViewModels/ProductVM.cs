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
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductDTO> ProductDTOs { get; set; }
        public ProductDTO ProductDTO { get; set; }

    }
}