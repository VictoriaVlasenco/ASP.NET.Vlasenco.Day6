using System;
using JaggedArraySortDelegates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1Test
{
    [TestClass]
    public class JaggedArraySortTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[][] array = new int[3][] {new int[3] {1, 2, 3}, new int[3] {4, 5, -6}, new int[3] {0, 1, 2}};
            int[][] array1 = new int[3][] { array[2], array[0], array[1] };
            JaggedArraySort.DoSort(array, SortingQueries.CompareByAbsoluteMaxToUp);
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInDescendingOrderByAbsoluteMaxElements()
        {
            int[][] array = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, -6 }, new int[3] { 0, 1, 2 } };
            int[][] array1 = new int[3][] { array[1], array[0], array[2] };
            JaggedArraySort.DoSort(array, SortingQueries.CompareByAbsoluteMaxToDown);
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInDescendingOrderBySumOfElements()
        {
            int[][] array = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 0, 1, -6 }, new int[3] { 10, 11, 12 } };
            int[][] array1 = new int[3][] { array[2], array[0], array[1] };
            JaggedArraySort.DoSort(array, SortingQueries.CompareBySumToDown);
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInAscendingOrderBySumOfElements()
        {
            int[][] array = new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 0, 1, -6 }, new int[3] { 10, 11, 12 } };
            int[][] array1 = new int[3][] { array[1], array[0], array[2] };
            JaggedArraySort.DoSort(array, SortingQueries.CompareBySumToUp);
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInAscendingOrderByStringLength()
        {
            int[][] array = new int[3][] {new int[3] {1, 2, 3}, new int[2] {0, 1}, new int[1] {1}};
            int[][] array1 = new int[3][] { array[2], array[1], array[0] };
            JaggedArraySort.DoSort(array, SortingQueries.CompareByStringLengthToUp);
            Assert.IsTrue(Equals(array, array1));
        }

        [TestMethod]
        public void SortInDescendingOrderByStringLength()
        {
            int[][] array = new int[3][] {new int[2] {1, 2}, new int[3] {0, 1, -6}, null};
            int[][] array1 = new int[3][] {array[1], array[0], array[2]};
            JaggedArraySort.DoSort(array, SortingQueries.CompareByStringLengthToDown);
            Assert.IsTrue(Equals(array, array1));
        }



        private bool Equals(int[][] a, int[][] b)
        {
            if (a == null) return (b == null);
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == null) return (b[i] == null);
                if (a[i].Length != b[i].Length) return false;
                for (int j = 0; j < a[i].Length; j++)
                {
                    if (a[i][j] != b[i][j]) return false;
                }
            }
            return true;
        }
    }
}
