using System.Data;
using Framework.Application.Extensions;
using Framework.Utilities.ResultUtil;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.Sm.UnitOfWork;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;

namespace ShopManagement.Application.ProductCategory;

public class ProductCategoryApplication : IProductCategoryApplication
{
    private readonly IProductCategoryRepository _repository;
    private readonly IUnitOfWorkShopManagement _unitOfWork;

    public ProductCategoryApplication(IProductCategoryRepository repository, IUnitOfWorkShopManagement unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultOperation> Create(CreateProductCategoryDto command)
    {
       await _repository.Create(command.MapToProductCategory());
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation> Edit(UpdateProductCategoryDto command)
    {
        var entity = await _repository.Get(x => x.Id == command.Id);
        if (entity == null) return ResultOperation.BuildFailedResult("دسته بندی محصول خواسته شده پیدا نشد");
        await _repository.Update(command.MapToProductCategory(entity));
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(
        ProductCategorySearchModel searchModel)
    {
        // Validate SearchModel

        // Generate Query 
        string query = @$"select * from ProductCategories select * from ProductCategories pc 
        where 1 = 1
        {(string.IsNullOrWhiteSpace(searchModel.Name) ? "":$"And pc.Name LIKE N'%@{nameof(searchModel.Name)}%'" )}" ;

        var sqlParamerter = new SqlParameter[]
        {
            new SqlParameter()
            {
                ParameterName = $"@{nameof(searchModel.Name)}",
                Value = searchModel.Name,
            },
        };
        // Get Result 

        var result = await _repository.GetAll(query,sqlParamerter);
        if (result == null)
            return ResultOperation<IEnumerable<ProductCategoryViewModel>>.BuildFailedResult("لیست خالیست");

        return result.ProjectToType<ProductCategoryEntity, ProductCategoryViewModel>().ToSuccessResult();
    }
}