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
    public class ProductController : Controller
    {
        ProductManager _p;
        CategoryManager _c;
        public ProductController()
        {
            _p = new ProductManager();
            _c = new CategoryManager();
        }

        // GET: Product
        public ActionResult Index()
        {
            ProductVM vM = new ProductVM()
            {
                Products = _p.GetActives(),
                
            };
            return View(vM);
        }


        public ActionResult AddProduct()
        {

            ProductVM vM = new ProductVM()
            {
                Categories = _c.GetActives()
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _p.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Product = _p.Find(id),
                Categories = _c.GetActives()
            };

            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _p.Update(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            _p.Delete(_p.Find(id));
            return RedirectToAction("Index");
        }


    }
}