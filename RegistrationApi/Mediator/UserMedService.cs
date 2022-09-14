using Confluent.Kafka;
using MediatR;
using RegistrationApi.BaseClient;
using ServiceLayer.AbstractServices;
using ServiceLayer.ConcreteServices;

namespace RegistrationApi.Mediator
{
    public class UserMedService
    {
        private readonly IUserService service;

        public UserMedService(IUserService service)
        {
            this.service = service;
        }
    }
}
