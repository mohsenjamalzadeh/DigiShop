﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Infrastructure;
using _01_framework.Application;
using _01_framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _context;
        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductCategory GetDetails(long id)
        {
            var productCategory = _context.ProductCategories.Select(p => new EditProductCategory
            {
                Id = p.Id,
                Description = p.Description,
                MetaDescription = p.MetaDescription,
                KeyWords = p.KeyWords,
                PictureAlt = p.PictureAlt,
                PictureTitle = p.PictureTitle,
                Slug = p.Slug,
                Name = p.Name
            }).FirstOrDefault(p => p.Id == id);

            return productCategory;

        }

        public List<ProductCategoryViewmodel> GetAll(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(p => new ProductCategoryViewmodel()
            {
                Name = p.Name,
                Picture = p.Picture,
                Id = p.Id,
                CreationDate = p.CreationDate.ToString("g"),
                PictureTitle = p.PictureTitle,
                PictureAlt = p.PictureAlt,
                ModefiedDate = p.ModefiedDate.ToString("g")
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(p => p.Name.Contains(searchModel.Name));

            return query.OrderByDescending(p => p.Id).ToList();
        }

        public List<ProductCategoryViewmodel> GetCategories()
        {
            var query = _context.ProductCategories.Select(p => new ProductCategoryViewmodel
            {
                Id = p.Id,
                Name = p.Name

            }).AsNoTracking().ToList();
            return query;
        }

        public string GetSlugForUploadfile(long id) => _context.ProductCategories.FirstOrDefault(p => p.Id == id).Name;
    }
}
