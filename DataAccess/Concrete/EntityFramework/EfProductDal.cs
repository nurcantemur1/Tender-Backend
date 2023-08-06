﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, TenderContext>, IProductDal
    {
        public List<Product> GetProductDetails()
        {
            using (TenderContext context = new TenderContext())
            {
                var result = context.Products.ToList();
                return result;
            }
        }
    }
}
