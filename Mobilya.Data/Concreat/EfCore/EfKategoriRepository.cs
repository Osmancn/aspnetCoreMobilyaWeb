using Mobilya.Data.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Data.Concreat.EfCore
{
    public class EfKategoriRepository:EfGenericRepository<Kategori>,IKategoriRepository
    {
        public EfKategoriRepository(MobilyaContext ctx):base(ctx)
        {

        }

        public MobilyaContext MobilyaContext
        {
            get { return context as MobilyaContext; }
        }
    }
}
