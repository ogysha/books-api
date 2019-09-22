using BooksApi.Core.Abstractions;
using BooksApi.Core.Entities;
using BooksApi.Core.Services;
using BooksApi.Infrastructure.Mappers;
using BooksApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BooksApi.Infrastructure
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
            services.AddScoped<IMapper<Documents.Book, Book>, BookMapper>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<BookService>();
            return services;
        }
    }
}