namespace FirstTaskProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    Console.Write("Введите конечное значение (положительное, не буква): ");
            //    if (int.TryParse(Console.ReadLine(), out int finalValue) && finalValue > 0)
            //    {
            //        NumberSequencePrinter.Print(finalValue);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Введите корректное значение. " +
            //            "Число должно быть меньше чем 2147483647 и больше нуля.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Ошибка:" + ex.Message);
            //}

            try
            {
                SquareWithSpacePrinter.Print(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
            }
        }
    }
}