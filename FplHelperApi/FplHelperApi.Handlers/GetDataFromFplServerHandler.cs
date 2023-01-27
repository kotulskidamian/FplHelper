using FplHelperApi.Models;
using System.Formats.Asn1;
using System.Net.Http;

namespace FplHelperApi.Handlers
{
    public class GetDataFromFplServerHandler 
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetDataFromFplServerHandler(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<RootFplResponse> Handle()
        {
            var fplClient = new FplClient(_clientFactory);
            var result = await fplClient.GetFplRootAsync();

            return result; 
        }
    }
}