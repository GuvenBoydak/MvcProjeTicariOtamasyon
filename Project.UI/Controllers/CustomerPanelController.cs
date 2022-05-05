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
        CustomerManager _cManager;
        SalesMovementManager _sManager;
        MessageManager _mManager;
        ShippingDetailManager _sDManager;
        ShippingTrackingManager _stManager;

        public CustomerPanelController()
        {
            _cManager = new CustomerManager();
            _sManager = new SalesMovementManager();
            _mManager = new MessageManager();
            _sDManager = new ShippingDetailManager();
            _stManager = new  ShippingTrackingManager();
        }
        // GET: CustomerPanel
        public ActionResult Index()
        {
            string email = (string)Session["Login"];
            CustomerVM vM = new CustomerVM()
            {
                Customer = _cManager.GetActives().FirstOrDefault(x => x.Email == email)
            };
            ViewBag.Email = email;
            return View(vM);
        }

        public ActionResult MyOrders()
        {
            string email = (string)Session["Login"];
            int ID = _cManager.Where(x => x.Email == email).Select(x => x.ID).FirstOrDefault();

            CustomerVM vM = new CustomerVM()
            {
                SalesMovements = _sManager.Where(x => x.ID == ID).ToList()
            };

            return View(vM);
        }

        public PartialViewResult MessageMenu()
        {
            string email = (string)Session["Login"];

            int incomingMessage = _mManager.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mManager.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;

            return PartialView();
        }



        public ActionResult IncomingMessages()
        {
            string email = (string)Session["Login"];
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.GetActives().Where(x => x.Receiver == email).OrderByDescending(x => x.ID).ToList()
            };

            int incomingMessage = _mManager.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mManager.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;
            return View(vM);
        }

        public ActionResult SendMessages()
        {
            string email = (string)Session["Login"];
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.GetActives().Where(x => x.Sender == email).OrderByDescending(x => x.ID).ToList()
            };
            int incomingMessage = _mManager.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mManager.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;
            return View(vM);
        }

        public ActionResult DetailMessage(int id)
        {
            string email = (string)Session["Login"];
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.Where(x => x.ID == id).ToList()
            };

            int incomingMessage = _mManager.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mManager.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;
            return View(vM);
        }


        public ActionResult NewMessage()
        {
            string email = (string)Session["Login"];

            int incomingMessage = _mManager.GetActives().Count(x => x.Receiver == email);
            ViewBag.IncomingMessage = incomingMessage;

            int sendMessage = _mManager.GetActives().Count(x => x.Sender == email);
            ViewBag.SendMessage = sendMessage;

            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string email = (string)Session["Login"];
            message.Sender = email;
            _mManager.Add(message);
            return RedirectToAction("");
        }

        public ActionResult ShippingTracking()
        {
            //Refactor Edilecek!!!!
            string email = (string)Session["Login"];
            string a = _cManager.GetActives().Where(x => x.Email == email).Select(x => x.FirstName).FirstOrDefault();
            string b = _cManager.GetActives().Where(x => x.Email == email).Select(x => x.LastName).FirstOrDefault();
            string c = a + " " + b;

            CustomerVM vM = new CustomerVM()
            {
                ShippingDetails = _sDManager.GetActives().Where(x => x.Receiver == c).ToList(),

            };
            return View(vM);
        }


        public ActionResult ShippingDetail(string id)
        {
            CustomerVM vM = new CustomerVM()
            {
                ShippingTrackings = _stManager.GetActives().Where(x=>x.TrackingCode==id).ToList()
            };
            return View(vM);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); //Kullanıcı bileti tarayıcıdan kaldırılır Oturum sonlandırma.
            Session.Abandon(); //Oturumu var olan Sessionu temizler.
            return RedirectToAction("Index","Login");
        }

    }
}