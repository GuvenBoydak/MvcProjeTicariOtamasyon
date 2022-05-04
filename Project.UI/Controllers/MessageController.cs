using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
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
            return View();
        }
    }
}