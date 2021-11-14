using Microsoft.Extensions.DependencyInjection;
using Sample.Core.Interfaces.Repositories;
using Sample.Infrastructure.Persistance.Repositories;

namespace Sample.Infrastructure.Persistance.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>))
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
