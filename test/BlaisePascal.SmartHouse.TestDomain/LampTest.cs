using BlaisePascal.SmartHouse.Domain;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class LampTest
    {
        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsOnItHasABrightnessPercentage()
        {
            StandardLamp lamp = new StandardLamp(50);
            Assert.True(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }
        [Fact]
        public void SwitchOn_Off_WhenTheLampIsOnAfterSwitchOn_OffItWillTurnOffAndTheBrigthnessPercentageWillBeZero()
        {
            StandardLamp lamp = new StandardLamp(52);
            lamp.SwitchOn_Off();
            Assert.False(lamp.IsOn);
        }

        [Fact]
        public void SwitchOn_Off_WhenTheLampIsOffAfterSwitchOn_OffItWillTurnOnAndTheBrightnessPercentageWillBe100()
        {
            StandardLamp lamp = new StandardLamp();
            lamp.SwitchOn_Off();
            Assert.True(lamp.IsOn);
        }

        [Fact]
        public void ChangeBrightness_CannotChangeBrightnessPercentageInAValueLowerThanZero()
        {
            StandardLamp lamp = new StandardLamp(100);
            Assert.Throws<ArgumentException>(() => lamp.ChangeBrightness(-10));
        }

        [Fact]
        public void ChangeBrightness_CannotChangeBrightnessPercentageInAValueGreaterThan100()
        {
            StandardLamp lamp = new StandardLamp(100);
            Assert.Throws<ArgumentException>(() => lamp.ChangeBrightness(105));
        }

        [Fact]
        public void ChangeBrightness_CannotChangeBrightnessWhenTheLampIsOff()
        {
            StandardLamp lamp = new StandardLamp();
            lamp.ChangeBrightness(66);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnAndTheNewBrightnessValueIs66TheBritghnessPercentageWillBeSetAt66()
        {
            StandardLamp lamp = new StandardLamp(52);
            lamp.ChangeBrightness(66);
            Assert.Equal(66, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnAndTheNewBrightnessValueIs0_TheBritghnessPercentageWillBeSetAt0()
        {
            StandardLamp lamp = new StandardLamp(52);
            lamp.ChangeBrightness(0);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }
    }
}
