using System;

namespace Laba5555
{
    class Program
    {
        //asdfjkasdklfslka
        static void Main(string[] args)
        {
            Console.WriteLine("Арифметическая прогрессия");
            double d = 0.5;
            int j = 3;
            double a0 = 1;
            Linear ar = new Linear(j, a0, d);
            Console.WriteLine("Арифметическая прогрессия, 1 элемент = {0}, Разность прогрессии = {1}, Количество элементов = {2}", a0, d, j);
            double arifSum = ar.GetSum(j);
            Console.WriteLine("Сумма арифметической прогрессии = {0}", arifSum);
            double r = 2;
            Console.WriteLine("Геометрическая прогрессия 1 элемент = {0}, Знаменатель прогрессии = {1}, Количество элементов = {2}", a0, r, j);
            Exponential exp = new Exponential(j, a0, r);
            double expSum = exp.GetSum(j);
            Console.WriteLine("Сумма геометрической прогрессии = {0}", expSum);
            Console.ReadKey();
        }
        public interface IProgression
        {
            double GetSum(int itemsCount);
        }
        public abstract class Series
        {
            public virtual double NextItem(int Index)
            {
                return 1;
            }
        }
        public class Linear : Series, IProgression
        {
            public double a0;
            public int J;
            public double D;

            public Linear(int J, double a0, double D)
            {
                this.a0 = a0;
                this.J = J;
                this.D = D;
            }
            public double GetSum(int J)
            {
                double summ = ((J) * (a0 + NextItem(J))) / 2;
                return summ;
            }
            public override double NextItem(int J)
            {
                return a0 + (J - 1) * D;
            }
        }
        public class Exponential : Series, IProgression
        {
            public double a0;
            public int J;
            public double R;

            public Exponential(int J, double a0, double R)
            {
                this.a0 = a0;
                this.J = J;
                this.R = R;
            }
            public double GetSum(int J)
            {

                return ((a0 - NextItem(J) * R) / (1 - R));

            }
            public override double NextItem(int Index)
            {
                return a0 * Math.Pow(R, J - 1);
            }
        }
    }
}
