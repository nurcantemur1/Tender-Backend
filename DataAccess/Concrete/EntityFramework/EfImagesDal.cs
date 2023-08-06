using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfImagesDal : EfEntityRepositoryBase<Image, TenderContext>, IImageDal
    {
        public List<Image> GetAllbyProduct(int productId)
        {
            using (TenderContext db = new TenderContext())
            {
                return db.Images.Where(x => x.productId == productId).ToList();
            }
        }
    }
}