using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CityManager.FunctionalTests.Controllers;

public class ActivityControllerTests : ControllerTestBase
{
    public ActivityControllerTests(TestWebApplicationFactory<Program> testWebApplicationFactory) : base(testWebApplicationFactory)
    {
    }
}