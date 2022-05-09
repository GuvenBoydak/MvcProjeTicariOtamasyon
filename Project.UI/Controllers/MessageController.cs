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
    public class MessageController : Controller
    {
        MessageRepository _mRepository;
        public MessageController()
        {
            _mRepository = new MessageRepository();
        }
        // GET: Message
        public ActionResult Index()
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.Receiver == "destek@gmail.com").ToList()
            };

            int senderMessageCount = _mRepository.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mRepository.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }

        public ActionResult SendMessage()
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.Sender.Contains("admin")).OrderByDescending(x=>x.ID).ToList()
            };
            int senderMessageCount = _mRepository.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mRepository.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }

        public ActionResult IncomingMessage()
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.Receiver == "destek@gmail.com").OrderByDescending(x => x.ID).ToList()
            };
            int senderMessageCount = _mRepository.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mRepository.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }


        public ActionResult NewMessage()
        {

            int senderMessageCount = _mRepository.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mRepository.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string admin = (string)Session["AdminLogin"];

            message.Sender = admin;
            _mRepository.Add(message);
            int senderMessageCount = _mRepository.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mRepository.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return RedirectToAction("SendMessage");
        }

        public ActionResult DetailMessage(int id)
        {
            MessageVM vM = new MessageVM()
            {
                Messages = _mRepository.GetActives().Where(x => x.ID == id).ToList()
            };
            int senderMessageCount = _mRepository.GetActives().Count(x => x.Sender.Contains("admin"));
            ViewBag.SenderMessageCount = senderMessageCount;

            int receiverMessageCount = _mRepository.GetActives().Count(x => x.Receiver == "destek@gmail.com");
            ViewBag.ReceiverMessageCount = receiverMessageCount;
            return View(vM);
        }


    }
}