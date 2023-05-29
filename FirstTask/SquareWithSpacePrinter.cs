using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject
{
    public class SquareWithSpacePrinter
    {
        /// <summary>
        /// Печатает квадрат, состоящий из символа «#», с «дыркой» в центре квадрата.
        /// </summary>
        /// <param name="oddInputValue">Нечетное значение.</param>
        public static void Print(int oddInputValue)
        {
            Console.Write("Введите нечетное число N: ");
            Console.WriteLine();
            //int oddValue = int.Parse(Console.ReadLine());
            if (oddInputValue % 2 == 0) // If N is an even number, exit the function.
            {
                Console.WriteLine("Вы ввели четное N.");
                return;
            }
            Console.WriteLine(MakeSquare(oddInputValue));
        }

        private static string MakeSquare(int oddInputValue)
        {
            for (int row = 1; row <= oddInputValue; row++)
            {
                for (int col = 1; col <= oddInputValue; col++)
                {
                    if (row == oddInputValue / 2 + 1 && col == oddInputValue / 2 + 1) Console.Write(" ");
                    else Console.Write("#");
                }
                Console.WriteLine();
            }
            return "";
        }
    }
}
