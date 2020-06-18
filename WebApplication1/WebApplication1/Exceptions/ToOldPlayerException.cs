using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class ToOldPlayerException : Exception
    {
        public ToOldPlayerException(string msg) : base(msg)
        {
        }
        public ToOldPlayerException(string msg, Exception e) : base(msg, e)
        {
        }
        public ToOldPlayerException()
        {
        }
    }
}
