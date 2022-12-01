using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.ProductCategory;

namespace ServiceHost.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IProductCategoryApplication _productCategoryApplication;

    public IndexModel(ILogger<IndexModel> logger , IProductCategoryApplication productCategoryApplication)
    {
        _logger = logger;
        _productCategoryApplication = productCategoryApplication;
    }

    public async Task OnGet()
    {
        var result = await _productCategoryApplication.Search(new ProductCategorySearchModel()
        {
            Name = "test"
        });
    }
}
