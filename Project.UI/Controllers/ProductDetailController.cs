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
        ProductRepository _pRepository;
        public ProductDetailController()
        {
            _pRepository = new ProductRepository();
        }

        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            ProductVM vM = new ProductVM()
            {
                Products = _pRepository.GetActives().Where(x=>x.ID==id).ToList()
            };
            return View(vM);
        }
    }
}