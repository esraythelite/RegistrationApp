using Confluent.Kafka;
using DomainLayer.Entities;
using RegistrationApi.BaseClient;

namespace RegistrationApi.KafkaClient
{
    public class Consumer:IBaseConsumer
    {
        ConsumerConfig conf = new ConsumerConfig
        {
            GroupId = "test-consumer-group",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        public string WriteMessage()
        {
            using (var c = new ConsumerBuilder<Ignore, string>(conf).Build())
            {
                c.Subscribe("Registration-topic");

                CancellationTokenSource cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume(cts.Token);
                            return cr.Message.Value ;
                        }
                        catch (ConsumeException e)
                        {
                            return $"Error occured: {e.Error.Reason}";
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {                    
                    c.Close();
                    return ex.Message;
                }
            }
        }
    }
}
