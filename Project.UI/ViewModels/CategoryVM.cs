using Project.ENTITIES.Concrete.Entities;
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
    }
}