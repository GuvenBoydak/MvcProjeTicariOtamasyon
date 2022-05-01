﻿using Project.BLL.DesingPatterns.GenericRepository.ConcreteRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class StatisticsController : Controller
    {
        CustomerManager _cManager;
        ProductManager _pManager;
        EmployeeManager _eManager;
        CategoryManager _cateManager;
        SalesMovementManager _sManager;

        public StatisticsController()
        {
            _cManager = new CustomerManager();
            _pManager = new ProductManager();
            _eManager = new EmployeeManager();
            _cateManager = new CategoryManager();
            _sManager = new SalesMovementManager();
        }

        // GET: Statistics
        public ActionResult Index()
        {
            string CustomerCount = _cManager.Count().ToString();
            ViewBag.CustomerCount = CustomerCount;

            string ProductCount = _pManager.Count().ToString();
            ViewBag.ProductCount = ProductCount;

            string EmployeeCount = _eManager.Where(x => x.ID == x.ID).Count().ToString();
            ViewBag.EmployeeCount = EmployeeCount;

            string CategoryCount = _cateManager.Where(x => x.ID == x.ID).Count().ToString();
            ViewBag.CategoryCount = CategoryCount;

            string TotalStock = _pManager.Sum(x=>x.Stock).ToString();
            ViewBag.TotalStock = TotalStock;

            string CriticalStock = _pManager.Where(x => x.Stock<=20).Count().ToString();
            ViewBag.CriticalStock = CriticalStock;

            string BrandCount = _pManager.GetActives().Select(x => x.Brand).Distinct().Count().ToString();
            ViewBag.BrandCount = BrandCount;

            string MaxPriceProduct = _pManager.GetActives().OrderByDescending(x => x.SellPrice).FirstOrDefault().Name;
            ViewBag.MaxPriceProduct = MaxPriceProduct;

            string MinPriceProduct = _pManager.GetActives().OrderBy(x => x.SellPrice).FirstOrDefault().Name;
            ViewBag.MinPriceProduct = MinPriceProduct;

            string BuzdolabiCount = _pManager.Where(x => x.Name == "Buzdolabı").Count().ToString();
            ViewBag.BuzdolabiCount = BuzdolabiCount;

            string MaxProductOfTheCategory = _cateManager.GetActives().Where(x => x.ID == (_pManager.GetActives().GroupBy(y => y.CategoryID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.MaxProductOfTheCategory = MaxProductOfTheCategory;

            string MaxBrand = _pManager.GetActives().GroupBy(x => x.Brand).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            ViewBag.MaxBrand = MaxBrand;

            string MoneyInTheSafe = _sManager.GetActives().Sum(x => x.TotalPrice).ToString();
            ViewBag.MoneyInTheSafe = MoneyInTheSafe;

            string SalesToday = _sManager.GetActives().Count(x => x.CreatedDate == DateTime.Today).ToString();
            ViewBag.SalesToday = SalesToday;

            string MoneyInTheSafeToday = _sManager.Where(x => x.CreatedDate == DateTime.Today).Sum(x => x.TotalPrice).ToString();
            ViewBag.MoneyInTheSafeToday = MoneyInTheSafeToday;

            string BestSellingProduct =_pManager.GetActives().Where(x=>x.ID ==(_sManager.GetActives().GroupBy(y => y.ProductID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault())).Select(x=>x.Name).FirstOrDefault();
            ViewBag.BastSellingProduct = BestSellingProduct;

            return View();
        }
    }
}