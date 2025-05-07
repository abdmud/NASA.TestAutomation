using RestSharp;
using System.Threading.Tasks;

namespace NASA.API.Tests.Client
{
    public class DonkiApiClient
    {
        private readonly RestClient _client;
        private readonly string _apiKey;

        public DonkiApiClient(string apiKey)
        {
            _apiKey = apiKey;
            _client = new RestClient("https://api.nasa.gov/DONKI/");
        }

        public async Task<RestResponse> GetEndpointDataAsync(string endpoint, string startDate, string endDate)
        {
            var request = new RestRequest(endpoint)
                .AddQueryParameter("startDate", startDate)
                .AddQueryParameter("endDate", endDate)
                .AddQueryParameter("api_key", _apiKey);

            return await _client.ExecuteGetAsync(request);
        }
    }
}
