using Microsoft.EntityFrameworkCore;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Data.Concreat.EfCore
{
    public class MobilyaContext :DbContext
    {
        public MobilyaContext(DbContextOptions<MobilyaContext> options)
            :base(options)
        {

        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunImage> Images { get; set; }
        public DbSet<Dukkan> Dukkan { get; set; }
    }
}
