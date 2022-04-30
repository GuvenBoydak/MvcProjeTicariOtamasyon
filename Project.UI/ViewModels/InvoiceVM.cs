using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.UI.ViewModels
{
    public class InvoiceVM
    {
        public List<Invoice> Invoices { get; set; }
        public List<InvoiceBody> InvoiceBodies { get; set; }
        public Invoice Invoice { get; set; }
        public InvoiceBody InvoiceBody { get; set; }
    }
}