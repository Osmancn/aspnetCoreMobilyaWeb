using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobilya.Data.Abstract
{
    public interface IUrunRepository :IGenericRepository<Urun>
    {
        IQueryable<Urun> GetByKategoriId(int kategoriId);
    }
}
