using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.ProductCategory;

namespace ShopManagement.Infrastructure.ConfigureServices;

public static class ApplicationLayerServiceBootrapper
{
     internal static void ShopManagementAppLayerServicesBootstrapper(this IServiceCollection services)
    {
        services.AddScoped<IProductCategoryApplication, ProductCategoryApplication>();
    }
}