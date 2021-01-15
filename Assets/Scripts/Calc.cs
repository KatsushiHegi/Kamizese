using System;
public class Calc 
{
    const float maxDistance = 580;
    const float weight = 0.25f;
    public double CalcProbability(int attractiveness, float distance)
    {
        double a  = 0.15 * attractiveness - 0.45;
        double d = 1 - (Math.Log(distance, 2) / Math.Log(maxDistance, 2) + weight * (1 - distance / maxDistance));

        return (d + a) < 0 ? 0 : (d + a) > 1 ? 1 : (d + a);
    }
}
