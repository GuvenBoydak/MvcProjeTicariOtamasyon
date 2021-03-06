using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        CustomerRepository _cRepository;
        AdminRepository _aRepository;
        ProductRepository _pRepository;

        public LoginController()
        {
            _cRepository = new CustomerRepository();
            _aRepository = new AdminRepository();
            _pRepository = new ProductRepository();
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
            _cRepository.Add(customer);
            return PartialView();
        }

        public ActionResult CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            Customer login = _cRepository.Where(x => x.Email == customer.Email && x.Password == customer.Password).FirstOrDefault();

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
            Admin info = _aRepository.GetActives().FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

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

        public ActionResult ProductGallery()
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pRepository.GetActives()
            };
            return View(vM);
        }

    }
}