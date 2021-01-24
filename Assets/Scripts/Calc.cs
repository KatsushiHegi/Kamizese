using System;
public class Calc 
{
    public double CalcProbability(int attractiveness, double distance)
    {
        const double maxDistance = 580;
        const double weight = 0.25;
        double a  = 0.15 * attractiveness - 0.45;
        double d = 1 - (Math.Log10(distance) / Math.Log10(maxDistance)) + weight * (1.0 - distance / maxDistance);

        return (d + a) < 0 ? 0 : (d + a) > 1 ? 1 : (d + a);
    }
    public double CalcDistanceProb(double distance)
    {
        const double maxDistance = 580;
        const double weight = 0.25;
        double d = 1 - (Math.Log10(distance) / Math.Log10(maxDistance)) + weight * (1.0 - distance / maxDistance);
        return d < 0 ? 0 : d > 1 ? 1 : d;
    }
    public int ProbabilityToPopulation(float probability)
    {
        const int JAPAN_POPULATION = 126500;
        return (int)(JAPAN_POPULATION * probability);
    }

}
