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
    public class MessageController : Controller
    {
        MessageManager _mManager;
        public MessageController()
        {
            _mManager = new MessageManager();
        }
        // GET: Message
        public ActionResult Index()
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.GetActives().Where(x => x.Receiver == "destek@gmail.com").ToList()
            };

            int senderMessageCount = _mManager.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mManager.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }

        public ActionResult SendMessage()
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.GetActives().Where(x => x.Sender.Contains("admin")).OrderByDescending(x=>x.ID).ToList()
            };
            int senderMessageCount = _mManager.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mManager.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }

        public ActionResult IncomingMessage()
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.GetActives().Where(x => x.Receiver == "destek@gmail.com").OrderByDescending(x => x.ID).ToList()
            };
            int senderMessageCount = _mManager.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mManager.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }


        public ActionResult NewMessage()
        {

            int senderMessageCount = _mManager.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mManager.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string admin = (string)Session["AdminLogin"];

            message.Sender = admin;
            _mManager.Add(message);
            int senderMessageCount = _mManager.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mManager.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return RedirectToAction("SendMessage");
        }

        public ActionResult DetailMessage(int id)
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mManager.GetActives().Where(x => x.ID == id).ToList()
            };
            int senderMessageCount = _mManager.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mManager.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }


    }
}