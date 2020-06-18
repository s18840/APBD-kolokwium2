using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ChampionshipTeam
    {
        public int IdTeam { get; set; }
        public int IdChampionship { get; set; }
        public float Score { get; set; }
        public Championship Championship { get; set; }
        public Team Team { get; set; }
    }
}
