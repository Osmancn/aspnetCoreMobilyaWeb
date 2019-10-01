using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using Mobilya.Entity;
using Mobilya.WebUI.Models;

namespace Mobilya.WebUI.Controllers
{
    public class UrunController : Controller
    {
        IUrunRepository urunRepo;
        IUrunImageRepository imageRepo;
        public UrunController(IUrunRepository UrunRepo,IUrunImageRepository ImageRepo)
        {
            urunRepo = UrunRepo;
            imageRepo = ImageRepo;
        }
        public IActionResult Detay(int id)
        {
            Urun urun = urunRepo.GetbyId(id);
            if(urun!=null)
            {
                UrunImageModel model = new UrunImageModel()
                {
                    Urun = urun,
                    Images = imageRepo.GetByUrunId(id).ToList()
                };
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}