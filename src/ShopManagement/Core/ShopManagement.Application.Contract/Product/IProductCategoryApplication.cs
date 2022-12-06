using Framework.Utilities.ResultUtil;

namespace ShopManagement.Application.Contract.Product;

public interface IProductApplication
{
    Task<ResultOperation> Create(CreateProductCmd command);
    Task<ResultOperation> Edit(UpdateProductCmd command);
    Task<ResultOperation<ProductDetails>> GetDetail(long id);
    Task<ResultOperation<IEnumerable<ProductViewModel>>> Search(ProductSearchModel searchModel);
}