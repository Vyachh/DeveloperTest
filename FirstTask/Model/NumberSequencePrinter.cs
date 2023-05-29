using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject.Model
{
    public class NumberSequencePrinter
    {
        public static void Start()
        {
            Console.Write("Введите конечное значение (положительное, не буква): ");
            if (int.TryParse(Console.ReadLine(), out int endValue) && endValue > 0) // Проверка на корректное введение значения пользователем.
            {
                string result = CalculateValue(endValue); // Создаем строку
                Print(result); // Выводим ее
            }
            else
            {
                Console.WriteLine("Введите корректное значение. " +
                    "Число должно быть меньше чем 2147483647 и больше нуля.");
            }
        }
        public static void Print(string value)
        {
            Console.WriteLine("Ваша последовательность: " + value);
        }
        /// <summary>
        /// Возвращает последовательность чисел от 1 до указанного значения.
        /// </summary>
        /// <param name="finalValue">Конечное значение.</param>
        public static string CalculateValue(int finalValue)
        {
            return string.Join(", ", Enumerable.Range(1, finalValue));
        }

    }
}
