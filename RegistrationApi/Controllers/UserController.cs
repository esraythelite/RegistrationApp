using DomainLayer.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.KafkaClient;
using RegistrationApi.Mediator.Commands;
using ServiceLayer.ConcreteServices;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        private readonly IMediator mediator;

        public UserController(UserService userService, IMediator mediator)
        {
            this.userService = userService;
            this.mediator = mediator;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            Producer producer = new Producer();
            producer.ReadMessage(user);
            var command = new RegisterUserCommand();
            mediator.Send(command);
            return Ok();
        }
    }
}
