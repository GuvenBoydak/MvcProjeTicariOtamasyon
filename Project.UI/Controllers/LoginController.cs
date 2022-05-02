using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.ENTITIES.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.UI.Controllers
{
    public class LoginController : Controller
    {
        CustomerManager _cManager;
        AdminManager _aManager;

        public LoginController()
        {
            _cManager = new CustomerManager();
            _aManager = new AdminManager();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult RegisterPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult RegisterPartial(Customer customer)
        {
            _cManager.Add(customer);
            return PartialView();
        }

        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            Customer login = _cManager.Where(x => x.Email == customer.Email && x.Password == customer.Password).FirstOrDefault();

            if (login!=null)
            {              
                FormsAuthentication.SetAuthCookie(login.Email,false);
                Session["Login"] = login.Email.ToString();

                return RedirectToAction("Index","CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Admin info = _aManager.GetActives().FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                Session["AdminLogin"] = info.UserName.ToString();

                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
           

            
        }

    }
}