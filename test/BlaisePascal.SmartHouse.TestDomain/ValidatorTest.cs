using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class ValidatorTest
    {
        [Fact]
        public void BrightnessValidator_NewBritghnessCannotBeLowerThan0()
        {
            Assert.Equal(0, Validator.Brightness(-1));
        }


        [Fact]
        public void BrightnessValidator_NewBritghnessCannotBeGreaterThan100()
        {
            Assert.Equal(100, Validator.Brightness(101));
        }


        [Fact]
        public void BrigthnessValidator_NewBrigthnessCanBeBetween0And100()
        {
            Assert.Equal(30, Validator.Brightness(30));
        }
    }
}
