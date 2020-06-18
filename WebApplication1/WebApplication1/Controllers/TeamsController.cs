using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api")]
    public class TeamsController : ControllerBase
    {
        private readonly IChampionshipDbService dbService;

        public TeamsController(IChampionshipDbService service)
        {
            dbService = service;
        }

        [HttpGet]
        [Route("championship/{championshipId}/teams")]
        public IActionResult GetTeams(int championshipId)
        {
            IActionResult response;
            try
            {
                //response = Ok(dbService.GetTeams(championshipId));
                return Ok(dbService.GetTeams(championshipId));
            }
            catch (NoChampionshipException e)
            {
                //response = NotFound($"No championship\n{e.Message}");
                return NotFound($"No championship\n{e.Message}");
            }
            return response;
        }

        [HttpPost]
        [Route("teams/{teamId}/players")]
        public IActionResult AddPlayerToTeam(int teamId, AddPlayerRequest request)
        {
            IActionResult response;
            try
            {
                dbService.AddPlayerToTeam(teamId, request);
                response = Created($"Added player", request);
            }
            catch (ToOldPlayerException e)
            {
                response = BadRequest($"Too old player\n{e.Message}");
            }
            catch (NoPlayerException e)
            {
                response = BadRequest($"No player\n{e.Message}");
            }
            catch (PlayerInTeamException e)
            {
                response = BadRequest($"Player in team\n{e.Message}");
            }
            return response;
        }

    }
}