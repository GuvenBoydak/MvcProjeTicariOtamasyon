using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.UI.DTOs;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    [Authorize(Roles = "A")]
    public class StatisticsController : Controller
    {
        CustomerRepository _cRepository;
        ProductRepository _pRepository;
        EmployeeRepository _eRepository;
        CategoryRepository _cateRepository;
        SalesMovementRepository _sRepository;

        public StatisticsController()
        {
            _cRepository = new CustomerRepository();
            _pRepository = new ProductRepository();
            _eRepository = new EmployeeRepository();
            _cateRepository = new CategoryRepository();
            _sRepository = new SalesMovementRepository();
        }

        // GET: Statistics
        public ActionResult Index()
        {
            string CustomerCount = _cRepository.Count().ToString();
            ViewBag.CustomerCount = CustomerCount;

            string ProductCount = _pRepository.Count().ToString();
            ViewBag.ProductCount = ProductCount;

            string EmployeeCount = _eRepository.Where(x => x.ID == x.ID).Count().ToString();
            ViewBag.EmployeeCount = EmployeeCount;

            string CategoryCount = _cateRepository.Where(x => x.ID == x.ID).Count().ToString();
            ViewBag.CategoryCount = CategoryCount;

            string TotalStock = _pRepository.Sum(x=>x.Stock).ToString();
            ViewBag.TotalStock = TotalStock;

            string CriticalStock = _pRepository.Where(x => x.Stock<=20).Count().ToString();
            ViewBag.CriticalStock = CriticalStock;

            string BrandCount = _pRepository.GetActives().Select(x => x.Brand).Distinct().Count().ToString();
            ViewBag.BrandCount = BrandCount;

            string MaxPriceProduct = _pRepository.GetActives().OrderByDescending(x => x.SellPrice).FirstOrDefault().Name;
            ViewBag.MaxPriceProduct = MaxPriceProduct;

            string MinPriceProduct = _pRepository.GetActives().OrderBy(x => x.SellPrice).FirstOrDefault().Name;
            ViewBag.MinPriceProduct = MinPriceProduct;

            string BuzdolabiCount = _pRepository.Where(x => x.Name == "Buzdolabı").Count().ToString();
            ViewBag.BuzdolabiCount = BuzdolabiCount;

            string MaxProductOfTheCategory = _cateRepository.GetActives().Where(x => x.ID == (_pRepository.GetActives().GroupBy(y => y.CategoryID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.MaxProductOfTheCategory = MaxProductOfTheCategory;

            string MaxBrand = _pRepository.GetActives().GroupBy(x => x.Brand).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.MaxBrand = MaxBrand;

            string MoneyInTheSafe = _sRepository.GetActives().Sum(x => x.TotalPrice).ToString();
            ViewBag.MoneyInTheSafe = MoneyInTheSafe;

            string SalesToday = _sRepository.GetActives().Where(x => x.CreatedDate == DateTime.Today).Sum(x => (decimal?)x.TotalPrice).ToString();
            ViewBag.SalesToday = SalesToday;

            string MoneyInTheSafeToday = _sRepository.Where(x => x.CreatedDate == DateTime.Today).Sum(x => x.TotalPrice).ToString();
            ViewBag.MoneyInTheSafeToday = MoneyInTheSafeToday;

            string BestSellingProduct =_pRepository.GetActives().Where(x=>x.ID ==(_sRepository.GetActives().GroupBy(y => y.ProductID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(x=>x.Name).FirstOrDefault();
            ViewBag.BastSellingProduct = BestSellingProduct;

            return View();
        }

        public ActionResult SimpleTables()
        {
           
            return View();
        }

        public PartialViewResult CategoryProductPartial()
        {
            CategoryVM vM = new CategoryVM()
            {
                ProductDTOs = _pRepository.GetActives().GroupBy(x => x.Category.CategoryName).Select(x => new ProductDTO { Category = x.Key, Count = x.Count() }).ToList()
            };
            return PartialView(vM);
        }


        public PartialViewResult CustomerCityPartial()
        {
            CustomerVM vM = new CustomerVM()
            {
                CustomerDTOs = _cRepository.GetActives().GroupBy(x => x.City).Select(x => new CustomerDTO { City = x.Key, Count = x.Count() }).ToList()
            };
            return PartialView(vM);
        }


        public PartialViewResult EmployeeDepartmentPartial()
        {
            EmployeeVM vM = new EmployeeVM()
            {
                EmployeeDTOs=_eRepository.GetActives().GroupBy(x=>x.Department.Name).Select(x=> new EmployeeDTO {Department=x.Key,Count=x.Count() }).ToList()
            };
            return PartialView(vM);
        }

        public PartialViewResult ProductBrandPartial()
        {
            ProductVM vM = new ProductVM()
            {
                ProductDTOs = _pRepository.GetActives().GroupBy(x => x.Brand).Select(x => new ProductDTO { Brand = x.Key, Count = x.Count() }).ToList()
            };
            return PartialView(vM);
        }

        public PartialViewResult ProductPartial()
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pRepository.GetActives()
            };
            return PartialView(vM);
        }

        public PartialViewResult CustomerPartial()
        {
            CustomerVM vM = new CustomerVM()
            {
                Customers=_cRepository.GetActives()
            };
            return PartialView(vM);
        }
       
    }
}