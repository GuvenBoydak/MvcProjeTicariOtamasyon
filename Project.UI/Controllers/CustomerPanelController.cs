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
    public class CustomerPanelController : Controller
    {
        CustomerManager _cManager;
        SalesMovementManager _sManager;
        MessageManager _mManager;

        public CustomerPanelController()
        {
            _cManager = new CustomerManager();
            _sManager = new SalesMovementManager();
            _mManager = new MessageManager();
        }
        // GET: CustomerPanel
        [Authorize] //kullanıcı giriş sorguluyoruz. [Authorize] atrribute ile.
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
                Messages = _mManager.GetActives().Where(x=>x.Receiver==email).OrderByDescending(x=>x.ID).ToList()
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
                Messages = _mManager.GetActives().Where(x => x.Sender == email).OrderByDescending(x=>x.ID).ToList()
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
    }
}