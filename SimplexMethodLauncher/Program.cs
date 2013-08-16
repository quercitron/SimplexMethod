﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplexMethodLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            var sm = new SimplexMethod.SimplexMethod();
            /*var A = new[,] { { 1D, 1, 1 } };
            var b = new[] { 3D };
            var c = new[] { 1D, 2, 0 };*/
            /*var A = new[,] { { 1D, 1, 3, 1, 0, 0 }, { 2, 2, 5, 0, 1, 0 }, {4, 1, 2, 0, 0, 1} };
            var b = new[] { 30D, 24, 36 };
            var c = new[] { 3D, 1, 2, 0, 0, 0 };*/
            /*var A = new[,] { { -2D, 8, 0, 10 }, { 5, 2, 0, 0 }, { 3, -5, 10, -2 } };
            var b = new[] { 50D, 100, 25 };
            var c = new[] { 1D, 1, 1, 1 };*/
            var A = new[,] { { 2D, -1 }, { 1, -5} };
            var b = new[] { 2D, -4 };
            var c = new[] { 2D, -1 };
            var result = sm.Simplex(A, b, c);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
