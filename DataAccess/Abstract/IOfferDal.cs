using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IOfferDal : IEntityRepository<Offer>
    {
        public List<Offer> GetAllbyUserId(int userId);

        public Offer GetLastOffer(int productId);
    }
}
