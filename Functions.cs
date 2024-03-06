using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalCalculator
{
    internal static class Functions
    {

        internal static List<string> function = new List<string>();

        internal static Dictionary<double, double> updatePoints(double minX, double maxX, double interval)
        {
            Dictionary<double, double> points = new Dictionary<double, double>();
            points.Clear();
            for(double x = minX; x < maxX; x += interval)
            {
                points.Add(x, FunctionParser.EvaluateFunction(function, x));
            }
            return points;
        }
    }
}
