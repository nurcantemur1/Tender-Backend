using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IOfferService
    {
        IDataResult<List<Offer>> GetAll();
        IDataResult<List<Offer>> GetAllByUser(int userId);
        IDataResult<List<Product>> GetAllEarnedProducts(int userId);
        IResult Add(Offer offer);
        IResult Update(Offer offer);
        IResult GetLastOffer(int productId);
    }
}