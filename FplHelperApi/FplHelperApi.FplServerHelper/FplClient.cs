using FplHelperApi.Models;
using FplHelperApi.Utils;
using MongoDB.Driver;
using System.Net.Http.Json;

namespace FplHelperApi
{
    public class FplClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _httpClient;

        private IMongoCollection<RootFplResponse> _fplMongoCollection;

        public FplClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            SetupClient();
            SetupMongoDbCollection();            
        }

        private void SetupClient()
        {
            _httpClient = _clientFactory.CreateClient(Constants.FPL_CLIENT);
        }
        private void SetupMongoDbCollection()
        {
            var client = new MongoClient("mongodb+srv://admin:admin@cluster0.07haif8.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("FplDatabase");
            _fplMongoCollection = database.GetCollection<RootFplResponse>("fplData");
        }

        public async Task RefreshFplRootAsync()
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

            await SaveToDatabase(root);
        }

        public async Task<RootFplResponse> GetFplRootAsync()
        {
            var result = await GetFplRootResponseFromMongoDb();
            return result;
        }

        private async Task<RootFplResponse> GetFplRootResponseFromMongoDb()
        {
            var mongoResponse = await _fplMongoCollection.FindAsync(_ => true);
            var result = await mongoResponse.FirstOrDefaultAsync();
            return result;
        }

        private async Task SaveToDatabase(RootFplResponse rootFplResponse)
        {                       
            await _fplMongoCollection.DeleteManyAsync(_ => true);

            rootFplResponse.Players = ClearUnusedPlayers(rootFplResponse.Players);

            await _fplMongoCollection.InsertOneAsync(rootFplResponse);
        }

        private IEnumerable<Player> ClearUnusedPlayers(IEnumerable<Player> players)
        {
            return players.Where(p => p.Starts > 0);
        }
    }
}
