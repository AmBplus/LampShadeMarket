using System.Linq.Expressions;
using Framework.Domain.Repository;

namespace ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

public interface IProductCategoryRepository : IBaseGenericRepository<long,ProductCategoryEntity> 
{
    
}