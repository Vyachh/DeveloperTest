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
                Console.Write("Введите нечетное число N: ");
                if (int.TryParse(Console.ReadLine(), out int oddNumber))
                {
                    string result = MakeSquare(oddNumber);
                    if (result != "")
                    {
                        Print(result);
                    }
                }
                else { Console.WriteLine("Вы ввели четное N."); }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
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
                Console.WriteLine("Вы ввели четное N.");
                return "";
            }
            //string result = "";  // Увидел ощутимую разницу в скорости работы между string и StringBuilder.
            StringBuilder result = new();
            for (int row = 1; row <= oddInputValue; row++)
            {
                for (int col = 1; col <= oddInputValue; col++)
                {
                    if (row == oddInputValue / 2 + 1 && col == oddInputValue / 2 + 1) /*result += ' '*/ result.Append(' ');
                    else /*result += '#'*/result.Append('#');
                }
                //result += '\n';
                result.Append('\n');
            }
            return result.ToString();
        }

    }
}
