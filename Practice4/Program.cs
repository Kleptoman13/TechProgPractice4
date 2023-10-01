using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix A = new Matrix(3);
            Matrix B = new Matrix(3);


            Console.WriteLine("A:\n" + A);
            Console.WriteLine("B:\n" + B);
            Console.WriteLine("Sum:\n" + (A + B));
            Console.WriteLine("Substract:\n" + (A - B));
            Console.WriteLine("Multiply:\n" +  (A * B));
            Console.WriteLine("Multiply:\n" +  (2 * B));

            Matrix X = ((2 * A) * (A + B) - (3 * A));
            Console.WriteLine("X:\n" + X);
            Console.WriteLine(X.MatrixIsSymmetric());

            Console.ReadKey();
        }
    }
}
