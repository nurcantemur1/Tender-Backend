using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ImageManager: IImageService
    {
        private IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(Image image)
        {
             _imageDal.Add(image);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Image image)
        {
            _imageDal.Update(image);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Image>> GetAllbyProduct(int productId)
        {
            var result = _imageDal.GetAllbyProduct(productId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Image>>(result.ToList(), Messages.Listed);
            }

            return null;
        }
    }
}
