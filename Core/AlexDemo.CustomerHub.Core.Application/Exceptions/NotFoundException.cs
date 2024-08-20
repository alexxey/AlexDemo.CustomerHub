using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDemo.CustomerHub.Core.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string entityName, object key) : base($"{entityName}, {key} is not found")
        {
            
        }
    }
}
