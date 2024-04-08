using ClassLibrary1ObfuscateMethodName;
using Xunit;

namespace TestProject1ObfuscateMethodName
{
    public class Tests
    {
        Class1 _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Class1();
        }

        [Test]
        //[Fact(int )]
        public void Test1()
        {
            var result = _sut.Method1(13, 3);

            Assert.AreEqual(4.333333333333333, result);
        }
    }
}