using FieldManagementSystem.Brokers.Infrastructure;
using FieldManagementSystem.Brokers.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace FieldManagementSystem.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
