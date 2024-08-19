using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDemo.CustomerHub.Core.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.DTOs
{
    public interface IBaseStatusDto
    {
        Status Status { get; set; }
    }
}
