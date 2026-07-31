namespace API_Gateway.Kafka
{
    public interface IKafkaProducer<in TMessage> : IDisposable
    {
        Task Produce(TMessage message, CancellationToken cancellationToken);
    }
}
