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
    public class DepartmentController : Controller
    {
        DepartmentRepository _dRepository;
        EmployeeRepository _eRepository;
        SalesMovementRepository _sRepository;
        DepartmentValidator _dValidator;

        public DepartmentController()
        {
            _dRepository = new DepartmentRepository();
            _eRepository = new EmployeeRepository();
            _sRepository = new SalesMovementRepository();
            _dValidator = new DepartmentValidator();
        }

        // GET: Department
        public ActionResult Index()
        {
            DepartmentVM vM = new DepartmentVM()
            {
                Departments = _dRepository.GetActives()
            };
            return View(vM);
        }

        
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department department)
        {
            DepartmentVM model = new DepartmentVM()
            {
                Department = department
            };

            ValidationResult result = _dValidator.Validate(department);
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
                _dRepository.Add(department);
            }
            return RedirectToAction("Index");
        }


        public ActionResult UpdateDepartment(int id)
        {
            DepartmentVM vM = new DepartmentVM()
            {
                Department = _dRepository.Find(id)
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            DepartmentVM model = new DepartmentVM()
            {
                Department = department
            };

            ValidationResult result = _dValidator.Validate(department);
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
                _dRepository.Update(department);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            _dRepository.Delete(_dRepository.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id)
        {
            DepartmentVM vM = new DepartmentVM()
            {
                Employees = _eRepository.Where(x => x.DepartmentID == id).ToList()

            };
            string departmentName = _dRepository.Where(x => x.ID == id).Select(z => z.Name).FirstOrDefault();
            ViewBag.DepartmentName = departmentName;
            return View(vM);
        }
        public ActionResult DepartmentEployeeSales(int id)
        {
            DepartmentVM vM = new DepartmentVM()
            {
                SalesMovements = _sRepository.Where(x => x.EmployeeID == id).ToList()

            };
            string employee = _eRepository.Where(x => x.ID == id).Select(z => z.FirstName + "" + z.LastName).FirstOrDefault();
            ViewBag.Employee = employee;
            return View(vM);
        }
    }
}