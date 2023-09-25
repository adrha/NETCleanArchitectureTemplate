using CityManager.Application.Common.Extensions;

namespace CityManager.UnitTests.Extensions;

public class ScaleExtensionTests
{
    [Theory]
    [InlineData(5, 0, 10, 0, 180, 90)]
    [InlineData(1, 0, 5, 0, 100, 20)]
    [InlineData(10, 0, 10, 0, 2, 2)]
    public void Scale_ValidScalingData_ScaledValue(double x, double dMin, double dMax, double rMin, double rMax, double y)
    {
        double scaled = x.Scale(dMin, dMax, rMin, rMax);
        Assert.Equal(y, scaled);
    }

    [Theory]
    [InlineData(50, 0, 10, 0, 100)]
    [InlineData(-50, 0, 10, 0, 100)]
    [InlineData(10, 20, 20, 0, 100)]
    [InlineData(10, 20, 20, 5, 5)]
    public void Scale_InvalidScalingData_ArgumentException(double x, double dMin, double dMax, double rMin, double rMax)
    {
        Assert.Throws<ArgumentException>(() => x.Scale(dMin, dMax, rMin, rMax));
    }

}