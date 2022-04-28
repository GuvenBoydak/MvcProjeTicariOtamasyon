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
    public class CategoryController : Controller
    {
        CategoryManager _cm;
        public CategoryController()
        {
            _cm = new CategoryManager();
        }
        // GET: Category
        public ActionResult Index()
        {
            CategoryVM vM = new CategoryVM()
            {
                Categories = _cm.GetActives()
            };
            return View(vM);
        }

        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _cm.Add(category);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM vM = new CategoryVM()
            {
                Category = _cm.Find(id)
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _cm.Update(category);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            _cm.Delete(_cm.Find(id));
            return RedirectToAction("Index");
        }





    }
}