using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public short Stock { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }

    }
}