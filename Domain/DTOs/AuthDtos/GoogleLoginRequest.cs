﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.AuthDtos
{
    public class GoogleLoginRequest
    {
        public string IdToken { get; set; } = null!;
    }
}
