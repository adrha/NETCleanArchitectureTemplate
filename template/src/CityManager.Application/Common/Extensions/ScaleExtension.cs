namespace CityManager.Application.Common.Extensions;

public static class ScaleExtension
{
    /// <summary>
    /// Calculate a scaled value as an extension.
    /// Formula: http://www.statistics4u.com/fundstat_eng/cc_scaling.html
    /// </summary>
    /// <param name="x">value to scale</param>
    /// <param name="dMin">source-value lower range value</param>
    /// <param name="dMax">source-value upper range value</param>
    /// <param name="rMin">scaled value lower range value</param>
    /// <param name="rMax">scaled value upper range value</param>
    /// <returns>scaled value</returns>
    /// <exception cref="ArgumentException">If scaling-parameters are invalid</exception>
    /// <exception cref="DivideByZeroException"></exception>
    public static double Scale(this double x, double dMin, double dMax, double rMin, double rMax)
    {
        if (rMin == rMax)
        {
            throw new ArgumentException($"{nameof(rMin)} can't be equal to {nameof(rMax)} for scaling");
        }

        if (dMin == dMax)
        {
            throw new ArgumentException($"{nameof(dMin)} can't be equal to {nameof(dMax)} for scaling");
        }

        if (x < dMin || x > dMax)
        {
            throw new ArgumentException($"{nameof(x)} does not fall in range of {nameof(dMin)} and {nameof(dMax)}. X={x} dMin={dMin} dMax={dMax}");
        }

        return x * ((rMax - rMin) / (dMax - dMin)) + (rMin * dMax - rMax * dMin) / (dMax - dMin);
    }

}