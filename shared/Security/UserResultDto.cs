﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Security
{
    public record UserResultDto(string DisplayName, string Email, string Token)
    {

    }
}
