using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class GraphicController : Controller
    {
        CategoryManager _cManager;
        ProductManager _pManager;
        public GraphicController()
        {
            _cManager = new CategoryManager();
            _pManager = new ProductManager();
        }
        // GET: Graphic
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }

        public List<ProductDTO> ProductList()
        {
            List<ProductDTO> dTOs = new List<ProductDTO>();

            dTOs = _pManager.GetActives().Select(x => new ProductDTO { Name = x.Name, Stock = x.Stock }).ToList();

            return dTOs;
        }

        public ActionResult LineGraphic()
        {
            return View();
        }

        public ActionResult ColumnGraphic()
        {
            return View();
        }
    }
}