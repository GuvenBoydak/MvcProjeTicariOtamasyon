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
    public class SalesMovementController : Controller
    {
        SalesMovementManager _sManager;
        CustomerManager _cManager;
        EmployeeManager _eManager;
        ProductManager _pManager;
        public SalesMovementController()
        {
            _sManager = new SalesMovementManager();
            _eManager = new EmployeeManager();
            _cManager = new CustomerManager();
            _pManager = new ProductManager();
        }
        // GET: SalesMovement
        public ActionResult Index()
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                SalesMovements = _sManager.GetActives(),
                Products=_pManager.GetActives()
            };
            return View(vM);
        }

        public ActionResult AddSalesMovement()
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                Customers=_cManager.GetActives(),
                Employees=_eManager.GetActives(),
                Products=_pManager.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddSalesMovement(SalesMovement salesMovement)
        {
            _sManager.Add(salesMovement);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSalesMovement(int id)
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                SalesMovement = _sManager.Find(id),
                Customers = _cManager.GetActives(),
                Employees = _eManager.GetActives(),
                Products = _pManager.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateSalesMovement(SalesMovement salesMovement)
        {
            _sManager.Update(salesMovement);
            return RedirectToAction("Index");
        }

        public ActionResult DetailSalesMovement(int id)
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                SalesMovements = _sManager.Where(x => x.ID == id).ToList()
            };
            return View(vM);
        }

    }
}