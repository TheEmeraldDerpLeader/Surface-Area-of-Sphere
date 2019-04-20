using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurfaceAreaOfSphere
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculater c = new Calculater();
            c.Setup();
        }
    }
    public class Calculater
    {
        //Due to rounding and other inconsistencies, larger numbers will actually decrease the result. However, some large numbers (30,44, and 90 are three) avoid this
        int segments = 0;

        public void Setup()
        {
            while (true)
            {
                Console.WriteLine("Input a number for the next calculation. Press space to enter.");
                bool abool = true;
                segments = 0;
                while (abool)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    if (key.Key == ConsoleKey.Backspace && segments > 0)
                    {
                        string segmentString = segments.ToString();
                        segmentString.Remove(segmentString.Length - 1, 1);
                        segments = int.Parse(segmentString);
                        Console.Write("\b \b");
                    }
                    switch (key.Key)
                    {
                        case ConsoleKey.D0:
                            segments *= 10;
                            segments += 0;
                            Console.Write(0);
                            break;
                        case ConsoleKey.D1:
                            segments *= 10;
                            segments += 1;
                            Console.Write(1);
                            break;
                        case ConsoleKey.D2:
                            segments *= 10;
                            segments += 2;
                            Console.Write(2);
                            break;
                        case ConsoleKey.D3:
                            segments *= 10;
                            segments += 3;
                            Console.Write(3);
                            break;
                        case ConsoleKey.D4:
                            segments *= 10;
                            segments += 4;
                            Console.Write(4);
                            break;
                        case ConsoleKey.D5:
                            segments *= 10;
                            segments += 5;
                            Console.Write(5);
                            break;
                        case ConsoleKey.D6:
                            segments *= 10;
                            segments += 6;
                            Console.Write(6);
                            break;
                        case ConsoleKey.D7:
                            segments *= 10;
                            segments += 7;
                            Console.Write(7);
                            break;
                        case ConsoleKey.D8:
                            segments *= 10;
                            segments += 8;
                            Console.Write(8);
                            break;
                        case ConsoleKey.D9:
                            segments *= 10;
                            segments += 9;
                            Console.Write(9);
                            break;
                    }
                }
                Console.WriteLine();
                Calculate();
                System.GC.Collect();
            }
        }

        public void Calculate()
        {
            if (segments < 1)
                segments = 1;
            if (segments > 100000)
            {
                segments = 100000;
                Console.WriteLine("You're welcome for not undergoing a pointlessly long operation");
            }

            int recursion = 0; //denoted with r
            double[] miniApproxQuarts = new double[segments + 1]; //denoted with "b" then "r" subscript
            double[] miniRadii = new double[segments + 1]; //denoted with "a" then "r" subscript
            double[] nextbPlusb = new double[segments];
            double[] nextbMinusb = new double[segments];
            double[] areas = new double[segments];


            double bSquared = 2d - (2d * Math.Cos(Deg2Rad(90d / segments)));
            miniApproxQuarts[0] = 0;
            miniApproxQuarts[segments] = Math.Sqrt(bSquared);
            miniRadii[0] = 0;
            miniRadii[segments] = 1;

            for (recursion = 1; recursion < segments; recursion++)
            {
                miniRadii[recursion] = Math.Sin(Deg2Rad((90d/segments)*recursion)); 
            }
            for (recursion = 1; recursion < segments; recursion++)
            {
                double aSquaredMult2 = Math.Pow(miniRadii[recursion],2)*2d;
                miniApproxQuarts[recursion] = Math.Sqrt(aSquaredMult2 - (aSquaredMult2*Math.Cos(Deg2Rad(90/segments))));
            }
            for (recursion = 0; recursion < segments; recursion++)
            {
                nextbPlusb[recursion] = miniApproxQuarts[recursion+1] + miniApproxQuarts[recursion];
            }
            for (recursion = 0; recursion < segments; recursion++)
            {
                nextbMinusb[recursion] = miniApproxQuarts[recursion+1] - miniApproxQuarts[recursion];
            }

            //This loop calculates the area of a trapazoid strip using the values above. A circle can be represented by trapazoids where each strip has their own identical trapazoids
            for (recursion = 0; recursion < segments; recursion++)
            {
                areas[recursion] = ((double)segments / 2d) * nextbPlusb[recursion] * Math.Sqrt(bSquared - (Math.Pow(nextbMinusb[recursion],2)/4d));
            }

            double surfaceArea = 0;
            for (recursion = 0; recursion < segments; recursion++)
            {
                surfaceArea += areas[recursion];
            }
            surfaceArea *= 8;

            for (recursion = 0; recursion <= segments; recursion++)
            {
                Console.WriteLine("b" + recursion.ToString() + " = " + miniApproxQuarts[recursion].ToString());
                Console.WriteLine("a" + recursion.ToString() + " = " + miniRadii[recursion].ToString());
            }
            Console.WriteLine();
            for (recursion = 0; recursion < segments; recursion++)
            {
                Console.WriteLine("Area" + recursion.ToString() + " = " + areas[recursion].ToString());
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The surface area calculated is " + surfaceArea.ToString());
            Console.WriteLine("Which is approximately " + (surfaceArea/Math.PI).ToString() + " * PI");
            Console.WriteLine();
        }
        public double Deg2Rad(double degrees)
        {
            return (degrees / 180) * Math.PI;
        }
    }
}
