﻿using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Customer.User;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Customer.User.Requests.Queries
{
    public class GetUserDetailsRequest : IRequest<UserDetailsDto>
    {
        public int Id { get; set; }
    }
}
