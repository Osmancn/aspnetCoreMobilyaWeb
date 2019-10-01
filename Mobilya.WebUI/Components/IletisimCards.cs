using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Components
{
    public class IletisimCards :ViewComponent
    {
        IDukkanRepository dukkanRepo;
        public IletisimCards(IDukkanRepository DukkanRepo)
        {
            dukkanRepo = DukkanRepo;
        }

        public IViewComponentResult Invoke()
        {
            return View(dukkanRepo.GetDukkan());
        }
    }
}
