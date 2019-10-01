using Microsoft.AspNetCore.Mvc;
using Mobilya.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Components
{
    public class Telefon:ViewComponent
    {
        IDukkanRepository dukkanRepo;
        public Telefon(IDukkanRepository DukkanRepo)
        {
            dukkanRepo = DukkanRepo;
        }
        public string Invoke()
        {
            return dukkanRepo.GetDukkan().Telefon;
        }
    }
}
