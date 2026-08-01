using KafkaModule;

namespace ApiGateway.Extensions
{
    public static class Extension
    {
        public static void AddProducer<TMessage>(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<KafkaSettings>(configurationSection);
            services.AddSingleton<IKafkaProducer<TMessage>, KafkaProducer<TMessage>>();
        }

        public static IServiceCollection AddConsumer<TMessage, THandler>(this IServiceCollection services, IConfigurationSection configurationSection)
            where THandler : class, IMessageHandler<TMessage>
        {
            services.Configure<KafkaSettings>(configurationSection);
            services.AddHostedService<KafkaConsumer<TMessage>>();
            services.AddSingleton<IMessageHandler<TMessage>, THandler>();

            return services;
        }
    }
}
