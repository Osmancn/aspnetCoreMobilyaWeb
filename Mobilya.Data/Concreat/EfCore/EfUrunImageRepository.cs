using Mobilya.Data.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobilya.Data.Concreat.EfCore
{
    public class EfUrunImageRepository : EfGenericRepository<UrunImage>,IUrunImageRepository
    {

        public EfUrunImageRepository(MobilyaContext ctx):base(ctx)
        {
           
        }

        public MobilyaContext MobilyaContext
        {
            get { return context as MobilyaContext; }
        }

        public UrunImage GetImageByUrunId(int urunId)
        {
            return MobilyaContext.Images.FirstOrDefault(i => i.UrunId == urunId);
        }

        IQueryable<UrunImage> IUrunImageRepository.GetByUrunId(int urunId)
        {
            return MobilyaContext.Images.Where(i => i.UrunId == urunId);
        }
    }
}
