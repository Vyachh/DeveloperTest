using FirstTaskProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskProject.Test.Model
{
    public class SquareWithSpacePrinterTest
    {
        [Fact]
        public void MakeSquare_ReturnsSquareWithSpaceInCenter()
        {
            // Arrange
            int oddInputValue = 5;
            string expected = "#####\n#####\n## ##\n#####\n#####\n";

            // Act
            string result = SquareWithSpace.MakeSquare(oddInputValue);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
