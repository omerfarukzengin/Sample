using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.Core.Behaviors;
using System.Reflection;

namespace Sample.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceCollectionExtensions));
        }
        public static IServiceCollection AddPipelineBehaviors(this IServiceCollection services)
        {
            return services
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
        public static IServiceCollection AddCoreMapping(this IServiceCollection services)
        {
            return services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
