using BMIWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIWebApi.Test.Model
{
    public class BMIResultTest
    {
        [Theory]
        [InlineData(18.5, "Недостаточная масса тела. Степень ожирения: 1/6.")]
        [InlineData(24.9, "Нормальная масса тела. Степень ожирения: 2/6.")]
        [InlineData(29.9, "Избыточная масса тела (предожирение). Степень ожирения: 3/6.")]
        [InlineData(34.9, "Ожирение I степени. Степень ожирения: 4/6.")]
        [InlineData(39.9, "Ожирение II степени. Степень ожирения: 5/6.")]
        [InlineData(45.0, "Ожирение III степени (морбидное). Степень ожирения: 6/6.")]
        public void GetBMIDescription_ReturnsCorrectDescription(double index, string expectedDescription)
        {
            // Arrange

            // Act
            var result = BMIResult.GetBMIDescription(index);

            // Assert
            Assert.Equal(expectedDescription, result);
        }


        [Theory]
        [InlineData(170, 60, 20.76)]
        [InlineData(180, 75, 23.15)]
        [InlineData(160, 55, 21.48)]
        public void CalculateBMI_ReturnsCorrectBMI(double height, double weight, double expectedBMI)
        {
            double actualBMI = BMIResult.CalculateBMI(height, weight);

            Assert.Equal(expectedBMI, actualBMI, 2); // Сравниваем с точностью до двух знаков после запятой
        }

        [Theory]
        [InlineData(170, 60, true)]
        [InlineData(180, 75, true)]
        [InlineData(160, 55, true)]
        [InlineData(300, 70, false)] // Неверная высота
        [InlineData(170, 600, false)] // Неверный вес
        [InlineData(0, 50, false)] // Неверная высота
        [InlineData(170, 0, false)] // Неверный вес
        public void ValidateMeasurements_ReturnsCorrectResult(double height, double weight, bool expectedResult)
        {
            bool actualResult = BMIResult.ValidateMeasurements(height, weight);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
