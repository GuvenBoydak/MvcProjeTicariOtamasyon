using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.DTOs;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.UI.Controllers
{
    [Authorize] //kullanıcı giriş sorguluyoruz. [Authorize] atrribute ile.
    public class CustomerPanelController : Controller
    {
        CustomerRepository _cRepository;
        SalesMovementRepository _sRepository;
        MessageRepository _mRepository;
        ShippingDetailRepository _sDRepository;
        ShippingTrackingRepository _stRepository;

        public CustomerPanelController()
        {
            _cRepository = new CustomerRepository();
            _sRepository = new SalesMovementRepository();
            _mRepository = new MessageRepository();
            _sDRepository = new ShippingDetailRepository();
            _stRepository = new  ShippingTrackingRepository();
        }

        [Authorize(Roles ="C")]
        public ActionResult Index()
        {
            string email = (string)Session["Login"];
            ViewBag.Email = email;
            CustomerVM vM = new CustomerVM()
            {
                Customers = _cRepository.GetActives().Where(x => x.Email == email).ToList(),
                Messages=_mRepository.GetActives().Where(x=>x.Receiver==email).ToList()              
            };
            int mailId = _cRepository.GetActives().Where(x => x.Email == email).Select(x => x.ID).FirstOrDefault();

            int totalSales = _sRepository.GetActives().Where(x => x.CustomerID == mailId).Count();
            ViewBag.TotalSales = totalSales;

            decimal totalAmount = _sRepository.GetActives().Where(x => x.CustomerID == mailId).Sum(x => x.TotalPrice);
            ViewBag.TotalAmount = totalAmount;

            int totalOrderQuantity = _sRepository.GetActives().Where(x => x.CustomerID == mailId).Sum(x => x.Quantity);
            ViewBag.TotalOrderQuantity = totalOrderQuantity;

            string nameSurname = _cRepository.GetActives().Where(x => x.Email == email).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
            ViewBag.NameSurname = nameSurname;
            return View(vM);
        }
        [Authorize(Roles = "C")]
        public ActionResult MyOrders()
        {
            string email = (string)Session["Login"];
            int ID = _cRepository.Where(x => x.Email == email).Select(x => x.ID).FirstOrDefault();

            CustomerVM vM = new CustomerVM()
            {
                SalesMovements = _sRepository.Where(x => x.ID == ID).ToList()
            };

            return View(vM);
        }
        [Authorize(Roles = "C")]
        public PartialViewResult MessageMenu()
        {
            string email = (string)Session["Login"];

            int incomingMessage = _mRepository.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mRepository.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;

            return PartialView();
        }


        [Authorize(Roles = "C")]
        public ActionResult IncomingMessages()
        {
            string email = (string)Session["Login"];
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.Receiver == email).OrderByDescending(x => x.ID).ToList()
            };

            int incomingMessage = _mRepository.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mRepository.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;
            return View(vM);
        }
        [Authorize(Roles = "C")]
        public ActionResult SendMessages()
        {
            string email = (string)Session["Login"];
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.Sender == email).OrderByDescending(x => x.ID).ToList()
            };
            int incomingMessage = _mRepository.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mRepository.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;
            return View(vM);
        }
        [Authorize(Roles = "C")]
        public ActionResult DetailMessage(int id)
        {
            string email = (string)Session["Login"];
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.Where(x => x.ID == id).ToList()
            };

            int incomingMessage = _mRepository.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mRepository.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;
            return View(vM);
        }

        [Authorize(Roles = "C")]
        public ActionResult NewMessage()
        {
            string email = (string)Session["Login"];

            int incomingMessage = _mRepository.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mRepository.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;

            return View();
        }

        [Authorize(Roles = "C")]
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string email = (string)Session["Login"];
            message.Sender = email;
            _mRepository.Add(message);
            return RedirectToAction("");
        }

        [Authorize(Roles = "C")]
        public ActionResult ShippingTracking(string id)
        {
            CustomerVM vM = new CustomerVM();
            if (id!=null)
            {
                vM.ShippingTrackings = _stRepository.GetActives().Where(x => x.TrackingCode.Contains(id)).ToList();
                return View(vM);
            }
            else
            {
                return View(vM);
            }
            
        }

        [Authorize(Roles = "C")]
        public ActionResult ShippingDetail()
        {
            //Refactor Edilecek!!!!
            string email = (string)Session["Login"];
            string d = _cRepository.GetActives().Where(x => x.Email == email).Select(x => x.FirstName).FirstOrDefault();
            string b = _cRepository.GetActives().Where(x => x.Email == email).Select(x => x.LastName).FirstOrDefault();
            string c = d + " " + b;

            CustomerVM vM = new CustomerVM();
            vM.ShippingDetails = _sDRepository.GetActives().Where(x => x.Receiver.Contains(c)).ToList();

            return View(vM);
        }

        [Authorize(Roles = "C")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); //Kullanıcı bileti tarayıcıdan kaldırılır Oturum sonlandırma.
            Session.Abandon(); //Oturumu var olan Sessionu temizler.
            return RedirectToAction("Index","Login");
        }

        [Authorize(Roles = "C")]
        public PartialViewResult Settings()
        {
            string email = (string)Session["Login"];
            int customerID = _cRepository.GetActives().Where(x => x.Email == email).Select(x => x.ID).FirstOrDefault();
            CustomerVM vM = new CustomerVM()
            {
                Customer = _cRepository.Find(customerID)
            };
            return PartialView(vM);
        }

        [Authorize(Roles = "C")]
        public PartialViewResult Announcements()
        {
            string email = (string)Session["Login"];

            CustomerVM vM = new CustomerVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.Sender.Contains("admin")).OrderByDescending(x=>x.ID).ToList()
            };
            return PartialView(vM);
        }

        [Authorize(Roles = "C")]
        public ActionResult UpdateCustomerPanel(Customer customer)
        {
            _cRepository.Update(customer);
            return RedirectToAction("Index");
        }



    }
}