using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Actions.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserDto UpdateDto { get; set; }
    }
}