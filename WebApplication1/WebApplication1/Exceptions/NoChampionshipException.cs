using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class NoChampionshipException : Exception
    {
        public NoChampionshipException(string msg) : base(msg)
        {
        }
        public NoChampionshipException(string msg, Exception e) : base(msg, e)
        {
        }
        public NoChampionshipException()
        {
        }
    }
}
