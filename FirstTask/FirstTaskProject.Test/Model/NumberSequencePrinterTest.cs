using FirstTaskProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject.Test.Model
{
    public class NumberSequencePrinterTest
    {
        [Fact]
        public void CalculateValue_ReturnsSequenceFrom1ToFinalValue()
        {
            // Arrange
            int finalValue = 5;
            string expected = "1, 2, 3, 4, 5";

            // Act
            string result = NumberSequence.CalculateValue(finalValue);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
