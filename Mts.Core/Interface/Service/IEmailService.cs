using Mts.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mts.Core.Interface.Service
{
    public interface IEmailService
    {
        void Send(EmailBody emailBody);
    }
}
