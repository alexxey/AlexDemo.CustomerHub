namespace AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands
{
    public record DeleteEntityCommand<T> : IRequest<Unit>
    {
        public T Id { get; set; }

        /// <summary>
        /// Id of the person who performed this change
        /// </summary>
        public string Actor { get; set; }
    }
}
