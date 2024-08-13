using FluentValidation.AspNetCore;
using FluentValidation;
using RealState.ValidationRules;
using Microsoft.AspNetCore.Hosting;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;

namespace RealState.Container;

public static class Extensions
{
    public static void RegisterValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation(config =>
        {
            config.DisableDataAnnotationsValidation = true;
        });

        services.AddValidatorsFromAssemblyContaining<BuyerValidator>();


        services.AddScoped<IBuyerRepository, BuyerRepository>();
        services.AddScoped<ISellerRepository, SellerRepository>();
        services.AddScoped<IPortfolioRepository, PortfolioRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }
}
