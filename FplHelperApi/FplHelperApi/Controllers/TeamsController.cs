using AutoMapper;
using FplHelperApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public TeamsController(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamReadDto>>> GetTeams()
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var resultTeam = _mapper.Map<IEnumerable<TeamReadDto>>(root.Teams);

            return Ok(resultTeam);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamReadDto>> GeTeamById(int id)
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var team = root.Teams.FirstOrDefault(d => d.Id == id);

            var resultTeam = _mapper.Map<TeamReadDto>(team);

            return Ok(resultTeam);
        }
    }
}
