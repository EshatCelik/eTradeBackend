﻿using eTradeBackend.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Application.Features.Commands.AppUser.GoogleLoginV2
{
    public class GoogleLoginV2CommandResponse
    {
        public Token? Token { get; set; }
    }
}
