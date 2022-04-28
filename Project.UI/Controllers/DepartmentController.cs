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
    public class DepartmentController : Controller
    {
        DepartmentManager _dm;
        EmployeeManager _em;
        SalesMovementManager _sm;

        public DepartmentController()
        {
            _dm = new DepartmentManager();
            _em = new EmployeeManager();
            _sm = new SalesMovementManager();
        }

        // GET: Department
        public ActionResult Index()
        {
            DepartmentVM vM = new DepartmentVM()
            {
                Departments = _dm.GetActives()
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
            _dm.Add(department);
            return RedirectToAction("Index");
        }


        public ActionResult UpdateDepartment(int id)
        {
            DepartmentVM vM = new DepartmentVM()
            {
                Department = _dm.Find(id)
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            _dm.Update(department);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            _dm.Delete(_dm.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id)
        {
            DepartmentVM vM = new DepartmentVM()
            {
                Employees = _em.Where(x => x.DepartmentID == id).ToList()
                
            };
            string departmentName = _dm.Where(x => x.ID == id).Select(z => z.Name).FirstOrDefault();
            ViewBag.DepartmentName = departmentName;
            return View(vM);
        }
        public ActionResult DepartmentEployeeSales(int id)
        {
            DepartmentVM vM = new DepartmentVM()
            {
                SalesMovements = _sm.Where(x => x.EmployeeID == id).ToList()
            };
            string employee = _em.Where(x => x.ID == id).Select(z => z.FirstName).FirstOrDefault();
            ViewBag.Employee = employee;
            return View(vM);
        }
    }
}