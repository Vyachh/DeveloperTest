using FirstTaskProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject.Model
{
    public class SquareWithSpacePrinter
    {

        public static void Start()
        {
            try
            {
                Console.Write("Введите нечетное число: ");
                int.TryParse(Console.ReadLine(), out int oddNumber);
                Print(MakeSquare(oddNumber));
            }
            catch (ReturnEvenValueException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        public static void Print(string value)
        {
            Console.WriteLine("Ваша фигура: \n" + value);
        }
        /// <summary>
        /// Создает квадрат, состоящий из символа «#», с «дыркой» в центре квадрата.
        /// </summary>
        /// <param name="oddInputValue">Нечетное значение.</param>
        public static string MakeSquare(int oddInputValue)
        {
            if (oddInputValue % 2 == 0) // If oddInputValue is an even number, exit the function.
            {
                throw new ReturnEvenValueException("Вы ввели четное значение!");
            }
            StringBuilder result = new();
            int avgValue = (oddInputValue / 2) + 1;
            for (int row = 1; row <= oddInputValue; row++)
            {
                for (int col = 1; col <= oddInputValue; col++)
                {
                    if (row == avgValue && col == avgValue)
                        result.Append(' ');
                    else result.Append('#');
                }
                result.Append('\n');
            }

            return result.ToString();
        }

    }
}
