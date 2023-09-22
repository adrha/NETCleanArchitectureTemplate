using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CityManager.FunctionalTests.ControllerTests;

public class CityControllerTests : ControllerTestBase
{
    public CityControllerTests(TestWebApplicationFactory<Program> testWebApplicationFactory) : base(testWebApplicationFactory)
    {
    }
}