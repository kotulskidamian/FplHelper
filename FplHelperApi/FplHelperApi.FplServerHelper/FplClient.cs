using FplHelperApi.Models;
using FplHelperApi.Utils;
using System.Net.Http.Json;

namespace FplHelperApi
{
    public class FplClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _httpClient;

        public FplClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            SetupClient();
        }

        private void SetupClient()
        {
            _httpClient = _clientFactory.CreateClient(Constants.FPL_CLIENT);
        }

        public async Task<RootFplResponse> GetFplRootAsync()
        {
            var uriBuilder = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = Constants.Enpoints.BOOTSTRAP_STATIC
            };

            var request = new HttpRequestMessage
            {
                RequestUri = uriBuilder.Uri,
                Method = HttpMethod.Get,
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var root = await response.Content.ReadFromJsonAsync<RootFplResponse>();

            return root;
        }
    }
}
