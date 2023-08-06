using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IImageDal : IEntityRepository<Image>
    {
        public List<Image> GetAllbyProduct(int productId);
    }
}