using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraySortDelegates
{
    public static class JaggedArraySort
    {
        public static void DoSort(int[][] array, Func<int[], int[], int> compareFunc)
        {
            QuickSort(array, 0, array.Length - 1, compareFunc);
        }

        public static void DoSort(int[][] array, IComparer<int[]> comparer )
        {
            QuickSort(array, 0, array.Length - 1, comparer.Compare);
        }

        private static void QuickSort(int[][] array, int left, int right, Func<int[], int[], int> compareFunc)
        {
            if (array == null || array.Length <= 1)
                return;
            if (left < right)
            {
                int pivot = Partition(array, left, right, compareFunc);

                if (pivot > 1)
                    QuickSort(array, left, pivot - 1, compareFunc);

                if (pivot + 1 < right)
                    QuickSort(array, pivot + 1, right, compareFunc);
            }
        }

        private static int Partition(int[][] array, int left, int right, Func<int[], int[], int> compareFunc)
        {
            int[] pivot = array[left];

            while (true)
            {
                while (compareFunc(array[left], pivot) < 0)
                    left++;

                while (compareFunc(array[right], pivot) > 0)
                    right--;

                if (left < right)
                {
                    Swap(ref array[left], ref array[right]);
                }
                else
                {
                    return right;
                }
            }
        }

        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
    }

    public static class SortingQueries
    {
        public static int CompareByAbsoluteMaxToUp(int[] a, int[] b)
        {
            int maxA = FindAbsoluteMaxOfElements(a);
            int maxB = FindAbsoluteMaxOfElements(b);
            if (maxA > maxB)
            {
                return 1;
            }
            if (maxA < maxB)
            {
                return -1;
            }
            return 0;
        }
        public static int CompareByAbsoluteMaxToDown(int[] a, int[] b)
        {
            int maxA = FindAbsoluteMaxOfElements(a);
            int maxB = FindAbsoluteMaxOfElements(b);
            if (maxA < maxB)
            {
                return 1;
            }
            if (maxA > maxB)
            {
                return -1;
            }
            return 0;
        }
        public static int CompareBySumToUp(int[] a, int[] b)
        {
            int sumA = FindSumOfElements(a);
            int sumB = FindSumOfElements(b);
            if (sumA > sumB)
            {
                return 1;
            }
            if (sumA < sumB)
            {
                return -1;
            }
            return 0;
        }
        public static int CompareBySumToDown(int[] a, int[] b)
        {
            int sumA = FindSumOfElements(a);
            int sumB = FindSumOfElements(b);
            if (sumA < sumB)
            {
                return 1;
            }
            if (sumA > sumB)
            {
                return -1;
            }
            return 0;
        }

        public static int CompareByStringLengthToUp(int[]a, int[] b)
        {
            int lenA = FindStringLength(a);
            int lenB = FindStringLength(b);
            if (lenA > lenB)
            {
                return 1;
            }
            if (lenA < lenB)
            {
                return -1;
            }
            return 0;
        }

        public static int CompareByStringLengthToDown(int[] a, int[] b)
        {
            int lenA = FindStringLength(a);
            int lenB = FindStringLength(b);
            if (lenA < lenB)
            {
                return 1;
            }
            if (lenA > lenB)
            {
                return -1;
            }
            return 0;
        }

        private static int FindStringLength(int[] array)
        {
            if (array == null) return -1;
            return array.Length;
        }


        private static int FindAbsoluteMaxOfElements(int[] array)
        {
            if (array.Length == 0) throw new NullReferenceException("Array is empty");
            if (array.Length == 1) return array[0];
            int max = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) > max)
                {
                    max = Math.Abs(array[i]);
                }
            }
            return max;
        }
        private static int FindSumOfElements(int[] array)
        {
            if (array.Length == 0) throw new NullReferenceException("Array is empty");
            int sum = array.Sum();
            return sum;
        }
    }
}
