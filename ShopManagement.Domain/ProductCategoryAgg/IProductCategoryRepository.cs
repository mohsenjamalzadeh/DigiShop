﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_framework.Domain;
using ShopManagement.Application.Contracts.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IRepository<long,ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewmodel> GetAll(ProductCategorySearchModel searchModel);
    }
}
