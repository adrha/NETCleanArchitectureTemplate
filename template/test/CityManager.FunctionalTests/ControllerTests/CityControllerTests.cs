using System.Net;
using System.Text;
using CityManager.Api.Contracts;
using CityManager.Api.Contracts.Enum;
using CityManager.Api.Contracts.InputModel;
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

    [Fact]
    public async Task CreateCity_CityCreationRequest_ReturnsCreatedCityWithCreatedCode()
    {
        // Arrange
        HttpClient httpClient = GenerateHttpClient();
        CityInputModel inputModel = new CityInputModel() { Name = "TestCity", CityType = CityType.NormalCity, CantonId = 99, BfsId = 11};
        string jsonContent = JsonConvert.SerializeObject(inputModel);
        StringContent postData = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        // Act
        HttpResponseMessage responseMessage = await httpClient.PostAsync(Routes.V1.Cities.CitiesRoute, postData);
        var body = await responseMessage.Content.ReadAsStringAsync();
        CityOutputModel? responseViewModel = JsonConvert.DeserializeObject<CityOutputModel>(body);
        
        // Assert
        Assert.Equal(HttpStatusCode.Created, responseMessage.StatusCode);
        Assert.NotNull(responseViewModel);
        Assert.Equal(inputModel.Name, responseViewModel.Name);
        Assert.Equal(inputModel.CityType, responseViewModel.CityType);
        Assert.Equal(inputModel.BfsId, responseViewModel.BfsId);
        Assert.Equal(inputModel.CantonId, responseViewModel.CantonId);
    }

    [Fact]
    public async Task ChangeCity_CityChangeRequest_ReturnsUpdatedCityWithOkCode()
    {
        // Arrange
        HttpClient httpClient = GenerateHttpClient();
        CityInputModel inputModel = new CityInputModel() { Name = "Zurich (changed)", CityType = CityType.SpecialCity, CantonId = 123, BfsId = 999};
        string jsonContent = JsonConvert.SerializeObject(inputModel);
        StringContent postData = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        // Act
        HttpResponseMessage responseMessage = await httpClient.PutAsync(Routes.V1.Cities.CityRoute.Replace("{id}", TestDataConst.ZurichCityGuid), postData);
        var body = await responseMessage.Content.ReadAsStringAsync();
        CityOutputModel? responseViewModel = JsonConvert.DeserializeObject<CityOutputModel>(body);
        
        // Assert
        Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        Assert.NotNull(responseViewModel);
        Assert.Equal(Guid.Parse(TestDataConst.ZurichCityGuid), responseViewModel.Id);
        Assert.Equal(inputModel.Name, responseViewModel.Name);
        Assert.Equal(inputModel.CityType, responseViewModel.CityType);
        Assert.Equal(inputModel.BfsId, responseViewModel.BfsId);
        Assert.Equal(inputModel.CantonId, responseViewModel.CantonId);
    }
}