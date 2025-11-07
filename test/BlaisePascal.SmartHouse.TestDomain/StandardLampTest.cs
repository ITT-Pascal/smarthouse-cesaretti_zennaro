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
        public void Constructor_AfterCreationTheLampIsOnAndTheBrightnessPercentageIsSet()
        {
            StandardLamp lamp = new StandardLamp(50);
            Assert.True(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }
        [Fact]
        public void Constructor_AfterCreationTheLampIsOffAndTheBrightnessPercentageIs0()
        {
            StandardLamp lamp = new StandardLamp(0);
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
        public void BrightnessValidator_NewBritghnessCannotBeLowerThan0()
        {
            StandardLamp lamp = new StandardLamp(50);
            Assert.Throws<ArgumentException>(() => lamp.BrightnessValidator(-1));
        }


        [Fact]
        public void BrightnessValidator_NewBritghnessCannotBeGreaterThan100()
        {
            StandardLamp lamp = new StandardLamp(50);
            Assert.Throws<ArgumentException>(() => lamp.BrightnessValidator(101));
        }


        [Fact]
        public void BrigthnessValidator_NewBrigthnessCanBeBetween0And100()
        {
            StandardLamp lamp = new StandardLamp(50);
            Assert.Equal(30, lamp.BrightnessValidator(30));
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnTheNewBrigthnessWillBeSet()
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

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOnTheBrightnessWillBeIncreaseCorrectly()
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

        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOnTheBrightnessWillBeDecreaseCorrectly()
        {
            StandardLamp lamp = new(50);
            lamp.DecreaseBrightness(30);
            Assert.Equal(20, lamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeDencrease()
        {
            StandardLamp lamp = new();
            lamp.DecreaseBrightness(30);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }
    }
}
