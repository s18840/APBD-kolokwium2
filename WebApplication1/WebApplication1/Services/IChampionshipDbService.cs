using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IChampionshipDbService
    {
        public GetChampionshipTeamsResponse GetTeams(int id);
        public void AddPlayerToTeam(int id, AddPlayerRequest request);
    }
}
