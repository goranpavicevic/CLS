﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AuthorizationException
    {
        private string message;

        public string Message { get => message; set => message = value; }
    }
}
