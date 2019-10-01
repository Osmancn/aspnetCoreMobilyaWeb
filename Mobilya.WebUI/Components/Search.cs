using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Components
{
    public class Search :ViewComponent
    {
        IKategoriRepository kategoriRepo;
        public Search(IKategoriRepository kateRepo)
        {
            kategoriRepo = kateRepo;
        }

        public IViewComponentResult Invoke()
        {
            return View(kategoriRepo.GetAll());
        }
    }
}
