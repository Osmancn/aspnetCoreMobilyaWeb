using Mobilya.Data.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mobilya.Data.Concreat.EfCore
{
    public class EfDukkanRepository : EfGenericRepository<Dukkan>, IDukkanRepository
    {
        public EfDukkanRepository(MobilyaContext ctx):base(ctx)
        {

        }
        public MobilyaContext MobilyaContext
        {
            get { return context as MobilyaContext; }
        }

        public Dukkan GetDukkan()
        {
            return MobilyaContext.Dukkan.First();
        }
    }
}
