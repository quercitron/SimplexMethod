using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimplexMethodTest
{
    [TestClass]
    public class SimplexTest
    {
        private const double Eps = 1e-10;

        [TestMethod]
        public void TestSmall()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { 1D, 1 } };
            var b = new[] { 3D };
            var c = new[] { 1D, 2 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 0, 3, 0 };
            CollectionAssert.AreEqual(answer, result);
        }
        
        [TestMethod]
        public void Test2()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { 1D, 1, 3 }, { 2, 2, 5 }, { 4, 1, 2 } };
            var b = new[] { 30D, 24, 36 };
            var c = new[] { 3D, 1, 2 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 8, 4, 0, 18, 0, 0 };
            CollectionAssert.AreEqual(answer, result);
        }

        [TestMethod]
        public void TestElection()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { -2D, 8, 0, 10 }, { 5, 2, 0, 0 }, { 3, -5, 10, -2 } };
            var b = new[] { 50D, 100, 25 };
            var c = new[] { 1D, 1, 1, 1 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 15.9090909090909, 10.2272727272727, 2.84090909090909, 0, 0, 0, 0 };
            DoubleCollectionAssert(answer, result);
        }

        public void DoubleCollectionAssert(IList<double> expected, IList<double> actual)
        {
            if (expected.Count != actual.Count)
            {
                throw new AssertFailedException("collections length are not equal");
            }

            for (int i = 0; i < expected.Count; i++)
            {
                if (Math.Abs(expected[i] - actual[i]) > Eps)
                {
                    throw new AssertFailedException(string.Format("{0}-th element: expected {1}, actual {2}", i, expected[i], actual[i]));
                }
            }
        }
    }
}
