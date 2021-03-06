﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    public static class TestHelper
    {
        public static void AssertMatricesAreEqual<T>(T[,] expectedMatrix, T[,] actualMatrix)
        {
            Assert.AreEqual(expectedMatrix.GetLength(0), actualMatrix.GetLength(0), "Matrices have different number of rows.");
            Assert.AreEqual(expectedMatrix.GetLength(1), actualMatrix.GetLength(1), "Matrices have different number of columns.");

            for (int x = 0; x < expectedMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < expectedMatrix.GetLength(1); y++)
                {
                    Assert.AreEqual(expectedMatrix[x, y], actualMatrix[x, y], $"Values are not equal at location ({x}, {y}).");
                }
            }
        }
    }

    public class HashSetComparerHelper : IComparer<HashSet<int>>, IEqualityComparer<HashSet<int>>
    {
        public int Compare([AllowNull] HashSet<int> x, [AllowNull] HashSet<int> y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            else
            {
                if (x.Count != y.Count)
                {
                    return x.Count - y.Count;
                }
                else
                {
                    var xArr = x.ToArray();
                    var yArr = y.ToArray();
                    Array.Sort(xArr);
                    Array.Sort(yArr);
                    for (int i = 0; i < x.Count; i++)
                    {
                        if (xArr[i] != yArr[i])
                        {
                            return xArr[i] - yArr[i];
                        }
                    }
                    return 0;
                }
            }
        }

        public bool Equals([AllowNull] HashSet<int> x, [AllowNull] HashSet<int> y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else
            {
                return x.SetEquals(y);
            }
        }

        public int GetHashCode([DisallowNull] HashSet<int> obj)
        {
            return obj.GetHashCode();
        }
    }
}
