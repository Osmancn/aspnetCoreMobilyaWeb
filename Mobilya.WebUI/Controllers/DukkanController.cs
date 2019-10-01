using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;

namespace Mobilya.WebUI.Controllers
{
    public class DukkanController : Controller
    {
        IDukkanRepository dukkanRepo;
        public DukkanController(IDukkanRepository DukkanRepo)
        {
            dukkanRepo = DukkanRepo;
        }
        public IActionResult Iletisim()
        {
            return View(dukkanRepo.GetDukkan());
        }

        public IActionResult OzelUrun()
        {
            return View(dukkanRepo.GetDukkan());
        }

        public IActionResult Hakkimizda()
        {
            return View(dukkanRepo.GetDukkan());

        }
    }
}