using Framework.Utilities.ResultUtil;


namespace ShopManagement.Application.Contract.ProductCategory;

public interface IProductCategoryApplication
{
    Task<ResultOperation> Create(CreateProductCategoryDto command);
    Task<ResultOperation> Edit(UpdateProductCategoryDto command);
    Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(ProductCategorySearchModel searchModel);
}