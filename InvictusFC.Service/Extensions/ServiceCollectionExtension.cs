using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvictusFC.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Mapping.DataModelMappingProfile));
            return services;
        }
        public static IServiceCollection RegisterServices( this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
