﻿

using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contract.Sm.UnitOfWork;
using ShopManagement.Domain.ProductAggregate.ProductCategoryModel;
using ShopManagement.Persistence.Repository;
using ShopManagement.Persistence.unit_of_work_ef_core;

namespace ShopManagement.Infrastructure.ConfigureServices;

public static class RepositoryConfiguration
{
    internal static void ShopManagementBootstrapRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IUnitOfWorkShopManagement, UnitOfWorkShopManagement>();
    }
}