using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Components
{
    public class Adres :ViewComponent
    {
        IDukkanRepository dukkanRepo;
        public Adres(IDukkanRepository DukkanRepo)
        {
            dukkanRepo = DukkanRepo;
        }
        public string Invoke()
        {
            return dukkanRepo.GetDukkan().Adres;
        }
    }
}
