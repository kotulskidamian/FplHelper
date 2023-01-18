using AutoMapper;
using FplHelperApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public PlayerStatsController(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PlayerStatsReadDto>> GetPlayerStatsAsync()
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var resultPlayerStats = _mapper.Map<IEnumerable<PlayerStatsReadDto>>(root.Players);

            return Ok(resultPlayerStats);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerStatsReadDto>> GetPlayerStatsByIdAsync(int id)
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var player = root.Players.FirstOrDefault(p => p.PlayerId == id);

            var resultPlayer = _mapper.Map<PlayerStatsReadDto>(player);

            return Ok(resultPlayer);
        }
    }
}
