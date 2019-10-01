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
    public class HomeController : Controller
    {
        IUrunImageRepository imageRepo;
        IUrunRepository urunRepo;
        IKategoriRepository kateRepo;
        IDukkanRepository dukkanRepo;
        public HomeController(IUrunRepository UrunRepo, IUrunImageRepository ImageRepo,
            IKategoriRepository KateRepo,IDukkanRepository DukkanRepo)
        {
            imageRepo = ImageRepo;
            urunRepo = UrunRepo;
            kateRepo = KateRepo;
            dukkanRepo = DukkanRepo;
        }
        public IActionResult Index()
        {
            return View(dukkanRepo.GetDukkan());
        }

        public IActionResult Kategori(int? id)
        {
            List<Urun> urunler;
            if (id == null || id==0)
                urunler = urunRepo.GetAll().ToList();

            else
                urunler = urunRepo.GetByKategoriId((int)id).ToList();
            
            if (urunler.Count()!=0)
            {
                ViewBag.kategori = kateRepo.GetbyId(urunler[0].KategoriId).KategoriAd;

                if (id == null)
                    urunler[0].Kategori.KategoriAd = "Tüm Ürünler";
                List<UrunImageModel> model = new List<UrunImageModel>();

                foreach (var item in urunler)
                {
                    List<UrunImage> image = new List<UrunImage>();
                    image.Add(imageRepo.GetImageByUrunId(item.UrunId));
                    model.Add(new UrunImageModel()
                    {
                        Urun = item,
                        Images = image
                    });
                }
                if (id == null || id == 0)
                    ViewBag.kategori = "Tüm Kategoriler";
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}