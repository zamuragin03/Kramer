using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kramer
{
    class Kramer
    {
        private double[] a;

        /// | a0 a1 a2  | a3  | 
        /// | a4 a5 a6  | a7  |
        /// | a8 a9 a10 | a11 |

        public Kramer(double[] a)
        {
            this.a = a;
        }

        /// <summary>
        /// Находит опредеитель массива
        /// </summary>
        /// <param  name= "a"  ></param>
        /// <returns></returns>
        double Det()
        {
            return a[0] * (a[5] * a[10] - a[9] * a[6]) - a[1] * (a[4] * a[10] - a[8] * a[6]) +
                   a[2] * (a[4] * a[9] - a[5] * a[8]);
        }
        double DetX()
        {
            return a[3] * (a[5] * a[10] - a[9] * a[6]) - a[1] * (a[7] * a[10] - a[11] * a[6]) +
                   a[2] * (a[7] * a[9] - a[5] * a[11]);
        }
        double DetY()
        {
            return a[0] * (a[7] * a[10] - a[11] * a[6]) - a[3] * (a[4] * a[10] - a[8] * a[6]) +
                   a[2] * (a[4] * a[11] - a[7] * a[8]);
        }
        double DetZ()
        {
            return a[0] * (a[5] * a[11] - a[7] * a[9]) - a[1] * (a[4] * a[11] - a[8] * a[7]) +
                   a[3] * (a[4] * a[9] - a[5] * a[8]);
        }

        public bool Checker()
        {
            return Det() != 0;
        }

        public double[] Answer()
        {
            return new[] { DetX() / Det(), DetY() / Det(), DetZ() / Det() };
        }

        public void Save()
        {
            using var temp = new StreamWriter("result.txt");
            temp.WriteLine(new string('—', 40));
            temp.WriteLine("Вы ввели следующие данные:");
            temp.WriteLine("a(x)=b\n");
            for (int i = 0; i <4; i++)
            {
                temp.Write($"{a[i]} ");
            }
            temp.WriteLine();

            for (int i = 4; i < 8; i++)
            {
                temp.Write($"{a[i]} ");
            }

            temp.WriteLine();
            for (int i = 8; i < 12; i++)
            {
                temp.Write($"{a[i]} ");
            }
            temp.WriteLine();
            if (Checker())
            {
                temp.WriteLine($"Δ= {Det()}");

                temp.WriteLine($"ΔX1= {DetX()}");
                temp.WriteLine($"ΔX2= {DetY()}");
                temp.WriteLine($"ΔX3= {DetZ()}");
                temp.WriteLine();

                temp.WriteLine($"X1= ΔX1/Δ  X1={DetX() / Det():F}");

                temp.WriteLine($"X2= ΔX2/Δ  X2={DetY() / Det():F}");

                temp.WriteLine($"X3= ΔX3/Δ  X3={DetZ() / Det():F}");
            }
            else
            {
                temp.WriteLine($"Система имеет бесконечное число решений  т. к Δ={Det()}");
            }
        }
    }
}
