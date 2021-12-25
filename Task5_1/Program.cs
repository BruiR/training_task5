using System;

namespace Task5_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sm = new SparseMatrix(4, 5)
            {
                [1, 2] = 2,
                [1, 3] = 2,
                [3, 1] = 2,
                [1, 4] = 4,
                [2, 2] = 15,
                [1, 1] = 0
            };
            Console.WriteLine(sm);
            Console.WriteLine(sm[1, 2]);
            Console.WriteLine(sm[1, 1]);
            Console.WriteLine(sm[1, 4]);
            Console.WriteLine(sm[3, 4]);
            Console.WriteLine($"GetCount(2) = {sm.GetCount(2)}");

            var nzElements = sm.GetNonzeroElements();
            foreach (var (row, column, element) in nzElements)
            {
                Console.WriteLine($"i={row} j={column} El={element}");
            }

            Console.WriteLine();
            foreach (var item in sm)
            {
                Console.WriteLine($"El={item}");
            }
        }
    }
}