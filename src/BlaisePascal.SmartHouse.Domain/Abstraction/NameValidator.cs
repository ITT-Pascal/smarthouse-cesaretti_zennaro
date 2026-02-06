using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Abstraction
{
    public static class NameValidator
    {
        public static void Validator(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("name cannot be null, empty or with empty spaces");
        }
    }
}
