namespace API_Gateway.Kafka
{
    public class KafkaSettings
    {
        public required string BootstrapServers { get; set; }
        public required string TopicName { get; set; }
    }
}
