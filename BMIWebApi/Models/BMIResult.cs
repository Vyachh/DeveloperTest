using BMIWebApi.Enums;
using BMIWebApi.Exceptions;
using BMIWebApi.Helpers;
using System.Text;

namespace BMIWebApi.Models
{
    /// <summary>
    /// Класс, предоставляющий методы для работы с индексом массы тела (BMI).
    /// </summary>
    public class BMIResult
    {

        /// <summary>
        /// Минимальное значение для значения роста (в сантиметрах).
        /// </summary>
        private const int MinHeightValue = 50;
        /// <summary>
        /// Максимальное значение для значения роста (в сантиметрах).
        /// </summary>
        private const int MaxHeightValue = 250;
        /// <summary>
        /// Минимальное значение для значения веса (в килограммах).
        /// </summary>
        private const int MinWeightValue = 5;
        /// <summary>
        /// Максимальное значение для значения веса (в килограммах).
        /// </summary>
        private const int MaxWeightValue = 500;


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
            int rate = 1;

            foreach (var threshold in BmiThresholds)
            {
                if (index <= threshold.Key)
                {
                    body = (BodyObesityRate)rate;
                    description = threshold.Value;
                    break;
                }
                rate++;
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
            Validator.ValidateMeasurement(height, MinHeightValue, MaxHeightValue, $"Рост должен быть от {MinHeightValue} до {MaxHeightValue}");
            Validator.ValidateMeasurement(weight, MinWeightValue, MaxWeightValue, $"Вес должен быть от {MinWeightValue} до {MaxWeightValue}");

            return Math.Round(weight / Math.Pow(height / 100, 2), 2);
        }
    }
}
