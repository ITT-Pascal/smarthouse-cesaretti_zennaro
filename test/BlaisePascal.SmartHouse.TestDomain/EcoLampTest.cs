using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class EcoLampTest
    {
        

        [Fact]
        public void Constructor_AfterCreationTheLampIsOnAndTheBrightnessPercentageIsSet()
        {
            EcoLamp ecolamp = new EcoLamp(50);
            Assert.True(ecolamp.IsOn);
            Assert.Equal(50, ecolamp.BrightnessPercentage);
        }
        [Fact]
        public void Constructor_AfterCreationTheLampIsOffAndTheBrightnessPercentageIs0()
        {
            EcoLamp ecolamp = new EcoLamp(0);
            Assert.True(ecolamp.IsOn);
            Assert.Equal(0, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOn_Off_IfTheLampIsOnAfterSwitchOn_OffItWillBeOff()
        {
            EcoLamp ecolamp = new EcoLamp(50);
            ecolamp.SwitchOn_Off();
            Assert.False(ecolamp.IsOn);
            Assert.Equal(50, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void SwitchOn_Off_IfTheLampIsOffAfterSwitchOn_OffItWillBeOn()
        {
            EcoLamp ecolamp = new EcoLamp();
            ecolamp.SwitchOn_Off();
            Assert.True(ecolamp.IsOn);
            Assert.Equal(0, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnTheNewBrigthnessWillBeSet()
        {
            EcoLamp ecolamp = new EcoLamp(50);
            ecolamp.ChangeBrightness(30);
            Assert.Equal(30, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOffTheNewBrigthnessWontBeSet()
        {
            EcoLamp ecolamp = new EcoLamp();
            ecolamp.ChangeBrightness(30);
            Assert.Equal(0, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOnTheBrightnessWillBeIncreaseCorrectly()
        {
            EcoLamp ecolamp = new(50);
            ecolamp.IncreaseBrightness(30);
            Assert.Equal(80, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeIncrease()
        {
            EcoLamp ecolamp = new();
            ecolamp.IncreaseBrightness(30);
            Assert.Equal(0, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void DecreaseBrightness_WhenTheLampIsOnTheBrightnessWillBeDecreaseCorrectly()
        {
            EcoLamp ecolamp = new(50);
            ecolamp.DecreaseBrightness(30);
            Assert.Equal(20, ecolamp.BrightnessPercentage);
        }

        [Fact]
        public void IncreaseBrightness_WhenTheLampIsOffTheBrightnessWontBeDencrease()
        {
            EcoLamp ecolamp = new();
            ecolamp.DecreaseBrightness(30);
            Assert.Equal(0, ecolamp.BrightnessPercentage);
        }
    }
}
