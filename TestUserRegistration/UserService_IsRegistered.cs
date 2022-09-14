using DomainLayer.Entities;
using DomainLayer.EntityValidation;
using MediatR;
using RegistrationApi.KafkaClient;
using RegistrationApi.Mediator.Commands;

namespace TestUserRegistration
{
    public class UserService_IsRegistered
    {


        [Fact]
        public void IsRegistered_User_ReturnTrue()
        {
            
            User user = new User()
            {
                FirstName = "Esra",
                LastName = "Bahadır",
                BirthDate = DateTime.Now,
                IDNo = "3423423432",
                Email = "esra@mil.com",
                Password = "vL9_?5"
            };
        
            Producer producer = new Producer();

            bool result = false;
            producer.ReadMessage(user);
            Consumer consumer = new Consumer();
            User _user = consumer.ConvertMessageToUser();

            if (_user != null)
            {
                result = true;
            }
            Assert.True(result);
        }
    }
}