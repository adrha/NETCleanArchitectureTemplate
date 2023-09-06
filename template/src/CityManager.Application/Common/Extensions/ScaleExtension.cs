namespace CityManager.Application.Common.Extensions;

public static class ScaleExtension
{
    public static double Scale(this double value , double min, double max, double minScale, double maxScale)
    {
      double scaled = minScale + (double)(value - min)/(max-min) * (maxScale - minScale);
      return scaled;
    }
}