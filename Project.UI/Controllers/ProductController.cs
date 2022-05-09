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
    [Authorize(Roles = "A")]
    public class ProductController : Controller
    {
        ProductRepository _pRepository;
        CategoryRepository _cRepository;
        EmployeeRepository _eRepository;
        SalesMovementRepository _sRepository;
        public ProductController()
        {
            _pRepository = new ProductRepository();
            _cRepository = new CategoryRepository();
            _eRepository = new EmployeeRepository();
            _sRepository = new SalesMovementRepository();
        }

        // GET: Product
        public ActionResult Index(int paged = 1)
        {
            ProductVM vM = new ProductVM()
            {
                ProductsPaged = _pRepository.GetActives().ToPagedList(paged, 6),
            };

            return View(vM);
        }


        public ActionResult AddProduct()
        {

            ProductVM vM = new ProductVM()
            {
                Categories = _cRepository.GetActives()
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
            _pRepository.Add(product);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Product = _pRepository.Find(id),
                Categories = _cRepository.GetActives()
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
            _pRepository.Update(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            _pRepository.Delete(_pRepository.Find(id));
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pRepository.GetActives(),
                Categories = _cRepository.GetActives()
            };
            return View(vM);
        }


        public ActionResult SellProduct(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Employees = _eRepository.GetActives()
            };

            int productID= _pRepository.Find(id).ID;
            ViewBag.ProductID =productID;

            return View(vM);
        }

        [HttpPost]
        public ActionResult SellProduct(SalesMovement salesMovement)
        {
            _sRepository.Add(salesMovement);
            return RedirectToAction("Index","SalesMovement");
        }

    }
}