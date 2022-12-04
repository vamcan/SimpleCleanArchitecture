using System.Text;
using SimpleCleanArchitecture.WebApp;
using SimpleCleanArchitecture.WebApp.ApiModels;

namespace SimpleCleanArchitecture.FunctionalTests.Order
{
    public class AddOrder : IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _client;

        public AddOrder(CustomWebApplicationFactory<WebMarker> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task AddOrderShouldAddOrderInDatabase()
        {
            var description = "TestDescription";
            var request = new CreateOrderRequest()
            {
                Email = "reza@gmail.com",
                Description = description,
                Title = "Title"
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
            var res =await 
                (await _client.PostAsync("api/Order", data)).Content.ReadAsStringAsync(); 
            Assert.NotNull(res);
            Assert.Contains("TestDescription", res);
        }
    }
}
