﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class NoPlayerException : Exception
    {
        public NoPlayerException(string msg) : base(msg)
        {
        }
        public NoPlayerException(string msg, Exception e) : base(msg, e)
        {
        }
        public NoPlayerException()
        {
        }
    }
}
