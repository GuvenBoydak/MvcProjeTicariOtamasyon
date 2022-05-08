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
    public class ProductDetailController : Controller
    {
        ProductManager _pManager;
        public ProductDetailController()
        {
            _pManager = new ProductManager();
        }

        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pManager.GetActives().Where(x=>x.ID==id).ToList()
            };
            return View(vM);
        }
    }
}