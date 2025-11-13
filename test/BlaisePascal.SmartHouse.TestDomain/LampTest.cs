using BlaisePascal.SmartHouse.Domain;
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
        public void Constructor_WhenAfterCreationTheLampIsBeOnTheBrightnessPercentageIsSet()
        {
            Lamp lamp = new Lamp(50);
            Assert.True(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }

        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsOffTheBrightnessPercentageIsSetTo0()
        {
            Lamp lamp = new Lamp();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOn_Off_IfTheLampIsOnAfterSwitchOn_OffItWillBeOff()
        {
            Lamp lamp = new Lamp(50);
            lamp.SwitchOn_Off();
            Assert.False(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOn_Off_IfTheLampIsOffAfterSwitchOn_OffItWillBeOn()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn_Off();
            Assert.True(lamp.IsOn);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBritghness_NewBritghnessCannotBeLowerThan0()
        {
            Lamp lamp = new(50);
            lamp.ChangeBrightness(-1);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBritghness_NewBritghnessCannotBeGreaterThan100()
        {
            Lamp lamp = new(50);
            lamp.ChangeBrightness(101);
            Assert.Equal(100, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnAndNewBrigthnessIsBetween0And100ItWillBeSet()
        {
            Lamp lamp = new Lamp(50);
            lamp.ChangeBrightness(30);
            Assert.Equal(30, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOffTheNewBrigthnessWontBeSet()
        {
            Lamp lamp = new Lamp();
            lamp.ChangeBrightness(30);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        public void IncreaseBrightness_TheIncreaseValueCannotBeLowerThan0()
        {
            Lamp lamp = new(50);
            Assert.Throws<ArgumentException>(() => lamp.IncreaseBrightness(-1));
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOnAndValueIsGreaterThan0TheBrightnessWillBeIncreaseCorrectly()
        {
            Lamp lamp = new(50);
            lamp.IncreaseBrightness(30);
            Assert.Equal(80, lamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeIncrease()
        {
            Lamp lamp = new();
            lamp.IncreaseBrightness(30);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        public void IncreaseBritghtness_WhenBrightnessIsIncreasedToAValueGreaterThan100ItWillBeSetat100()
        {
            Lamp lamp = new(50);
            lamp.IncreaseBrightness(200);
            Assert.Equal(100, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_TheDecreaseValueCannotBeLowerThan0()
        {
            Lamp lamp = new(50);
            Assert.Throws<ArgumentException>(() => lamp.DecreaseBrightness(-1));
        }


        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOnAndValueIsGreaterThan0TheBrightnessWillBeDecreaseCorrectly()
        {
            Lamp lamp = new(50);
            lamp.DecreaseBrightness(30);
            Assert.Equal(20, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeDecrease()
        {
            Lamp lamp = new(30);
            lamp.SwitchOn_Off();
            lamp.DecreaseBrightness(30);
            Assert.Equal(30, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_WhenTheBrightnessIsDecreasedInAValueLowerThan0OItWllBeSetAt0()
        {
            Lamp lamp = new(50);
            lamp.DecreaseBrightness(300);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }
    }
}
