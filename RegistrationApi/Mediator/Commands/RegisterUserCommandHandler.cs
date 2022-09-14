using DomainLayer.Entities;
using MediatR;
using ServiceLayer.AbstractServices;

namespace RegistrationApi.Mediator.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {
        private readonly IMediator mediator;
        private readonly IUserService service;

        public RegisterUserCommandHandler(IMediator mediator,
            IUserService service)
        {
            this.mediator = mediator;
            this.service = service;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            service.Add(request.User);
            return await Task.FromResult(request.User);
        }
    }
}
