using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Library
{
    public class Gcd
    {

        private delegate int GcdMethod(int x, int y, ref long time);

        public static int GetEuclid(int a, int b)
        {
            long time = 0;
            int gcd = Count(a, b, ref time, EuclidMethod);
            double microseconds = time/(Double) Stopwatch.Frequency*1000;
            return gcd;
        }

        public static int GetEuclid(int a, int b, int c)
        {
            long time = 0;
            int gcd = Count(Count(a, b, ref time, EuclidMethod), c, ref time, EuclidMethod);
            double microseconds = time / (Double)Stopwatch.Frequency * 1000;
            return gcd;
        }

        public static int GetEuclid(params int[] args)
        {
            long time = 0;
            int gcd = Count(EuclidMethod, ref time, args);
            double microseconds = time / (Double)Stopwatch.Frequency * 1000;
            return gcd;
        }

        public static int GetStein(int a, int b)
        {
            long time = 0;
            int gcd = Count(a, b, ref time, SteinMethod);
            double microseconds = time / (Double)Stopwatch.Frequency * 1000;
            return gcd;
        }

        public static int GetStein(int a, int b, int c)
        {
            long time = 0;
            int gcd = Count(Count(a, b, ref time, SteinMethod), c, ref time, SteinMethod);
            double microseconds = time / (Double)Stopwatch.Frequency * 1000;
            return gcd;
        }

        public static int GetStein(params int[] args)
        {
            long time = 0;
            int gcd = Count(SteinMethod, ref time, args);
            double microseconds = time / (Double)Stopwatch.Frequency * 1000;
            return gcd;
        }

        private static int Count(int x, int y, ref long time, GcdMethod gcdMethod)
        {
            return gcdMethod(x, y, ref time);
        }

        //private static int Count(int x, int y, int z, ref long time, GcdMethod gcdMethod)
        //{
        //    return gcdMethod(gcdMethod(x, y, ref time), z, ref time);
        //}

        private static int Count(GcdMethod gcdMethod, ref long time, params int[] args)
        {
            if (args == null || args.Length < 2)
                throw new Exception("Too few arguments in function");
            int gcd = args[0];
            time = 0;
            for (int i = 1; i < args.Length; i++)
            {
                gcd = gcdMethod(gcd, args[i], ref time);
            }
            return gcd;
        }

        private static int EuclidMethod(int a, int b, ref long time)
        {
            int temp;
            long startTime = Stopwatch.GetTimestamp();
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            time += Stopwatch.GetTimestamp() - startTime;
            return a;
        }
        private static int SteinMethod(int a, int b, ref long time)
        {
            int shiftCount;
            bool isNegative = a < 0 && b < 0;
            a = Math.Abs(a);
            b = Math.Abs(b);
            long startTime = Stopwatch.GetTimestamp();

            if (a == 0)
            {
                time += Stopwatch.GetTimestamp() - startTime;
                return b;
            }
            if (b == 0)
            {
                time += Stopwatch.GetTimestamp() - startTime;
                return a;
            }
            for (shiftCount = 0; ((a | b) & 1) == 0; shiftCount++)
            {
                a >>= 1;
                b >>= 1;
            }
            while ((a & 1) == 0)
                a >>= 1;

            do
            {
                while ((b & 1) == 0)
                    b >>= 1;
                if (a > b)
                {
                    Swap(ref a, ref b);
                }
                b = b - a;
            } while (b != 0);
            a = a << shiftCount;
            if (isNegative)
            {
                time += Stopwatch.GetTimestamp() - startTime;
                return -a;
            }
            time += Stopwatch.GetTimestamp() - startTime;
            return a;
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
