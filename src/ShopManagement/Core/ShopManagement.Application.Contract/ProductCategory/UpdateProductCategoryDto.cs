using Framework.Utilities;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Application.Contract.ProductCategory;

public class UpdateProductCategoryDto : CreateProductCategoryDto
{
    public long Id { get; set; }

    public virtual ProductCategoryEntity MapToProductCategory(ProductCategoryEntity productCategoryEntity)
    {
        productCategoryEntity.Edit(this.Name, this.Description,
            this.ImageSrc,
            this.ImageAlt, this.ImageTitle, this.Keywords,
            this.MetaDescription, this.Slug.Slugify());
        return productCategoryEntity;
    }
}