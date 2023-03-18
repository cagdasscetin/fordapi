using FordApi.Data;

namespace FordApi.Web.Extension;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        // uow
        services.AddScoped<IUnitOfWork,UnitOfWork>();

        // repos
        //services.AddScoped<IGenericRepository<Account>,GenericRepository<Account>>();
        //services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

        services.AddScoped<ScopedService>();
        services.AddTransient<TransientService>();
        services.AddSingleton<SingletonService>();
    }
}
