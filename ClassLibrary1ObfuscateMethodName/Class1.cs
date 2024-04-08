
namespace ClassLibrary1ObfuscateMethodName
{
    public class Class1
    {
        public double Method1(int number, int divisionNumber)
        {
            if (divisionNumber == 0)
            {
                throw new DivideByZeroException();
            }

            var result = (double)number / divisionNumber;
            return result;
        }
    }
}
