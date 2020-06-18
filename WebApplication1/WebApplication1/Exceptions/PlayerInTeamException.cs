using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Exceptions
{
    public class PlayerInTeamException :Exception
    {
        public PlayerInTeamException(string msg) : base(msg)
        {
        }
        public PlayerInTeamException(string msg, Exception e) : base(msg, e)
        {
        }
        public PlayerInTeamException()
        {
        }
    }
}
