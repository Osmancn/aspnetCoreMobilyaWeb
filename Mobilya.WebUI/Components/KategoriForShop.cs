using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Components
{
    public class KategoriForShop:ViewComponent
    {
        IKategoriRepository kateRepo;
        public KategoriForShop(IKategoriRepository KateRepo)
        {
            kateRepo = KateRepo;
        }

        public IViewComponentResult Invoke()
        {
            return View(kateRepo.GetAll());
        }
    }
}
