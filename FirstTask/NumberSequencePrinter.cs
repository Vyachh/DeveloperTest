using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject
{
    public class NumberSequencePrinter
    {
        /// <summary>
        /// Печатает последовательность чисел от 1 до указанного значения.
        /// </summary>
        /// <param name="finalValue">Конечное значение.</param>
        public static void Print(int finalValue)
        {
            Console.WriteLine(CalculateResult(finalValue));
        }

        private static string CalculateResult(int finalValue) =>
            string.Join(", ", Enumerable.Range(1, finalValue));
    }
}
