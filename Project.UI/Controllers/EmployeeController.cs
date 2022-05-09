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
    [Authorize(Roles = "A")]
    public class EmployeeController : Controller
    {
        EmployeeRepository _eRepository;
        DepartmentRepository _dRepository;
        EmployeeValidator _eValidator;
        public EmployeeController()
        {
            _eRepository = new EmployeeRepository();
            _dRepository = new DepartmentRepository();
            _eValidator = new EmployeeValidator();
        }

        // GET: Employee
        public ActionResult Index()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Employees = _eRepository.GetActives()
            };
            return View(vM);
        }

        public ActionResult AddEmployee()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Departments = _dRepository.GetActives()
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
                string road = "/Imagee/" + filesName + extension;
                //İstekde tutuş oldugum 0 indexli degeri road(kaydedilecek yer) e kaydediyoruz.
                Request.Files[0].SaveAs(Server.MapPath(road));
                //Personel görseline veri tabanına kaydelicek degeri atadik.
                employee.Image= "/Imagee/" + filesName + extension;
            }
            _eRepository.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Employee = _eRepository.Find(id),
                Departments = _dRepository.GetActives()
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
                string road = "/Imagee/" + filesName + extension;
                //İstekde tutuş oldugum 0 indexli degeri road(kaydedilecek yer) e kaydediyoruz.
                Request.Files[0].SaveAs(Server.MapPath(road));
                //Personel görseline veri tabanına kaydelicek degeri atadik.
                employee.Image = "/Imagee/" + filesName + extension;
            }
            _eRepository.Update(employee);

            return RedirectToAction("Index");
        }

        public ActionResult EmployeeListDetail()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                Employees = _eRepository.GetActives()
            };
            return View(vM);
        }
    }
}