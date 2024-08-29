namespace AlexDemo.CustomerHub.Core.Application.UseCases.Common.Actions.Commands
{
    public class DeleteEntityCommand<TKey, TResponse> : IRequest<TResponse>
    {
        public TKey Id { get; set; }

        /// <summary>
        /// Id of the person/entity who performed this change
        /// </summary>
        public string Actor { get; set; }
    }
}
