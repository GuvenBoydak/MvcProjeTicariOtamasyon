using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class InvoiceBody:BaseEntity
    {
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public int? InvoiceID { get; set; }
        public int? ProductID { get; set; }

        //Relational Property
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
