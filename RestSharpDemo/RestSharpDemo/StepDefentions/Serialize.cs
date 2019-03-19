using RestSharp.Serialization.Json;
using RestSharpDemo.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpDemo.StepDefentions
{
    [Binding]
    public sealed class Serialize
    {
        private static Create new_employee;
        string JsonBody;

        [When(@"I Create a request body with the following values")]
        public void WhenICreateARequestBodyWithTheFollowingValues(Table table)
        {
            new_employee = table.CreateInstance<Create>();
            var obj = new Create()
            {
                name = new_employee.name,
                salary = new_employee.salary,
                age = new_employee.age
            };
            JsonSerializer serializer = new JsonSerializer();
            JsonBody = serializer.Serialize(obj);
        }

        [When(@"Add the serialized body to the API request")]
        public void WhenAddTheSerializedBodyToTheAPIRequest()
        {
            SharedSteps.request.AddJsonBody(JsonBody);
        }

    }
}
