using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(Image image);
        IResult Update(Image image);
        IDataResult<List<Image>> GetAllbyProduct(int productId);
    }
}