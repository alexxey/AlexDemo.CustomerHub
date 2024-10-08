﻿using AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project;

namespace AlexDemo.CustomerHub.Core.Application.UseCases.Portfolio.Project.Actions.Queries
{
    public class GetProjectDetailsRequest : IRequest<ProjectDetailsDto>
    {
        public int Id { get; set; }
    }
}
