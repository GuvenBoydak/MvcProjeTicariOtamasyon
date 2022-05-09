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
    [Authorize(Roles = "A")]
    public class SalesMovementController : Controller
    {
        SalesMovementRepository _sRepository;
        CustomerRepository _cRepository;
        EmployeeRepository _eRepository;
        ProductRepository _pRepository;
        public SalesMovementController()
        {
            _sRepository = new SalesMovementRepository();
            _eRepository = new EmployeeRepository();
            _cRepository = new CustomerRepository();
            _pRepository = new ProductRepository();
        }
        // GET: SalesMovement
        public ActionResult Index()
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                SalesMovements = _sRepository.GetActives(),
                Products= _pRepository.GetActives(),
                Customers=_cRepository.GetActives()
               
            };
            return View(vM);
        }

        public ActionResult AddSalesMovement()
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                Customers=_cRepository.GetActives(),
                Employees=_eRepository.GetActives(),
                Products= _pRepository.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddSalesMovement(SalesMovement salesMovement)
        {
            _sRepository.Add(salesMovement);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSalesMovement(int id)
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                SalesMovement = _sRepository.Find(id),
                Customers = _cRepository.GetActives(),
                Employees = _eRepository.GetActives(),
                Products = _pRepository.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateSalesMovement(SalesMovement salesMovement)
        {
            _sRepository.Update(salesMovement);
            return RedirectToAction("Index");
        }

        public ActionResult DetailSalesMovement(int id)
        {
            SalesMovementVM vM = new SalesMovementVM()
            {
                SalesMovements = _sRepository.Where(x => x.ID == id).ToList()
            };
            return View(vM);
        }

    }
}