using Mobilya.Data.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobilya.Data.Concreat.EfCore
{
    public class EfUrunRepository:EfGenericRepository<Urun>,IUrunRepository
    {
        public EfUrunRepository(MobilyaContext ctx):base(ctx)
        {

        }
        public MobilyaContext MobilyaContext
        {
            get { return context as MobilyaContext; }
        }
        public IQueryable<Urun> GetByKategoriId(int kategoriId)
        {
            return MobilyaContext.Urunler.Where(i => i.KategoriId == kategoriId);
        }
    }
}
