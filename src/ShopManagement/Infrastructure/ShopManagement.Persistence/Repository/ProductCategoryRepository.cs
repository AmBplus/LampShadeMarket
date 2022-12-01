using System.Linq.Expressions;
using Framework.Infrastructure.Repository;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;

namespace ShopManagement.Persistence.Repository;

public class ProductCategoryRepository : BaseGenericRepository<long,ProductCategoryEntity> , IProductCategoryRepository
{
    private readonly ShopManagementContext _contex;

    public ProductCategoryRepository(ShopManagementContext contex) : base(contex)
    {
        _contex = contex;
    }

}