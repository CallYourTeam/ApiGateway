using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace API_Gateway.Kafka
{
    public class KafkaProducer<TMessage> : IKafkaProducer<TMessage>
    {
        private readonly IProducer<string, TMessage> _producer;
        private readonly string _topic;

        public KafkaProducer(IOptions<KafkaSettings> settings)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = settings.Value.BootstrapServers
            };

            _producer = new ProducerBuilder<string, TMessage>(config)
                .SetValueSerializer(new KafkaJsonSerializer<TMessage>())
                .Build();

            _topic = settings.Value.TopicName;
        }

        public void Dispose()
        {
            _producer.Dispose();
        }

        public async Task Produce(TMessage message, CancellationToken cancellationToken)
        {
            await _producer.ProduceAsync(_topic, new Message<string, TMessage>
            {
                Key = "uniq1",
                Value = message
            }, cancellationToken);
        }
    }
}
