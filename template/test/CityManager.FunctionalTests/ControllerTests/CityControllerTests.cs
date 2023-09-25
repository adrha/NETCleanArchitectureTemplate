using System.Net;
using CityManager.Api.Contracts;
using CityManager.Api.Contracts.OutputModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace CityManager.FunctionalTests.ControllerTests;

public class CityControllerTests : ControllerTestBase
{
    public CityControllerTests(TestWebApplicationFactory<Program> testWebApplicationFactory) : base(testWebApplicationFactory)
    {
    }

    [Fact]
    public async Task GetCities_DefaultRequest_ReturnsCitiesWithCodeOk()
    {
        // Arrange
        HttpClient httpClient = GenerateHttpClient();
        
        // Act
        HttpResponseMessage responseMessage = await httpClient.GetAsync(Routes.V1.Cities.CitiesRoute);
        string body = await responseMessage.Content.ReadAsStringAsync();
        List<CityOutputModel>? responseViewModel = JsonConvert.DeserializeObject<List<CityOutputModel>>(body);
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.NotNull(responseViewModel);
        Assert.NotEmpty(responseViewModel);
    }
}