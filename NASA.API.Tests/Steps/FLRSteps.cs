using NASA.API.Tests.Client;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace NASA.API.Tests.Steps
{
    [Binding]
    public class FLRSteps
    {
        private readonly ScenarioContext _context;
        private RestResponse _response;
        private readonly DonkiApiClient _apiClient;

        public FLRSteps(ScenarioContext context)
        {
            _context = context;
            _apiClient = new DonkiApiClient("w8k1sJxzaybb7r0jLbYOeJJ0Mez8aYfHqjcgIHng");
        }

        [Given(@"I call the GET FLR API with startDate ""(.*)"" and endDate ""(.*)""")]
        public async Task GivenICallTheGETFLRAPIWithStartDateAndEndDate(string startDate, string endDate)
        {
            _response = await _apiClient.GetEndpointDataAsync("FLR", startDate, endDate);
            _context["ApiResponse"] = _response;
        }

        [Then(@"I should receive a valid response with FLR data")]
        public void ThenIShouldReceiveAValidResponseWithFLRData()
        {
            Assert.That(_response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "API did not return 200 OK");

            var content = _response.Content;
            Assert.That(content, Is.Not.Null.And.Not.Empty, "API returned empty content");

            var json = JArray.Parse(content!);
            Assert.That(json.Count, Is.GreaterThan(0), "No CME data returned in the response");
        }
    }
}
