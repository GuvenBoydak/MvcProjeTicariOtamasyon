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
    public class GalleryController : Controller
    {
        ProductManager _pManager;
        public GalleryController()
        {
            _pManager = new ProductManager();
        }
        // GET: Gallery
        public ActionResult Index()
        {
            GalleryVM vM = new GalleryVM()
            {
                Products = _pManager.GetActives()
            };
            return View(vM);
        }
    }
}