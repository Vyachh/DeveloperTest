using BMIWebApi.Enums;
using System.Text;

namespace BMIWebApi.Models
{
    public class BMIResult
    {
        public double Index { get; set; }
        public string Description { get; set; }
        public string FinalString { get; set; }

        private static readonly Dictionary<double, string> BmiThresholds = new()
        {
            { 18.5, "Недостаточная масса тела" },
            { 24.9, "Нормальная масса тела" },
            { 29.9, "Избыточная масса тела (предожирение)" },
            { 34.9, "Ожирение I степени" },
            { 39.9, "Ожирение II степени" },
        };

        public static string GetBMIDescriptionByIndex(double index)
        {
            BodyObesityRate body = BodyObesityRate.ObesityIII;
            string description = "Ожирение III степени (морбидное)";
            int e = 0;

            foreach (var threshold in BmiThresholds)
            { 
                if (index < threshold.Key)
                {
                    body = (BodyObesityRate)e;
                    description = threshold.Value;
                    break;
                }
                e++;
            }
            description += $" Ваш рейтинг: {(int)body}/6";  
            return description;
        }
    }
}
