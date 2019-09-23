using Books.Api.Core.Abstractions;
using Books.Api.Core.Domain;
using Books.Api.Core.Entities;
using Books.Api.Infrastructure.Mappers;
using Books.Api.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Books.Api.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MongoFactory>();
            services.AddScoped(sp => sp.GetService<MongoFactory>().MongoClient);
            services.AddScoped(sp => sp.GetService<MongoFactory>().Database);
            services.AddScoped<IRepository<Book>, BookRepository>();
            services.AddScoped<IMapper<Entities.Book, Book>, BookMapper>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<BookService>();
            return services;
        }
    }
}