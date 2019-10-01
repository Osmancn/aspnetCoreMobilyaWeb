using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Entity
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}
