using FluentValidation.AspNetCore;
using FluentValidation;
using RealState.ValidationRules;
using Microsoft.AspNetCore.Hosting;

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


    }
}
