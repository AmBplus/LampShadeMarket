using Framework.Utilities.ResultUtil;


namespace ShopManagement.Application.Contract.ProductCategory;

public interface IProductCategoryApplication
{
    Task<ResultOperation> Create(CreateProductCategoryCmd command);
    Task<ResultOperation> Edit(UpdateProductCategoryCmd command);
    Task<ResultOperation<ProductCategoryDetails>> GetDetail(long id);
    Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(ProductCategorySearchModel searchModel);
}