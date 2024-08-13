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

        services.AddValidatorsFromAssemblyContaining<CustomerValidator>();


        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IBuyerRepository, BuyerRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }
}
