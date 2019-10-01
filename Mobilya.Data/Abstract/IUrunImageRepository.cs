using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobilya.Data.Abstract
{
    public interface IUrunImageRepository:IGenericRepository<UrunImage>
    {
        IQueryable<UrunImage> GetByUrunId(int urunId);
        UrunImage GetImageByUrunId(int urunId);
    }
}
