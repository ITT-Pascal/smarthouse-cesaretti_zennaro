using BlaisePascal.SmartHouse.Domain.DevicesStatus;
using BlaisePascal.SmartHouse.Domain.Lamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class LampTest
    {
        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsOffTheBrightnessPercentageIsSetTo0()
        {
            Lamp lamp = new("lamp1");
            Assert.True(lamp.Status == DeviceStatus.Off);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOff_IfTheLampIsOnAfterSwitchOffItWillBeOff()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.True(lamp.Status == DeviceStatus.Off);
        }

        [Fact]
        public void SwitchOff_WhenTheLampIsOff_AfterSwitchOffNothingHappen()
        {
            Lamp lamp = new("lamp1");
            Assert.Throws<InvalidOperationException>(() => lamp.SwitchOff());
        }

        [Fact]
        public void SwitchOn_IfTheLampIsOffAfterSwitchOnItWillBeOn()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            Assert.True(lamp.Status == DeviceStatus.On);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }
        [Fact]
        public void SwitchOn_IfTheLampIsOnAfterSwitchOnNothingHappen()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            Assert.Throws<InvalidOperationException>(() => lamp.SwitchOn());
        }

        [Fact]
        public void ChangeBritghness_NewBritghnessCannotBeLowerThan0()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(-1);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBritghness_NewBritghnessCannotBeGreaterThan100()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(101);
            Assert.Equal(100, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnAndNewBrigthnessIsBetween0And100ItWillBeSet()
        {
            Lamp lamp = new Lamp("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(30);
            Assert.Equal(30, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOff_ThrowInvalidOperationException()
        {
            Lamp lamp = new Lamp("lamp1");
            Assert.Throws<InvalidOperationException>(() => lamp.ChangeBrightness(30));
        }
        [Fact]
        public void IncreaseBrightness_TheIncreaseValueCannotBeLowerThan0()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            Assert.Throws<ArgumentException>(() => lamp.IncreaseBy(-1));
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOnAndValueIsGreaterThan0TheBrightnessWillBeIncreaseCorrectly()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(50);
            lamp.IncreaseBy(30);
            Assert.Equal(80, lamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeIncrease()
        {
            Lamp lamp = new("lamp1");
            Assert.Throws<InvalidOperationException>(() => lamp.IncreaseBy(30));
        }
        [Fact]
        public void IncreaseBritghtness_WhenBrightnessIsIncreasedToAValueGreaterThan100ItWillBeSetAt100()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(50);
            lamp.IncreaseBy(200);
            Assert.Equal(100, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_TheDecreaseValueCannotBeLowerThan0()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            Assert.Throws<ArgumentException>(() => lamp.DecreaseBy(-1));
        }


        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOnAndValueIsGreaterThan0TheBrightnessWillBeDecreaseCorrectly()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(50);
            lamp.DecreaseBy(30);
            Assert.Equal(20, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeDecrease()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(30);
            lamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => lamp.DecreaseBy(30));
        }

        [Fact]
        public void DecreaseBrightness_WhenTheBrightnessIsDecreasedInAValueLowerThan0OItWllBeSetAt0()
        {
            Lamp lamp = new("lamp1");
            lamp.SwitchOn();
            lamp.ChangeBrightness(50);
            lamp.DecreaseBy(300);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }
    }
}
