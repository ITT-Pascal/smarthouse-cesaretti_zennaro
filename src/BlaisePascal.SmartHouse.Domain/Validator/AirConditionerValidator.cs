using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Validator
{
    public static class AirConditionerValidator
    {
        public static int TemperatureValidator(int value)
        {
            if (value <= 0)
                throw new ArgumentException("value must be greater than 0");
            return value;
        }
    }
}
