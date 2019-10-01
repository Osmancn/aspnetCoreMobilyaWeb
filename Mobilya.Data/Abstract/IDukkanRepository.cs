using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilya.Data.Abstract
{
    public interface IDukkanRepository:IGenericRepository<Dukkan>
    {
        Dukkan GetDukkan();
    }
}
