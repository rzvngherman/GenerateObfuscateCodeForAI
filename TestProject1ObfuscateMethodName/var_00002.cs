using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace var_00001
{
    public class var_00002
    {
        public double var_00003(int var_00004, int var_00005)
        {
            if (var_00005 == 0)
            {
                throw new DivideByZeroException();
            }

            var result = (double)var_00004 / var_00005;
            return result;
        }

    }
}
