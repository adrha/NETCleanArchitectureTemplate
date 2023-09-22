using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CityManager.FunctionalTests.ControllerTests;

public class ActivityControllerTests : ControllerTestBase
{
    public ActivityControllerTests(TestWebApplicationFactory<Program> testWebApplicationFactory) : base(testWebApplicationFactory)
    {
    }
}