using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PlayerTeam
    {
        public int IdPlayer { get; set; }
        public int IdTeam { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }
        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}
