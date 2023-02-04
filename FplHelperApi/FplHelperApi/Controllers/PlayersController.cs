using AutoMapper;
using FplHelperApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public PlayersController(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetPlayers()
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var resultPlayers = _mapper.Map<IEnumerable<PlayerReadDto>>(root.Players);

            return Ok(resultPlayers);
        }  
    }
}
