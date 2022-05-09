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
        ToDoRepository _tRepository;
        CustomerRepository _cRepository;
        ProductRepository _pRepository;
        CategoryRepository _cateRepository;
        SalesMovementRepository _sRepository;

        public TodoController()
        {
            _tRepository = new ToDoRepository();
            _cRepository = new CustomerRepository();
            _pRepository = new ProductRepository();
            _cateRepository = new CategoryRepository();
            _sRepository = new SalesMovementRepository();
        }
         
        // GET: Todo
        public ActionResult Index()
        {
            string CustomerCount = _cRepository.Count().ToString();
            ViewBag.CustomerCount = CustomerCount;

            string ProductCount = _pRepository.Count().ToString();
            ViewBag.ProductCount = ProductCount;

            string CategoryCount = _cateRepository.Count().ToString();
            ViewBag.CategoryCount = CategoryCount;

            string BestSellerProduct = _sRepository.GetActives().GroupBy(x => x.Product.Name).OrderByDescending(y => y.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.BestSellerProduct = BestSellerProduct;

            ToDoVM vM = new ToDoVM()
            {
                ToDos = _tRepository.GetActives()
            };
            return View(vM);
        }
    }
}