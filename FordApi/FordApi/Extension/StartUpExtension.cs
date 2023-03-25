﻿using AutoMapper;
using FordApi.Data;
using FordApi.Service;
using FordApi.Service.Abstract;
using FordApi.Service.Concrete;

namespace FordApi.Web.Extension;

public static class StartUpExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        // uow
        services.AddScoped<IUnitOfWork,UnitOfWork>();
        

        services.AddScoped<ScopedService>();
        services.AddTransient<TransientService>();
        services.AddSingleton<SingletonService>();
    }

    public static void AddMapperService(this IServiceCollection services)
    {
        // mapper
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new MappingProfile());
        });
        services.AddSingleton(mapperConfig.CreateMapper());
    }


    public static void AddBussinessServices(this IServiceCollection services)
    {
        // repos
        services.AddScoped<IGenericRepository<Account>,GenericRepository<Account>>();
        services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

        // services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IAccountService, AccountService>();
    }
}
