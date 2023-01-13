using AutoMapper;
using FplHelperApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsControllers : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public PositionsControllers(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionReadDto>>> GetPositions()
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var resultPositions = _mapper.Map<IEnumerable<PositionReadDto>>(root.Positions);

            return Ok(resultPositions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionReadDto>> GetPositionById(int id)
        {
            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var position = root.Positions.FirstOrDefault(p => p.Id == id);

            var resultPosition = _mapper.Map<PositionReadDto>(position);

            return Ok(resultPosition);
        }
    }
}
