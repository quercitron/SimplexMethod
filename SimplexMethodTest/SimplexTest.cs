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
            var answer = new double[] { 0, 3 };
            CollectionAssert.AreEqual(answer, result.Solution);
        }
        
        [TestMethod]
        public void Test2()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { 1D, 1, 3 }, { 2, 2, 5 }, { 4, 1, 2 } };
            var b = new[] { 30D, 24, 36 };
            var c = new[] { 3D, 1, 2 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 8, 4, 0 };
            CollectionAssert.AreEqual(answer, result.Solution);
        }

        [TestMethod]
        public void TestElection()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { -2D, 8, 0, 10 }, { 5, 2, 0, 0 }, { 3, -5, 10, -2 } };
            var b = new[] { 50D, 100, 25 };
            var c = new[] { 1D, 1, 1, 1 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 15.9090909090909, 10.2272727272727, 2.84090909090909, 0 };
            DoubleCollectionAssert(answer, result.Solution);
        }

        [TestMethod]
        public void TestElection2()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { 2D, -8, 0, -10 }, { -5, -2, 0, 0 }, { -3, 5, -10, 2 } };
            var b = new[] { -50D, -100, -25 };
            var c = new[] { -1D, -1, -1, -1 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 18.4684684684685, 3.82882882882883, 0, 5.63063063063063 };
            DoubleCollectionAssert(answer, result.Solution);
        }

        [TestMethod]
        public void TestInitialization1()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { 2D, -1 }, { 1, -5 } };
            var b = new[] { 2D, -4 };
            var c = new[] { 2D, -1 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] {14D / 9, 10D / 9};
            DoubleCollectionAssert(answer, result.Solution);
        }

        [TestMethod]
        public void TestSpecialCase()
        {
            var sm = new SimplexMethod.SimplexMethod();
            var A = new[,] { { 1D, 1 }, { -1D, -1 } };
            var b = new[] { 1D, -1D };
            var c = new[] { -2D, -1 };
            var result = sm.Simplex(A, b, c);
            var answer = new double[] { 0, 1 };
            DoubleCollectionAssert(answer, result.Solution);
        }

        public void DoubleCollectionAssert(IList<double> expected, IList<double> actual)
        {
            if (expected.Count != actual.Count)
            {
                throw new AssertFailedException("Different number of elements.");
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
