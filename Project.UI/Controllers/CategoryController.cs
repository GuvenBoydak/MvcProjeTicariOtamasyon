using FluentValidation.Results;
using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using Project.BLL.ValidationRules;
using Project.ENTITIES.Concrete.Entities;
using Project.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace Project.UI.Controllers
{
    [Authorize(Roles ="A")]
    public class CategoryController : Controller
    {
        CategoryManager _cManager;
        CategoryValidator _cValidator;
        public CategoryController()
        {
            _cManager = new CategoryManager();
            _cValidator = new CategoryValidator();
        }
        // GET: Category
        public ActionResult Index(int paged=1)
        {
            CategoryVM vM = new CategoryVM()
            {
                CategoriesPaged = _cManager.GetActives().ToPagedList(paged, 7),
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
            CategoryVM model = new CategoryVM()
            {
                Category = category
            };

            ValidationResult result = _cValidator.Validate(category);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                _cManager.Add(category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM vM = new CategoryVM()
            {
                Category = _cManager.Find(id)
            };
            return View(vM);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryVM model = new CategoryVM()
            {
                Category = category
            };

            ValidationResult result = _cValidator.Validate(category);
            if (!result.IsValid)
            {
                foreach (ValidationFailure item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(model);
            }
            else
            {
                _cManager.Update(category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            _cManager.Delete(_cManager.Find(id));
            return RedirectToAction("Index");
        }





    }
}