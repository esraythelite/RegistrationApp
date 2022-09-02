using DomainLayer.Entities;
using MediatR;

namespace RegistrationApi.Mediator.Commands
{
    public class RegisterUserCommand:IRequest<User>
    {

    }
}
