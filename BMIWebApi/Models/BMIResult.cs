using BMIWebApi.Enums;
using System.Text;

namespace BMIWebApi.Models
{
    /// <summary>
    /// Класс, предоставляющий методы для работы с индексом массы тела (BMI).
    /// </summary>
    public class BMIResult
    {
        public double Index { get; set; }
        public string Description { get; set; }

        private static readonly Dictionary<double, string> BmiThresholds = new()
        {
            { 18.5, "Недостаточная масса тела." },
            { 24.9, "Нормальная масса тела." },
            { 29.9, "Избыточная масса тела (предожирение)." },
            { 34.9, "Ожирение I степени." },
            { 39.9, "Ожирение II степени." },
        };


        /// <summary>
        /// Получает описание степени ожирения на основе индекса массы тела (BMI).
        /// </summary>
        /// <param name="index">Индекс массы тела (BMI).</param>
        /// <returns>Описание степени ожирения.</returns>
        public static string GetBMIDescription(double index)
        {
            BodyObesityRate body = BodyObesityRate.ObesityIII;
            string description = "Ожирение III степени (морбидное).";
            int e = 1;

            foreach (var threshold in BmiThresholds)
            { 
                if (index <= threshold.Key)
                {
                    body = (BodyObesityRate)e;
                    description = threshold.Value;
                    break;
                }
                e++;
            }
            description += $" Степень ожирения: {(int)body}/6.";  
            return description;
        }


        /// <summary>
        /// Рассчитывает индекс массы тела (BMI) на основе заданного роста и веса.
        /// </summary>
        /// <param name="height">Рост в сантиметрах.</param>
        /// <param name="weight">Вес в килограммах.</param>
        /// <returns>Индекс массы тела (BMI).</returns>
        public static double CalculateBMI(double height, double weight)
        {
            return Math.Round(weight / Math.Pow(height / 100, 2), 2);
        }


        /// <summary>
        /// Проверяет, являются ли заданные значения роста и веса допустимыми.
        /// </summary>
        /// <param name="height">Рост в сантиметрах.</param>
        /// <param name="weight">Вес в килограммах.</param>
        /// <returns>Значение true, если значения роста и веса являются допустимыми, иначе false.</returns>
        public static bool ValidateMeasurements(double height, double weight)
        {
            if (height < 50 || height > 250)
            {
                return false;
            }
            if (weight < 5 || weight > 500)
            {
                return false;
            }
            return true;
        }
    }
}
