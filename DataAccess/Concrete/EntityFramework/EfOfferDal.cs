using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOfferDal : EfEntityRepositoryBase<Offer, TenderContext>, IOfferDal
    {
        public List<Offer> GetAllbyUserId(int userId)
        {
            using (TenderContext db = new TenderContext())
            {
                return db.Offers.Where(x => x.userId == userId).ToList();
            }
        }

        public Offer GetLastOffer(int productId)
        {
            using (TenderContext db = new TenderContext())
            {
                var list = db.Offers.Where(x => x.productId == productId).ToList();
                return list[list.Count-1];
            }
        }
    }
}
