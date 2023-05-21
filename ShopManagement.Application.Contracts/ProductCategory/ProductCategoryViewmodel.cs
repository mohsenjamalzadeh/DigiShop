﻿namespace ShopManagement.Application.Contracts.ProductCategory;

public class ProductCategoryViewmodel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PictureAlt { get; set; }
    public string PictureTitle { get; set; }
    public string Picture { get; set; }
    public string CreationDate { get; set; }
}