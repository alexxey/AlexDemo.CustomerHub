using FluentValidation.Results;

namespace AlexDemo.CustomerHub.Core.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = [];

        public ValidationException(ValidationResult validationResult)
        {
            foreach (var validationResultError in validationResult.Errors)
            {
                var errorCode = validationResultError.ErrorCode;

                // todo alex: convert error into localized message
                Errors.Add(validationResultError.ErrorMessage);
            }
        }
    }
}
