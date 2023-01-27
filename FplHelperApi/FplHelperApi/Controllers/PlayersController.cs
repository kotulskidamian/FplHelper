using AutoMapper;
using FplHelperApi.Messages.Contracts;
using FplHelperApi.Messages.Contracts.GetDataFromFplServer;
using FplHelperApi.Models.Dtos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly IRequestClient<ISagaStartMessage> _sagaStartMessageRequestClient;

        public PlayersController(IHttpClientFactory clientFactory, IMapper mapper, IRequestClient<ISagaStartMessage> sagaStartMessageRequestClient)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _sagaStartMessageRequestClient = sagaStartMessageRequestClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerReadDto>>> GetPlayers()
        {
            var response = await _sagaStartMessageRequestClient.GetResponse<IGetDataFromFplServerSagaEndMsg>(new
            {
                SagaType = typeof(IGetDataFromFplServerSagaStartMsg),
                CorrelationId = Guid.NewGuid()
            });

            var root = await new FplClient(_clientFactory).GetFplRootAsync();

            var resultPlayers = _mapper.Map<IEnumerable<PlayerReadDto>>(root.Players);

            return Ok(resultPlayers);
        }
    }
}
