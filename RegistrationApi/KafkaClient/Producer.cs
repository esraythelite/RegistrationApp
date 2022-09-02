using Confluent.Kafka;
using DomainLayer.Entities;
using RegistrationApi.BaseClient;

namespace RegistrationApi.KafkaClient
{
    public class Producer:IBaseProducer
    {
        ProducerConfig pconf = new ProducerConfig { BootstrapServers = "localhost:9092" };
        List<User> RegistrationList = new List<User>();

        public void ReadMessage(User user)
        {
            using (var prodBuilder = new ProducerBuilder<Null, string>(pconf).Build())
            {
                string userInfos = user.Id + " " + user.FirstName + " " + user.LastName + " " + user.Email + " " + user.Password;
                prodBuilder.Produce("Registration-topic", new Message<Null, string> { Value = userInfos });
                RegistrationList.Add(user);
                prodBuilder.Flush(TimeSpan.FromSeconds(10));
            }
        }
    }
}
