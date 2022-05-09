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
    public class ShippingController : Controller
    {
        ShippingDetailRepository _sdRepository;
        ShippingTrackingRepository _stRepository;
        public ShippingController()
        {
            _sdRepository = new ShippingDetailRepository();
            _stRepository = new ShippingTrackingRepository();
        }
        // GET: Shipping
        public ActionResult Index()
        {
            ShippingDetailVM vM = new ShippingDetailVM()
            {
                ShippingDetails = _sdRepository.GetActives(),
                ShippingTrackings=_stRepository.GetActives()
                
            };
            Random rdm = new Random();
            string[] Characters = { "A", "B", "C", "D","E","F","G","H" };
            int k1, k2, k3;
            k1 = rdm.Next(0, Characters.Length);
            k2 = rdm.Next(0, Characters.Length);
            k3 = rdm.Next(0, Characters.Length);
            int s1, s2, s3;
            s1 = rdm.Next(100, 999);
            s2 = rdm.Next(10, 99);
            s3 = rdm.Next(10, 99);

            var TrackingCode = s1.ToString() + Characters[k1] + s2 + Characters[k2] + s3 + Characters[k3];
            ViewBag.TrackingCode = TrackingCode;
            return View(vM);
        }

        public ActionResult AddShippingDetail()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult AddShippingDetail(ShippingDetail shippingDetail)
        {
            _sdRepository.Add(shippingDetail);
            return RedirectToAction("Index");
        }

        public ActionResult ShippingTracking(string id)
        {
            ShippingDetailVM vM = new ShippingDetailVM()
            {          
                ShippingTrackings = _stRepository.Where(x => x.TrackingCode == id)
            };
            return View(vM);
        }


    }
}