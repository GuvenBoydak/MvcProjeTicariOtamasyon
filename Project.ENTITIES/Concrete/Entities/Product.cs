using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }

        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal SellPrice { get; set; }
        public string ProductImage { get; set; }

        public int? CategoryID { get; set; }

        //Relational Property
        public virtual Category Category { get; set; }
        public virtual List<SalesMovement> SalesMovements { get; set; }
        public virtual List<InvoiceBody> InvoiceBodies { get; set; }

    }
}
