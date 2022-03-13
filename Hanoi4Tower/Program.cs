using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi4Tower
{
    class Program
    {
        static int step;
        const double Div_7_6 = 7d / 6d;
        const double Div_2_3 = 2d / 3d;
        static void Main(string[] args)
        {
            int input;
            String A = "A", B = "B", C = "C", D = "D";
            do
            {
                Console.Write("河內塔4模擬程式，請輸入層數：");
                input = Int32.Parse(Console.ReadLine());
                step = 0;
                move(input, true, A, B, C, D);
                Console.WriteLine();
                GC.Collect();
            } while (input != 0);
        }

        static void move(String A, String D)
        {
            step++;
            Console.WriteLine("step " + step + " move " + A + " to " + D);
        }

        static void move(int x, String A, String B, String C)
        {
            if (x != 1)
            {
                move(x - 1, A, C, B);
                move(A, C);
                move(x - 1, B, A, C);
            }
            else
            {
                move(A, C);
            }
        }

        static void move(int x, bool use3, String A, String B, String C, String D)
        {
            switch (x)
            {
                case 0:
                    return;
                case 1:
                    move(A, D);
                    break;
                case 2:
                    move(A, B);
                    move(A, D);
                    move(B, D);
                    break;
                default:
                    if (use3)
                    {
                        double a;

                        if (x >= 6)
                        {
                            a = (double)x;
                            a = a - round((-1d + Math.Sqrt(1d + 8d * a)) / 2d);
                            move((int)a, true, A, D, C, B);
                            move(x - (int)a, A, C, D);
                            move((int)a, true, B, C, A, D);
                        }
                        else
                        {
                            move(x, false, A, B, C, D);
                        }
                    }
                    else
                    {
                        move(x - 2, false, A, C, D, B);
                        move(A, C);
                        move(A, D);
                        move(C, D);
                        move(x - 2, false, B, C, A, D);
                    }
                    break;
            }
        }

        static double round(double x)
        {
            double y = (int)x;
            if (x - y > 0)
                return y + 1;
            return y;
        }
    }
}
