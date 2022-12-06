using System.ComponentModel.DataAnnotations;
using Framework.Shared.Resourses;
using Framework.Utilities;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Application.Contract.ProductCategory;

public class UpdateProductCategoryCmd : CreateProductCategoryCmd
{
    [Display(ResourceType = typeof(PropertiesName),Name = nameof(PropertiesName.Id))]
    [Range(minimum:1,maximum:long.MaxValue,ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
    public long Id { get; set; }
}