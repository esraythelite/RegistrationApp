using DomainLayer.Entities;
using MediatR;
using RegistrationApi.KafkaClient;
using RepositoryLayer.ConcreteRepositories;
using ServiceLayer.ConcreteServices;

namespace RegistrationApi.Mediator.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly UserRepository service;

        public RegisterUserCommandHandler(UserRepository service)
        {
            this.service = service;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            Consumer consumer = new Consumer();

            string[] messages = consumer.WriteMessage().Split(" ");

            User user = new User() { Id = Convert.ToInt32(messages[0]), FirstName = messages[1], LastName = messages[2], Email = messages[3], Password = messages[4] };

            service.Add(user);

            return await Task.FromResult(user);
        }
    }
}
