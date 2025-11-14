using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public static class Validator
    {
        private const int MaxBrightness = 100;
        private const int MinBrightness = 0;

        public static int BritghnessValue(int value)
        {
            if (value <= 0 || value > 100)
                throw new ArgumentException("value must be between 0 and 100");
            return value;
        }

        public static int Value(int value)
        {
            if (value <= 0 )
                throw new ArgumentException("value must be greater than 0");
            return value;
        }

        public static int LampNumberValidator(int lampNumber)
        {
            if( lampNumber == 1 || lampNumber == 2)
            {
                return lampNumber;
            } else
            {
                throw new ArgumentException("lamp number must be 1 or 2")
            }
            

           
        }
    }
}
