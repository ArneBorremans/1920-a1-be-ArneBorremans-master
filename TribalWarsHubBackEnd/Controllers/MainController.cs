using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TribalWarsHubBackEnd.Data;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;

        private readonly IVillageRepository _villageRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITribeRepository _tribeRepository;

        public MainController(IVillageRepository context, IPlayerRepository playerContext, ITribeRepository tribeContext)
        {
            _villageRepository = context;
            _playerRepository = playerContext;
            _tribeRepository = tribeContext;
        }

        [HttpGet]
        public async Task GenerateMapAsync()
        {
            await TWMapGenerator.GenerateMap(_villageRepository.GetAll().ToList(), "mapW111.png");
        }

        [HttpGet("/topPlayers")]
        public async Task GenerateTopPlayersMapAsync()
        {
            Player[] players = new Player[5];

            for(var i = 1; i < 6; i++)
            {
                players[i-1] = (_playerRepository.GetByRank(107, i));
            }
            
            await TWMapGenerator.GenerateTopPlayersMap(players.ToList(), _villageRepository.GetAll().ToList(), "topPlayersMapW111.png");
        }
    }
}
