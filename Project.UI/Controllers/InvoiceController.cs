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
    [Authorize(Roles = "A")]
    public class InvoiceController : Controller
    {
        InvoiceRepository _iRepository;
        InvoiceBodyRepository _iBRepository;

        public InvoiceController()
        {
            _iRepository = new InvoiceRepository();
            _iBRepository = new InvoiceBodyRepository();
        }

        // GET: Invoice
        public ActionResult Index()
        {
            InvoiceVM vM = new InvoiceVM()
            {
                Invoices = _iRepository.GetActives(),
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
            _iRepository.Add(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateInvoice(int id)
        {
            InvoiceVM vM = new InvoiceVM()
            {
                Invoice = _iRepository.Find(id)
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            _iRepository.Update(invoice);
            return RedirectToAction("Index");
        }

        public ActionResult DetailsInvoice(int id)
        {
            InvoiceVM vM = new InvoiceVM()
            {
                InvoiceBodies = _iBRepository.Where(x => x.InvoiceID == id).ToList()
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
            _iBRepository.Add(invoiceBody);
            return RedirectToAction("Index");
        }

        public ActionResult DynamicInvoices()
        {
            InvoiceVM vM = new InvoiceVM()
            {
                Invoices = _iRepository.GetActives(),
                InvoiceBodies = _iBRepository.GetActives()
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
            _iRepository.Add(invoice);

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
                _iBRepository.Add(iBody);
            }

            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}