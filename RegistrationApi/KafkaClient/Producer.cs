using Confluent.Kafka;
using DomainLayer.Entities;
using MediatR;
using RegistrationApi.BaseClient;


namespace RegistrationApi.KafkaClient
{
    public class Producer:IProducer
    {

        ProducerConfig pconf = new ProducerConfig { BootstrapServers = "localhost:9092" };
        List<User> RegistrationList = new List<User>();
        Action<DeliveryReport<Null, string>> handler = r =>
        Console.WriteLine(!r.Error.IsError ? $"Delivered message to {r.TopicPartitionOffset}" : $"Delivery Error: {r.Error.Reason}");

        public void ReadMessage(User user)
        {
            using (var prodBuilder = new ProducerBuilder<Null, string>(pconf).Build())
            {
                string userInfos = $"{user.FirstName} {user.LastName} {user.BirthDate} {user.IDNo} {user.Email} {user.Password}";
                prodBuilder.Produce("StartRegistrationLast", new Message<Null, string> { Value = userInfos },handler);
                prodBuilder.Flush(TimeSpan.FromSeconds(10));
            }


        }
    }
}
 