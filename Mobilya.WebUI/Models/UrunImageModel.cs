using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.WebUI.Models
{
    public class UrunImageModel
    {
        public Urun Urun { get; set; }
        public List<UrunImage> Images { get; set; }
    }
}
