using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mobilya.Data.Abstract;
using Mobilya.Entity;
using Mobilya.WebUI.Models;

namespace Mobilya.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IKategoriRepository kategoriRepo;
        private IUrunRepository urunRepo;
        private IUrunImageRepository imageRepo;
        public AdminController(IKategoriRepository KateRepo, IUrunRepository UrunRepo,
            IUrunImageRepository ImageRepo)
        {
            kategoriRepo = KateRepo;
            urunRepo = UrunRepo;
            imageRepo = ImageRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KategoriList()
        {
            return View(kategoriRepo.GetAll());
        }

        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori entity)
        {
            kategoriRepo.Add(entity);
            TempData["message"] = $"{entity.KategoriAd} eklendi";
            return RedirectToAction("KategoriList");
        }

        public IActionResult KategoriSil(int id)
        {
            Kategori entity = kategoriRepo.GetbyId(id);
            kategoriRepo.Delete(entity);
            TempData["message"] = $"{entity.KategoriAd} Silindi";

            return RedirectToAction("KategoriList");
        }

        public IActionResult KategoriDuzenle(int id)
        {
            Kategori kategori = kategoriRepo.GetbyId(id);
            if (kategori != null)
                return View(kategori);
            return RedirectToAction("KategoriList");
        }

        [HttpPost]
        public IActionResult KategoriDuzenle(Kategori entity)
        {
            if (ModelState.IsValid)
            {
                kategoriRepo.Update(entity);
                TempData["message"] = $"{entity.KategoriId} id li kategori değiştirildi";
                return RedirectToAction("KategoriList");
            }
            return View(entity);
        }

        public IActionResult UrunList()
        {
            IEnumerable<Urun> urunlist = urunRepo.GetAll();
            List<UrunImageModel> urunler = new List<UrunImageModel>();
            foreach (var item in urunlist)
            {
                urunler.Add(new UrunImageModel()
                {
                    Urun = item,
                    Images = imageRepo.GetByUrunId(item.UrunId).ToList()
                });
            }
            return View(urunler);
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            ViewBag.Kategoriler = new SelectList(kategoriRepo.GetAll(), "KategoriId", "KategoriAd");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun entity, IEnumerable<IFormFile> file)
        {
            ViewBag.Kategoriler = new SelectList(kategoriRepo.GetAll(), "KategoriId", "KategoriAd");
            if (ModelState.IsValid && file != null)
            {
                Account acc = new Account("naimmobilya", "742112311237693", "nqeO8i7tnQpNPnSAQyESOqImU-I");
                Cloudinary cloudinary = new Cloudinary(acc);
                Urun urun = urunRepo.Add(entity);
                foreach (var item in file)
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", item.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);

                    }
                    UrunImage image = new UrunImage() { UrunId = urun.UrunId };
                    imageRepo.Add(image);
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(filePath),
                        PublicId = "" + image.UrunImageId

                    };
                    var uploadResult = cloudinary.Upload(uploadParams);
                    image.ImageUrl = uploadResult.Uri.ToString();
                    imageRepo.Update(image);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                TempData["message"] = $"{entity.UrunId} id li ürün eklendi";
                return RedirectToAction("UrunList");
            }
            return View(entity);
        }

        public IActionResult UrunDuzenle(int id)
        {
            ViewBag.Kategoriler = new SelectList(kategoriRepo.GetAll(), "KategoriId", "KategoriAd");
            Urun urun = urunRepo.GetbyId(id);
            if (urun == null)
                return RedirectToAction("UrunList");
            UrunImageModel model = new UrunImageModel()
            {
                Urun = urun,
                Images = imageRepo.GetByUrunId(urun.UrunId).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UrunDuzenle(UrunImageModel entity, IEnumerable<IFormFile> file)
        {
            ViewBag.Kategoriler = new SelectList(kategoriRepo.GetAll(), "KategoriId", "KategoriAd");
            if (ModelState.IsValid)
            {
                Account acc = new Account("naimmobilya", "742112311237693", "nqeO8i7tnQpNPnSAQyESOqImU-I");
                Cloudinary cloudinary = new Cloudinary(acc);
                if (file != null)
                {
                    foreach (var item in file)
                    {
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", item.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await item.CopyToAsync(stream);

                        }
                        UrunImage image = new UrunImage() { UrunId = entity.Urun.UrunId };
                        imageRepo.Add(image);
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(filePath),
                            PublicId = "" + image.UrunImageId

                        };
                        var uploadResult = cloudinary.Upload(uploadParams);
                        image.ImageUrl = uploadResult.Uri.ToString();
                        imageRepo.Update(image);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                }
                urunRepo.Update(entity.Urun);
                TempData["message"] = $"{entity.Urun.UrunId} id li ürün eklendi";
                return RedirectToAction("UrunList");
            }
            return View(entity);
        }

        public IActionResult UrunSil(int id)
        {
            Urun entity = urunRepo.GetbyId(id);
            if (entity != null)
            {
                Account acc = new Account("naimmobilya", "742112311237693", "nqeO8i7tnQpNPnSAQyESOqImU-I");
                Cloudinary cloudinary = new Cloudinary(acc);
                List<UrunImage> images = imageRepo.GetByUrunId(entity.UrunId).ToList();
                foreach (var item in images)
                {
                    cloudinary.DeleteResources(item.UrunImageId.ToString());
                }
                urunRepo.Delete(entity);
                TempData["message"] = $"{entity.UrunId} id li ürün silindi";
            }

            return RedirectToAction("UrunList");
        }
        public IActionResult ImageSil(int id)
        {
            UrunImage entity = imageRepo.GetbyId(id);
            if (entity != null)
            {
                Account acc = new Account("naimmobilya", "742112311237693", "nqeO8i7tnQpNPnSAQyESOqImU-I");
                Cloudinary cloudinary = new Cloudinary(acc);
                cloudinary.DeleteResources(entity.UrunImageId.ToString());
                imageRepo.Delete(entity);
                TempData["message"] = $"{entity.UrunId} id li image silindi";
            }

            return RedirectToAction("UrunDuzenle", new { id = entity.UrunId });
        }
    }
}