using Framework.Utilities;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Application.Contract.ProductCategory;

public class CreateProductCategoryDto
{

    public string Name { get;  set; }
    public string Description { get; set; }
    public string ImageSrc { get; set; }
    public string ImageAlt { get; set; }
    public string ImageTitle { get; set; }
    public string Keywords { get; set; }
    public string MetaDescription { get; set; }
    public string Slug { get; set; }

    public virtual ProductCategoryEntity MapToProductCategory()
    {
        return new ProductCategoryEntity(this.Name, this.Description,
            this.ImageSrc,
            this.ImageAlt, this.ImageTitle, this.Keywords,
            this.MetaDescription, this.Slug.Slugify());
    }
}