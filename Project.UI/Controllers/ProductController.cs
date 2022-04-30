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
    public class ProductController : Controller
    {
        ProductManager _pManager;
        CategoryManager _cManager;
        public ProductController()
        {
            _pManager = new ProductManager();
            _cManager = new CategoryManager();           
        }

        // GET: Product
        public ActionResult Index()
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pManager.GetActives(),
                
            };
            return View(vM);
        }


        public ActionResult AddProduct()
        {

            ProductVM vM = new ProductVM()
            {
                Categories = _cManager.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _pManager.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Product = _pManager.Find(id),
                Categories = _cManager.GetActives()
            };

            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _pManager.Update(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            _pManager.Delete(_pManager.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pManager.GetActives(),
                Categories=_cManager.GetActives()
            };
            return View(vM);
        }

    }
}