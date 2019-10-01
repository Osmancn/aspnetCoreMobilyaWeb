using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Entity
{
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunBaslik { get; set; }
        public string Aciklama { get; set; }
        public int GozukmeSayisi { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        public List<UrunImage> Images { get; set; }
    }
}
