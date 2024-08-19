namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs.Portfolio.Project
{
    public record CreateProjectDto
    {
        public required string ProjectCode { get; set; }

        public required string Name { get; set; }

        public decimal ProjectBudget { get; set; }

        public DateTime StartDate { get; set; }

        public int ResponsibleOfficeId { get; set; }
    }
}
