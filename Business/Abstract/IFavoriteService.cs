using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFavoriteService
    {
        IDataResult<List<Favorite>> GetAll();
        IDataResult<Favorite> GetById(int Id);
        IResult Add(Favorite favorite);
        IResult Delete(Favorite favorite);
        IDataResult<List<Product>> GetAllbyUser(int userId);
        int ProductFavoriteCount(int productId);

    }
}