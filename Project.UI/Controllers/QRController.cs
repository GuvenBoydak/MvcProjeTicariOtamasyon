using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string trackingCode)
        {
            using (MemoryStream ms=new MemoryStream())
            {
                QRCodeGenerator createQR = new QRCodeGenerator();
                QRCodeGenerator.QRCode QrCode = createQR.CreateQrCode(trackingCode, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap image=QrCode.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}