using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Entity
{
    public class UrunImage
    {
        public int UrunImageId { get; set; }
        public string ImageUrl { get; set; }

        public int UrunId { get; set; }
        public Urun Urun { get; set; }
    }
}
