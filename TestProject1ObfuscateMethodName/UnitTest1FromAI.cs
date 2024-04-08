using var_00001;
using Xunit;

namespace TestProject1ObfuscateMethodName
{
    [TestFixture]
    public class Tests
    {
        private var_00002 _primeService;

        [SetUp]
        public void Setup()
        {
            _primeService = new var_00002();
        }

        [Test]
        public void Divide_ValidInput_ReturnsCorrectResult()
        {
            // Arrange
            int numerator = 10;
            int denominator = 2;

            // Act
            var result = _primeService.var_00003(numerator, denominator);

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
            Assert.Throws<DivideByZeroException>(() => _primeService.var_00003(numerator, denominator));
        }
    }
}