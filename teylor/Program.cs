using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandelov
{
    class Program
    {
         public static double Taylor_Arctg(double x, double eps, out int args)
        {
            if(Math.Abs(x)>=1) throw new ArgumentException("Абсолютное значение должно быть меньше 1");
            double comp;
            double sum = 0;
            int n = 0;
            do
            {
                comp = (Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1)) / (2 * n + 1);
                sum += comp;
                n++;
            } while (Math.Abs(comp)>eps);
            args = n;
            return sum;
        }
        static int Main(string[] args)
        {
            double xOrigin = 0.0;
            double xEnd;
            inputXEnd:
            Console.WriteLine("Рассчет arctg x = Σ(-1) ^ n * x ^ (2 * n +1) / (2 * n + 1) = x - x ^ 3 / 3 - x ^ 5 / 5, |x| < 1");
            Console.Write("Начальное значение: 0\nВведите конечное значение (максимум 1): ");
            try
            {
                
                xEnd = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Write("Вы ввели недопустимое значение!\n");
                goto inputXEnd;
            }
            double step = 0.01;
            int numberOfArgs;
            Console.WriteLine("Арг-т\tAtg(x)\t\tСлаг.");

            for (double i = xOrigin; i < xEnd; i += step)
            {
                Console.WriteLine("{0}\t{1}\t\t{2}", Math.Round(i, 5), Math.Round(Taylor_Arctg(i, double.Epsilon,
                                                    out numberOfArgs), 5), numberOfArgs);
            }
            Console.ReadLine();
            return 0;
        }
    }
 }