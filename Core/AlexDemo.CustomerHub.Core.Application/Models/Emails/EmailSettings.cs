using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexDemo.CustomerHub.Core.Application.Enums;

namespace AlexDemo.CustomerHub.Core.Application.Models.Emails
{
    public sealed class EmailSettings
    {
        public string ApiKey { get; set; }

        public string FromAddress { get; set; }

        public string FromName { get; set; }

        public Priority Priority { get; set; }
    }
}
