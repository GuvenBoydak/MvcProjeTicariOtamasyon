using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Concrete.Entities
{
    public class Invoice:BaseEntity
    {
        public string SerialNo { get; set; } //Seri No
        public string InvoiceNumber { get; set; } //sıra No
        public string TaxAuthorityNumber { get; set; } //Vergi Dairesi
        public string Time { get; set; }
        public string Submitter { get; set; } //Gönderen
        public string Receiver { get; set; } //alan
        public decimal TotalPrice { get; set; }

        //Relational Property
        public virtual List<InvoiceBody> InvoiceBodies { get; set; }
    }
}
