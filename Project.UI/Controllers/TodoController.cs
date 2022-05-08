using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    [Authorize(Roles = "A")]
    public class TodoController : Controller
    {
        ToDoManager _tManager;
        CustomerManager _cManager;
        ProductManager _pManager;
        CategoryManager _cateManager;
        SalesMovementManager _sManager;

        public TodoController()
        {
            _tManager = new ToDoManager();
            _cManager = new CustomerManager();
            _pManager = new ProductManager();
            _cateManager = new CategoryManager();
            _sManager = new SalesMovementManager();
        }
         
        // GET: Todo
        public ActionResult Index()
        {
            string CustomerCount = _cManager.Count().ToString();
            ViewBag.CustomerCount = CustomerCount;

            string ProductCount = _pManager.Count().ToString();
            ViewBag.ProductCount = ProductCount;

            string CategoryCount = _cateManager.Count().ToString();
            ViewBag.CategoryCount = CategoryCount;

            string BestSellerProduct = _sManager.GetActives().GroupBy(x => x.Product.Name).OrderByDescending(y => y.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.BestSellerProduct = BestSellerProduct;

            ToDoVM vM = new ToDoVM()
            {
                ToDos = _tManager.GetActives()
            };
            return View(vM);
        }
    }
}