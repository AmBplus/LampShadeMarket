using System.Data;
using Framework.Application.Extensions;
using Framework.Utilities.ResultUtil;
using Mapster;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.Sm.UnitOfWork;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using Microsoft.Data.SqlClient;
using ShopManagement.Application.Contract.Maping;

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

    public async Task<ResultOperation> Create(CreateProductCategoryCmd command)
    {
       await _repository.Create(command.MapToProductCategory());
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation> Edit(UpdateProductCategoryCmd command)
    {
        var entity = await _repository.Get(x => x.Id == command.Id);
        if (entity == null) return ResultOperation.BuildFailedResult("دسته بندی محصول خواسته شده پیدا نشد");
        await _repository.Update(command.MapToProductCategory(entity));
        await _unitOfWork.SaveChangesAsync();
        return ResultOperation.BuildSuccessResult();
    }

    public async Task<ResultOperation<ProductCategoryDetails>> GetDetail(long id)
    {
        ProductCategoryDetails details = new ProductCategoryDetails();
        var entity = await _repository.Get(x => x.Id == id);
        if (entity == null) return details.ToFailed("انتیتی یافت نشد ");
        details = entity.Adapt<ProductCategoryDetails>();
        return details.ToSuccessResult();
    }

    public async Task<ResultOperation<IEnumerable<ProductCategoryViewModel>>> Search(
        ProductCategorySearchModel searchModel)
    {
        // Validate SearchModel

        // Generate Query 
        string query = @$"select * from ProductCategories pc 
        where 1 = 1
        {(string.IsNullOrWhiteSpace(searchModel.Name) ? "":$"And pc.Name LIKE @{nameof(searchModel.Name)}" )}" ;

        var sqlParamerter = new SqlParameter[]
        {
            new SqlParameter()
            {
                ParameterName = $"@{nameof(searchModel.Name)}",
                Value = $"%{searchModel.Name}%",

            },
        };
        // Get Result 

        var result = await _repository.GetAll(query,sqlParamerter);
        if (result == null)
            return ResultOperation<IEnumerable<ProductCategoryViewModel>>.BuildFailedResult("لیست خالیست");

        return result.ProjectToType<ProductCategoryEntity, ProductCategoryViewModel>().ToSuccessResult();
    }
}