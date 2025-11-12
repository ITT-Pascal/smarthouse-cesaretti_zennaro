using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class StandardLampTest
    {
        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsBeOnTheBrightnessPercentageIsSet()
        {
            StandardLamp lamp = new StandardLamp(50);
            Assert.True(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }

        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsOffTheBrightnessPercentageIsSetTo0()
        {
            StandardLamp lamp = new StandardLamp();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOn_Off_IfTheLampIsOnAfterSwitchOn_OffItWillBeOff()
        {
            StandardLamp lamp = new StandardLamp(50);
            lamp.SwitchOn_Off();
            Assert.False(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOn_Off_IfTheLampIsOffAfterSwitchOn_OffItWillBeOn()
        {
            StandardLamp lamp = new StandardLamp();
            lamp.SwitchOn_Off();
            Assert.True(lamp.IsOn);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBritghness_NewBritghnessCannotBeLowerThan0()
        {
            StandardLamp lamp = new(50);
            Assert.Throws<ArgumentException>( () =>  lamp.ChangeBrightness(-1));
        }

        [Fact]
        public void ChangeBritghness_NewBritghnessCannotBeGreaterThan100()
        {
            StandardLamp lamp = new(50);
            Assert.Throws<ArgumentException>(() => lamp.ChangeBrightness(101));
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnAndNewBrigthnessIsBetween0And100ItWillBeSet()
        {
            StandardLamp lamp = new StandardLamp(50);
            lamp.ChangeBrightness(30);
            Assert.Equal(30, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOffTheNewBrigthnessWontBeSet()
        {
            StandardLamp lamp = new StandardLamp();
            lamp.ChangeBrightness(30);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        public void IncreaseBrightness_TheIncreaseValueCannotBeLowerThan0()
        {
            StandardLamp lamp = new(50);
            Assert.Throws<ArgumentException>(() => lamp.IncreaseBrightness(-1));
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOnAndValueIsGreaterThan0TheBrightnessWillBeIncreaseCorrectly()
        {
            StandardLamp lamp = new(50);
            lamp.IncreaseBrightness(30);
            Assert.Equal(80, lamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeIncrease()
        {
            StandardLamp lamp = new();
            lamp.IncreaseBrightness(30);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        public void IncreaseBritghtness_WhenBrightnessIsIncreasedToAValueGreaterThan100ItWillBeSetat100()
        {
            StandardLamp lamp = new(50);
            lamp.IncreaseBrightness(200);
            Assert.Equal(100, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_TheDecreaseValueCannotBeLowerThan0()
        {
            StandardLamp lamp = new(50);
            Assert.Throws<ArgumentException>(() => lamp.DecreaseBrightness(-1));
        }


        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOnAndValueIsGreaterThan0TheBrightnessWillBeDecreaseCorrectly()
        {
            StandardLamp lamp = new(50);
            lamp.DecreaseBrightness(30);
            Assert.Equal(20, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeDecrease()
        {
            StandardLamp lamp = new(30);
            lamp.SwitchOn_Off();
            lamp.DecreaseBrightness(30);
            Assert.Equal(30, lamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_WhenTheBrightnessIsDecreasedInAValueLowerThan0OItWllBeSetAt0()
        {
            StandardLamp lamp = new(50);
            lamp.DecreaseBrightness(300);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }
    }
}
