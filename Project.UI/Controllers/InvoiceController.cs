using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class InvoiceController : Controller
    {
        InvoiceManager _iManager;
        InvoiceBodyManager _iBManager;

        public InvoiceController()
        {
            _iManager = new InvoiceManager();
            _iBManager = new InvoiceBodyManager();
        }

        // GET: Invoice
        public ActionResult Index()
        {
            InvoiceVM vM = new InvoiceVM()
            {
                Invoices = _iManager.GetActives(),
            };
            return View(vM);
        }

        public ActionResult AddInvoice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoice(Invoice invoice)
        {
            _iManager.Add(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateInvoice(int id)
        {
            InvoiceVM vM = new InvoiceVM()
            {
                Invoice = _iManager.Find(id)
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            _iManager.Update(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult DetailsInvoice(int id)
        {
            InvoiceVM vM = new InvoiceVM()
            {
                InvoiceBodies = _iBManager.Where(x => x.InvoiceID == id).ToList()
            };
            return View(vM);
        }

        public ActionResult AddInvoiceBody()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInvoiceBody(InvoiceBody invoiceBody)
        {
            _iBManager.Add(invoiceBody);
            return RedirectToAction("Index");
        }

        public ActionResult DynamicInvoices()
        {
            InvoiceVM vM = new InvoiceVM()
            {
                Invoices = _iManager.GetActives(),
                InvoiceBodies = _iBManager.GetActives()
            };
            return View(vM);
        }


        public ActionResult SaveInvoice(string serialNo,string invoiceNumber,string taxAuthorityNumber,string time,string submitter,string receiver,decimal totalPrice,DateTime createdDate, InvoiceBody[] invoiceBodies)
        {

            Invoice invoice = new Invoice()
            {
                SerialNo = serialNo,
                InvoiceNumber = invoiceNumber,
                TaxAuthorityNumber = taxAuthorityNumber,
                Time = time,
                Submitter = submitter,
                Receiver = receiver,
                TotalPrice = totalPrice,
                CreatedDate = createdDate
            };
            _iManager.Add(invoice);

            foreach (InvoiceBody item in invoiceBodies)
            {
                InvoiceBody iBody = new InvoiceBody();
                iBody.Description = item.Description;
                iBody.InvoiceID = invoice.ID;
                iBody.CreatedDate = item.CreatedDate;
                iBody.Quantity = item.Quantity;
                iBody.UnitPrice = item.UnitPrice;
                iBody.TotalPrice = item.TotalPrice;
                iBody.Status = item.Status;
                _iBManager.Add(iBody);
            }

            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}