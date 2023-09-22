using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CityManager.FunctionalTests;

public class ControllerTestBase : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _testWebApplicationFactory;
    
    public ControllerTestBase(TestWebApplicationFactory<Program> testWebApplicationFactory)
    {
        _testWebApplicationFactory = testWebApplicationFactory;
    } 
    
    protected HttpClient GenerateHttpClient()
    {
        HttpClient httpClient = _testWebApplicationFactory.CreateClient();
        return httpClient;
    }
}