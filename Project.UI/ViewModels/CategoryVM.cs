using Project.ENTITIES.Concrete.Entities;
using Project.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class CategoryVM
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public List<ProductDTO> ProductDTOs { get; set; }
        public ProductDTO ProductDTO { get; set; }
    }
}