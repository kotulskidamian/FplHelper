using AutoMapper;
using FplHelperApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FplHelperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshFplDataController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public RefreshFplDataController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetRefreshFplData()
        {
            await new FplClient(_clientFactory).RefreshFplRootAsync();

            return Ok("done");
        }
    }
}
