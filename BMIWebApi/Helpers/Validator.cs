namespace BMIWebApi.Helpers
{

    public class Validator
    {
        /// <summary>
        /// Проверяет значение на валидность 
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="minValue">Нижняя граница</param>
        /// <param name="maxValue">Верхняя граница</param>
        /// <param name="message">Сообщение пользователю в случае ошибки.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateMeasurement(double value, double minValue, double maxValue, string message)
        {
            if (value < minValue || value > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value), message);
            }
        }
    }
}
