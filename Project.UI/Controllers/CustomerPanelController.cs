using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
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

        public CustomerPanelController()
        {
            _cManager = new CustomerManager();
            _sManager = new SalesMovementManager();
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


    }
}