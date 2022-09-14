using DomainLayer.Entities;
using MediatR;

namespace RegistrationApi.Mediator.Commands
{
    public class RegisterUserCommand:IRequest<User>
    {
        public User User { get; set; }

        public RegisterUserCommand(User user)
        {
            this.User = user;     
        }
    }
}
