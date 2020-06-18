using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class GetChampionshipTeamsResponse
    {
        public int IdChampionship { get; set; }
        public Dictionary<string, float> Score { get; set; }
    }
}
