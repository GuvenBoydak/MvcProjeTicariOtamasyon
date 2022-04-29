using FluentValidation.Results;
using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.BLL.ValidationRules;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _cManaeger;
        SalesMovementManager _sManager;
        EmployeeManager _eManager;

        CustomerValidator _cValidator;
        public CustomerController()
        {
            _cManaeger = new CustomerManager();
            _cValidator = new CustomerValidator();
            _sManager = new SalesMovementManager();
            _eManager = new EmployeeManager();
        }

        // GET: Customer
        public ActionResult Index()
        {
            CustomerVM vM = new CustomerVM()
            {
                Customers = _cManaeger.GetActives()
            };
            return View(vM);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            CustomerVM model = new CustomerVM()
            {
                Customer = customer
            };

            ValidationResult result = _cValidator.Validate(customer);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                _cManaeger.Add(customer);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            CustomerVM vM = new CustomerVM()
            {
                Customer = _cManaeger.Find(id)
            };

            return View(vM);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            CustomerVM model=new CustomerVM()
            {
                Customer = customer
            };

            ValidationResult result = _cValidator.Validate(customer);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                _cManaeger.Update(customer);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            _cManaeger.Delete(_cManaeger.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSales(int id)
        {
            CustomerVM vM = new CustomerVM()
            {
                SalesMovements = _sManager.Where(x => x.Customer.ID == id).ToList(),
                Employees = _eManager.GetActives()
            };
            string customer = _cManaeger.Where(x => x.ID == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
            ViewBag.Customer = customer;
            return View(vM);
        }



    }
}