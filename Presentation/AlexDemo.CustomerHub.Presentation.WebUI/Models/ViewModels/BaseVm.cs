using System.ComponentModel.DataAnnotations;

namespace AlexDemo.CustomerHub.Presentation.WebUI.Models.ViewModels
{
    public abstract class BaseVm<T>
    {
        [Required]
        public T Id { get; set; }
    }
}
