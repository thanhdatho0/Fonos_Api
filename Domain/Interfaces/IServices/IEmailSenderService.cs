﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IEmailSenderService
    {
        public Task SendEmailAsync(string email, string subjec, string htmlMessage);
    }
}
