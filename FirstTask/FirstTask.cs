using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject
{
    internal class FirstTask
    {
        public class ZadanieTwo
        {
            public static void Two()
            {
                Console.Write("Введите нечетное число N: ");
                int n = int.Parse(Console.ReadLine());
                if (n % 2 == 0) // If N is an even number, exit the function.
                {
                    Console.WriteLine("Вы ввели четное N.");
                    return;
                }
                for (int row = 1; row <= n; row++)
                {
                    for (int col = 1; col <= n; col++)
                    {
                        if (row == n / 2 + 1 && col == n / 2 + 1) Console.Write(" ");
                        else Console.Write("#");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
