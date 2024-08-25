using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Actions.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public CreateUserDto CreateDto { get; set; }
    }
}
