using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EfChampionshipDbService :IChampionshipDbService
    {
        private readonly s18840DbContext _context;

        public EfChampionshipDbService(s18840DbContext context)
        {
            _context = context;
        }

        public GetChampionshipTeamsResponse GetTeams(int championshipId)
        {
            var championshipExists = _context.Championships
                .Any(x => x.IdChampionship.Equals(championshipId));
            if (!championshipExists)
            {
                throw new NoChampionshipException($"Did not found this championship");
            }

            var teamsInGivenChampionship = _context.ChampionshipTeams
                .Where(x => x.IdChampionship.Equals(championshipId))
                .OrderByDescending(x => x.Score)
                .ToList();

            Dictionary<string, float> teamResults = new Dictionary<string, float>();
            foreach (var team in teamsInGivenChampionship)
            {
                teamResults.Add(
                    _context.Teams.Single(x => x.IdTeam.Equals(team.IdTeam)).TeamName,
                    team.Score
                );
            }

            return new GetChampionshipTeamsResponse
            {
                IdChampionship = championshipId,
                Score = teamResults
            };
        }

        public void AddPlayerToTeam(int teamId, AddPlayerRequest request)
        {
            var maxAge = _context.Teams
                .Single(x => x.IdTeam.Equals(teamId))
                .MaxAge;
            var playerAge = DateTime.Now.Year - request.BirthDate.Year;
            if (playerAge > maxAge)
            {
                throw new ToOldPlayerException($"This player is to old");
            }

            var playerExists = _context.Players
                .Any(x => x.FirstName.Equals(request.FirstName) && x.LastName.Equals(request.LastName));
            if (!playerExists)
            {
                throw new NoPlayerException($"Did not found this player");
            }

            var playerId = _context.Players
                .Single(x => x.FirstName.Equals(request.FirstName) && x.LastName.Equals(request.LastName))
                .IdPlayer;

            var playerAlreadyInTheTeam = _context.PlayerTeams
                .Any(x => x.IdPlayer.Equals(playerId) && x.IdTeam.Equals(teamId));
            if (playerAlreadyInTheTeam)
            {
                throw new PlayerInTeamException($"This player is already in team");
            }

            _context.PlayerTeams.Add(new PlayerTeam
            {
                IdTeam = teamId,
                IdPlayer = playerId,
                NumOnShirt = request.NumOnShirt,
                Comment = request.Comment
            }
            );
            _context.SaveChanges();
        }
    }
}
