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
    [Authorize(Roles = "A")]
    public class GraphicController : Controller
    {
        CategoryRepository _cRepository;
        ProductRepository _pRepository;
        public GraphicController()
        {
            _cRepository = new CategoryRepository();
            _pRepository = new ProductRepository();
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

            dTOs = _pRepository.GetActives().Select(x => new ProductDTO { Name = x.Name, Stock = x.Stock }).ToList();

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