using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexDemo.CustomerHub.Core.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string code) : base(code)
        {
            
        }
    }
}
