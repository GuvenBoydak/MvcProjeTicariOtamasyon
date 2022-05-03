using FluentValidation.Results;
using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.BLL.ValidationRules;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager _eManager;
        DepartmentManager _dManager;
        EmployeeValidator _eValidator;
        public EmployeeController()
        {
            _eManager = new EmployeeManager();
            _dManager = new DepartmentManager();
            _eValidator = new EmployeeValidator();
        }

        // GET: Employee
        public ActionResult Index()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Employees = _eManager.GetActives()
            };
            return View(vM);
        }

        public ActionResult AddEmployee()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Departments = _dManager.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (Request.Files.Count>0)//Reguest=>isteklerim arasında dosya varsa.
            {
                //İstekde tutmuş oldugum 0 indexli dosya ismini al ve degişkene atadık.
                string filesName = Path.GetFileName(Request.Files[0].FileName);
                //istekde tutmuş oldugum 0 indexli doysa ismini aldık uzantı olarak  degişkene atadık.
                string extension = Path.GetExtension(Request.Files[0].FileName);
                //Degişkene "~/Image/" + filesName + extension; kaydedilen degeri atadık.
                string road = "~/Image/" + filesName + extension;
                //İstekde tutuş oldugum 0 indexli degeri road(kaydedilecek yer) e kaydediyoruz.
                Request.Files[0].SaveAs(Server.MapPath(road));
                //Personel görseline veri tabanına kaydelicek degeri atadik.
                employee.Image= "~/Image/" + filesName + extension;
            }
            _eManager.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Employee = _eManager.Find(id),
                Departments = _dManager.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            if (Request.Files.Count > 0)//Reguest=>isteklerim arasında dosya varsa.
            {
                //İstekde tutmuş oldugum 0 indexli dosya ismini al ve degişkene atadık.
                string filesName = Path.GetFileName(Request.Files[0].FileName);
                //istekde tutmuş oldugum 0 indexli doysa ismini aldık uzantı olarak  degişkene atadık.
                string extension = Path.GetExtension(Request.Files[0].FileName);
                //Degişkene "~/Image/" + filesName + extension; kaydedilen degeri atadık.
                string road = "~/Image/" + filesName + extension;
                //İstekde tutuş oldugum 0 indexli degeri road(kaydedilecek yer) e kaydediyoruz.
                Request.Files[0].SaveAs(Server.MapPath(road));
                //Personel görseline veri tabanına kaydelicek degeri atadik.
                employee.Image = "~/Image/" + filesName + extension;
            }
            _eManager.Update(employee);

            return RedirectToAction("Index");
        }

        public ActionResult EmployeeListDetail()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Employees = _eManager.GetActives()
            };
            return View(vM);
        }
    }
}