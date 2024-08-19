using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using RealState.Entity;
using RealState.JWTools;
using RealState.Models;
using RealState.Repository.GenericRepository;
using RealState.Repository.IRepository;
using RealState.ValidationRules;

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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IFSBORepository, FSBORepository>();
        services.AddScoped<IQuestRepository, QuestRepository>();
        services.AddScoped<ICalendarRepository, CalendarRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();

        services.AddScoped<IPasswordHasher<AppUser>, PasswordHasher<AppUser>>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<JWTokenGenerator>();

    }
}
