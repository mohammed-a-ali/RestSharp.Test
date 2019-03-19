using FluentAssertions;
using RestSharp;
using System.Configuration;
using TechTalk.SpecFlow;

namespace RestSharpDemo.StepDefentions
{
    [Binding]
    public sealed class SharedSteps
    {
        public static RestClient api = new RestClient(ConfigurationManager.AppSettings["RestAPI"]);
        public static RestRequest request;
        public static IRestResponse apiresult;

        [Given(@"Create Request ""(.*)"" with ""(.*)"" method")]
        public void GivenCreateRequestWithMethod(string _request, Method _method)
        {
            request = new RestRequest(_request, _method);
            request.RequestFormat = DataFormat.Json;
        }

        [When(@"Create URL segment for ""(.*)"" with parameter ""(.*)""")]
        public void WhenCreateURLSegmentForWithParameter(string _segment, int _parameter)
        {
            request.AddUrlSegment(_segment, _parameter);
        }

        [When(@"Execute API")]
        public void WhenExecuteAPI()
        {
            apiresult = api.Execute(request);
        }

        [Then(@"returned status code will be ""(.*)""")]
        public void ThenReturnedStatusCodeWillBe(int _status)
        {
            var code = apiresult.StatusCode;
            code.Should().Be(_status);
        }

    }
}
