using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Utilities;
using ShopManagement.Application.Contract.ProductCategory;

namespace ShopManagement.Application.Contract.Maping
{
    public static class Mapping_ShopManagement_Extensions
    {
        public static ProductCategoryEntity MapToProductCategory(this CreateProductCategoryCmd entity)
        {
            return new ProductCategoryEntity(entity.Name, entity.Description,
                entity.ImageSrc,
                entity.ImageAlt, entity.ImageTitle, entity.Keywords,
                entity.MetaDescription, entity.Slug.Slugify());
        }
        public static ProductCategoryEntity MapToProductCategory(this UpdateProductCategoryCmd entity , ProductCategoryEntity productCategoryEntity)
        {
            productCategoryEntity.Edit(entity.Name, entity.Description,
                entity.ImageSrc,
                entity.ImageAlt, entity.ImageTitle, entity.Keywords,
                entity.MetaDescription, entity.Slug.Slugify());
            return productCategoryEntity;
        }
    }
}
