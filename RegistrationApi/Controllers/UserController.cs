using DomainLayer.Entities;
using DomainLayer.EntityValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.KafkaClient;
using RegistrationApi.Mediator;
using RegistrationApi.Mediator.Commands;
using ServiceLayer.AbstractServices;
using ServiceLayer.ConcreteServices;

namespace RegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMediator mediator;

        public UserController(IUserService userService, IMediator mediator)
        {
            this.userService = userService;
            this.mediator = mediator;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            UserValidator validations = new UserValidator();
            var result = validations.Validate(user);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine("Property " + item.PropertyName + " failed validation. Error was: " + item.ErrorMessage);
                }
            }

            Producer producer = new Producer();
            producer.ReadMessage(user);
            Consumer consumer = new Consumer();
            User _user = consumer.ConvertMessageToUser();
            var command = new RegisterUserCommand(_user);
            mediator.Send(command);
            return Ok(command);

        }
    }
}
