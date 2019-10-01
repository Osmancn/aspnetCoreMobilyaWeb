using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Components
{
    public class AnaSayfaBaslik:ViewComponent
    {
        IDukkanRepository dukkanRepo;
        public AnaSayfaBaslik(IDukkanRepository DukkanRepo)
        {
            dukkanRepo = DukkanRepo;
        }
        public string Invoke()
        {
            return dukkanRepo.GetDukkan().AnaSayfaYazi;
        }
    }
}
