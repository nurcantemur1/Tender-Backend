using System;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        //Claim
       // [SecuredOperation("admin")] 
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {

            //Aynı isimde ürün eklenemez
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.productName));

            if (result != null)
            {
                return result;
            }

            product = _productDal.Add(product);
            return new SuccessDataResult<Product>(product, Messages.Added);

        }


      //  [CacheAspect] //key,value
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<Product>> GetAllAcceptedProducts()
        { 
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x=> x.status== true), Messages.Listed);
        }

        public IDataResult<List<Product>> GetAllunAcceptedProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.status == false), Messages.Listed);
        }

        public IDataResult<List<Product>> GetAllbyUser(int userId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x=> x.userId == userId), Messages.Listed);
        }

        public IDataResult<List<Product>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.id == productId));
        }

       

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
             product = _productDal.Update(product);
             return new SuccessDataResult<Product>(product, Messages.Updated);
        }

    
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.productName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _productDal.GetAll();
            if (result.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {

            Add(product);
            if (product.price < 10)
            {
                    throw new Exception("");
            }
            
            Add(product);

            return null;
        }

    }
}
