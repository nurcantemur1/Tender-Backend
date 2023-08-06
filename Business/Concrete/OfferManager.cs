using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class OfferManager : IOfferService
    {
        private IOfferDal _offerDal;
        private IProductDal _productDal;

        public OfferManager(IOfferDal offerDal, IProductDal productDal)
        {
            this._productDal = productDal;
            this._offerDal = offerDal;
        }

        public IDataResult<List<Offer>> GetAll()
        {
            return new SuccessDataResult<List<Offer>>(_offerDal.GetAll());
        }

        public IDataResult<List<Offer>> GetAllByUser(int userId)
        {
            return new SuccessDataResult<List<Offer>>(_offerDal.GetAllbyUserId(userId),Messages.Listed);
        }

        public IDataResult<List<Product>> GetAllEarnedProducts(int userId)
        {
            var kazanilanurunler =new List<Product>();
            List<Offer> peyverilenurunlistesi = _offerDal.GetAllbyUserId(userId).ToList();
            foreach (var item in peyverilenurunlistesi)
            {
                if (GetLastOffer(productId: item.productId).Success == true)
                {
                    Product urun = _productDal.Get(x=> x.id == item.productId); 
                    kazanilanurunler.Add(urun);
                    return new SuccessDataResult<List<Product>>(kazanilanurunler.ToList(), Messages.Listed);
                } 
               
            }

            return null;
        }

        public IResult Add(Offer offer)
        {
            _offerDal.Add(offer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Offer offer)
        {
            _offerDal.Update(offer);
            return new SuccessResult(Messages.Updated);
        }

        public IResult GetLastOffer(int productId)
        {
            return new SuccessDataResult<Offer>(_offerDal.GetLastOffer(productId), "son pey");
        }
    }
}
