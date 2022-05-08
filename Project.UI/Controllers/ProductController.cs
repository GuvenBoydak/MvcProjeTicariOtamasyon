using PagedList;
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
    public class ProductController : Controller
    {
        ProductManager _pManager;
        CategoryManager _cManager;
        EmployeeManager _eManager;
        SalesMovementManager _sManager;
        public ProductController()
        {
            _pManager = new ProductManager();
            _cManager = new CategoryManager();
            _eManager = new EmployeeManager();
            _sManager = new SalesMovementManager();
        }

        // GET: Product
        public ActionResult Index(int paged = 1)
        {
            ProductVM vM = new ProductVM()
            {
                ProductsPaged = _pManager.GetActives().ToPagedList(paged, 6),
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
            if (Request.Files.Count > 0)//Reguest=>isteklerim arasında dosya varsa.
            {
                //İstekde tutmuş oldugum 0 indexli dosya ismini al ve degişkene atadık.
                string filesName = Path.GetFileName(Request.Files[0].FileName);
                //Degişkene "~/Image/" + filesName + extension; kaydedilen degeri atadık.
                string road = "/Imagee/" + filesName;
                //İstekde tutuş oldugum 0 indexli degeri road(kaydedilecek yer) e kaydediyoruz.
                Request.Files[0].SaveAs(Server.MapPath(road));
                //Personel görseline veri tabanına kaydelicek degeri atadik.
                product.ProductImage = "/Imagee/" + filesName;
            }
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
            if (Request.Files.Count > 0)//Reguest=>isteklerim arasında dosya varsa.
            {
                //İstekde tutmuş oldugum 0 indexli dosya ismini al ve degişkene atadık.
                string filesName = Path.GetFileName(Request.Files[0].FileName);
                //Degişkene "~/Image/" + filesName + extension; kaydedilen degeri atadık.
                string road = "/Imagee/" + filesName;
                //İstekde tutuş oldugum 0 indexli degeri road(kaydedilecek yer) e kaydediyoruz.
                Request.Files[0].SaveAs(Server.MapPath(road));
                //Personel görseline veri tabanına kaydelicek degeri atadik.
                product.ProductImage = "/Imagee/" + filesName;
            }
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
                Categories = _cManager.GetActives()
            };
            return View(vM);
        }


        public ActionResult SellProduct(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Employees = _eManager.GetActives()
            };

            int productID= _pManager.Find(id).ID;
            ViewBag.ProductID =productID;

            return View(vM);
        }

        [HttpPost]
        public ActionResult SellProduct(SalesMovement salesMovement)
        {
            _sManager.Add(salesMovement);
            return RedirectToAction("Index","SalesMovement");
        }

    }
}