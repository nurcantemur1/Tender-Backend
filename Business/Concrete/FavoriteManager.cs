using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private IFavoriteDal _favoriteDal;
        private IProductDal _productDal;
    

        public FavoriteManager(IFavoriteDal favoriteDal, IProductDal productDal)
        {
            _favoriteDal = favoriteDal;
            _productDal = productDal;
        }
        public IDataResult<List<Favorite>> GetAll()
        {

            return new SuccessDataResult<List<Favorite>>(_favoriteDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Favorite> GetById(int Id)
        {
            return new SuccessDataResult<Favorite>(_favoriteDal.Get(x => x.Id == Id), Messages.Listed);
        }
        public int ProductFavoriteCount(int productId)
        {
            var list = _favoriteDal.GetAll(x => x.productId == productId);
            return list.Count;
        }

        public IResult Add(Favorite favorite)
        {
            IResult result = BusinessRules.Run(CheckIfFavoritesExists(favorite.productId));

            if (result != null)
            {
                return result;
            }

            _favoriteDal.Add(favorite);

            return new SuccessResult(Messages.Added);
        }


        public IResult Delete(Favorite favorite)
        {
            _favoriteDal.Delete(favorite);
            return new SuccessResult(Messages.Deleted);
        }
        private IResult CheckIfFavoritesExists(int productId)
        {
            var result = _favoriteDal.GetAll(p => p.productId == productId).Any();
            if (result)
            {
                return new ErrorResult(Messages.ItisLike);
            }
            return new SuccessResult();
        }
        public IDataResult<List<Product>> GetAllbyUser(int userId)
        {
            List<Product> favoriurunler = new List<Product>();
            var result = _favoriteDal.GetAll(x => x.userId == userId).ToList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                         favoriurunler.Add(_productDal.Get(x=> x.id == item.productId));
                    }
                    
                }
                return new SuccessDataResult<List<Product>>(data: favoriurunler, Messages.Listed);
        }
    }
}
