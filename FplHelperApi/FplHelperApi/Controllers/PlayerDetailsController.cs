using AutoMapper;
using FplHelperApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerDetailsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public PlayerDetailsController(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDetailsReadDto>> GetPlayerDetailsByIdAsync(int id)
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var player = root.Players.FirstOrDefault(p => p.Id == id);

            var resultPlayer = _mapper.Map<PlayerDetailsReadDto>(player);

            return Ok(resultPlayer);
        }
    }
}
