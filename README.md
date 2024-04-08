"# GenerateObfuscateCodeForAI" 

1)
run with arguments:
ConsoleApp1ObfuscateMethodName.exe "01_ophuscate_data" "inputText.txt" "inputTextTags.txt"

2)
go to AI and say:

Write nunit tests for following method:

        public double var_00003(int var_00004, int var_00005)
        {
            if (var_00005 == 0)
            {
                throw new DivideByZeroException();
            }

            var result = (double)var_00004 / var_00005;
            return result;
        }


3) generated from AI:
using NUnit.Framework;
using Prime.Services;

namespace PrimeService.Tests
{
    [TestFixture]
    public class PrimeServiceTests
    {
        private PrimeService _primeService;

        [SetUp]
        public void Setup()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void Divide_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            int numerator = 10;
            int denominator = 2;

            // Act
            var result = _primeService.Divide(numerator, denominator);

            // Assert
            Assert.AreEqual(5.0, result);
        }

        [Test]
        public void Divide_DenominatorIsZero_ThrowsDivideByZeroException()
        {
            // Arrange
            int numerator = 10;
            int denominator = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _primeService.Divide(numerator, denominator));
        }
    }
}
