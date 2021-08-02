using System;
public class Calc 
{
    /// <summary>
    /// 魅力度と距離によって都道府県移動確率を計算します
    /// </summary>
    /// <param name="attractiveness">魅力度</param>
    /// <param name="distance">距離</param>
    /// <returns>都道府県移動確率を返します</returns>
    public double CalcProbability(int attractiveness, double distance)
    {
        const double maxDistance = 580;
        const double weight = 0.25;
        double a  = 0.15 * attractiveness - 0.45;
        double d = 1 - (Math.Log10(distance) / Math.Log10(maxDistance)) + weight * (1.0 - distance / maxDistance);

        return (d + a) < 0 ? 0 : (d + a) > 1 ? 1 : (d + a);
    }
    /// <summary>
    /// 人口割合から人口を計算します
    /// </summary>
    /// <param name="probability">都道府県の人口割合</param>
    /// <returns>人口を返します</returns>
    public int ProbabilityToPopulation(float probability)
    {
        const int JAPAN_POPULATION = 126500;
        return (int)(JAPAN_POPULATION * probability);
    }

}
