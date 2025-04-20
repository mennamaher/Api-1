﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class RegisterValidationException:Exception
    {
        public IEnumerable<string> Errors { get; set; }
        public RegisterValidationException(IEnumerable<string> error) : base("validation error")
        {
            Errors=error;
        }
    }
}
