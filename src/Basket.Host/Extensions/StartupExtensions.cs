using Basket.Host.Builder;
using Basket.Host.Builder.Contracts;
using Basket.Host.Domain.Basket;
using Basket.Host.Repositories;
using Basket.Host.Services;
using Basket.Host.Services.Contracts;
using Basket.Host.Subscription.PriceChanged;
using MassTransit;

namespace Basket.Host.Extensions
{
    public static class StartupExtensions
    {
        public static void AddServiceRegistryConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            #region [ Service ]

            services.AddScoped<IBasketService, BasketService>();

            #endregion [ Service ]

            #region [ Events ]

            services.AddScoped<IConsumer<ChangedPriceEvent>, ChangedPriceConsumer>();

            #endregion [ Events ]

            #region [ Infra - Data ]

            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            #endregion [ Infra - Data ]

            #region [ Builder ]

            services.AddScoped<IItemBuilder, UserBasketBuilder>();

            #endregion [ Builder ]

        }
    }
}