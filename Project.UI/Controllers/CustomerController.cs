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
    [Authorize(Roles = "A")]
    public class CustomerController : Controller
    {
        CustomerRepository _cRepository;
        SalesMovementRepository _sRepository;
        EmployeeRepository _eRepository;

        CustomerValidator _cValidator;
        public CustomerController()
        {
            _cRepository = new CustomerRepository();
            _cValidator = new CustomerValidator();
            _sRepository = new SalesMovementRepository();
            _eRepository = new EmployeeRepository();
        }

        // GET: Customer
        public ActionResult Index()
        {
            CustomerVM vM = new CustomerVM()
            {
                Customers = _cRepository.GetActives()
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
                _cRepository.Add(customer);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCustomer(int id)
        {
            CustomerVM vM = new CustomerVM()
            {
                Customer = _cRepository.Find(id)
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
                _cRepository.Update(customer);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            _cRepository.Delete(_cRepository.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSales(int id)
        {
            CustomerVM vM = new CustomerVM()
            {
                SalesMovements = _sRepository.Where(x => x.Customer.ID == id).ToList(),
                Employees = _eRepository.GetActives()
            };
            string customer = _cRepository.Where(x => x.ID == id).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
            ViewBag.Customer = customer;
            return View(vM);
        }



    }
}