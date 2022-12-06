using Framework.Asp.Infrastructure;
using Framework.Shared.Resourses;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategoryManagement
{
    public class IndexModel : BasePageModel
    {
        public readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public ProductCategorySearchModel SearchModel { get; set; }
        public UpdateProductCategoryCmd UpdateProductCategoryCmd { get; set; }
       
        public IEnumerable<ProductCategoryViewModel> ViewResult { get; set; }
        public async Task OnGet(ProductCategorySearchModel searchModel)
        {
            try
            {
                var result = await _productCategoryApplication.Search(searchModel);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    ViewResult = new List<ProductCategoryViewModel>();
                    return;
                }
                ViewResult = result.Data;
            }
            catch (Exception e)
            {
                AddToastError(ErrorMessages.ProblemOccurred);
            }
        }
        [Route("id")]
        public async Task<IActionResult> OnGetEdit(long id)
        {
            try
            {
                var result = await _productCategoryApplication.GetDetail(id);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    return Page();
                }

                var resutlMapToEditCmd = result.Data.Adapt<UpdateProductCategoryCmd>();
                return Partial("./Edit", resutlMapToEditCmd);
            }
            catch (Exception e)
            {
                AddToastError(ErrorMessages.ProblemOccurred);
                return Page();
            }
        }
        public async Task<IActionResult> OnPostEdit(UpdateProductCategoryCmd  updateProductCategory)
        {
            try
            {
                var result =  await _productCategoryApplication.Edit(updateProductCategory);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    return BadRequest(result);
                }
                AddRangeToastSuccess(result.Message);
                return new OkObjectResult(result); ;
            }
            catch (Exception e)
            {
                return new OkObjectResult(ErrorMessages.ProblemOccurred); 
            }
        }
        public async Task<IActionResult> OnGetCreate()
        {
            return Partial("./Create");
        }
        public async Task<IActionResult> OnPostCreate(CreateProductCategoryCmd productCategoryCmd)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Partial("./Create",productCategoryCmd);
                }
                var result = await _productCategoryApplication.Create(productCategoryCmd);
                if (result.IsSuccess == false)
                {
                    AddRangeToastErrors(result.Message);
                    return BadRequest(result);
                }

                AddRangeToastSuccess(result.Message);
                return new OkObjectResult(result); ;
            }
            catch (Exception e)
            {
                return new OkObjectResult(ErrorMessages.ProblemOccurred);
            }
        }
    }
}
