using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace NASA.API.Tests.Steps
{
    [Binding]
    public class SharedSteps
    {
        private readonly ScenarioContext _context;

        public SharedSteps(ScenarioContext context) 
        {
            _context = context;
        }

        [Then(@"I should receive a Bad Request response")]
        public void ThenIShouldReceiveABadRequestResponse()
        {
            var response = (RestResponse)_context["ApiResponse"];
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest), "Expected 400 Bad Request.");
        }
    }
}
