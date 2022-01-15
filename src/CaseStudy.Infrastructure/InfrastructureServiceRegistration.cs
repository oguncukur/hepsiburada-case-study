using System;
using CaseStudy.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using CaseStudy.Application.Repository;
using CaseStudy.Infrastructure.Repositories;
using CaseStudy.Application.Infrastructure;
using CaseStudy.Infrastructure.Cache;

namespace CaseStudy.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IMongoDbContext, MongoDbContext>();
            services.AddTransient<ExceptionHandlerMiddleware>();
            return services;
        }

        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services, Action<MongoDbSettings> mongoDbSettings)
        {
            services.Configure(mongoDbSettings);
            return services;
        }
    }
}