using BlaisePascal.SmartHouse.Domain;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class LampTest
    {

        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsOffTheBrigthnessPercentageIsZero()
        {
            Lamp lamp = new Lamp();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void Constructor_WhenAfterCreationTheLampIsOnItHasABrightnessPercentage() 
        {
            Lamp lamp = new Lamp(50);
            Assert.True(lamp.IsOn);
            Assert.Equal(50, lamp.BrightnessPercentage);
        }
        [Fact]
        public void SwitchOn_Off_WhenTheLampIsOnAfterSwitchOn_OffItWillTurnOffAndTheBrigthnessPercentageWillBeZero()
        {
            Lamp lamp = new Lamp(52);
            lamp.SwitchOn_Off();
            Assert.False(lamp.IsOn);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }


        [Fact]
        public void SwitchOn_Off_WhenTheLampIsOffAfterSwitchOn_OffItWillTurnOn()
        {
            Lamp lamp = new Lamp();
            lamp.SwitchOn_Off();
            Assert.True(lamp.IsOn);
        }


        [Fact]
        public void ChaangeBrightness_CannotChangeBrightnessPercentageInAValueLowerThanZero()
        {
            Lamp lamp = new Lamp(100);
            Assert.Throws<ArgumentException>(() =>lamp.ChangeBrightness(-10));
        }

        [Fact]
        public void ChaangeBrightness_CannotChangeBrightnessPercentageInAValueGreaterThan100()
        {
            Lamp lamp = new Lamp(100);
            Assert.Throws<ArgumentException>(() => lamp.ChangeBrightness(105));
        }

        [Fact]
        public void ChangeBrightness_CannotChangeBrightnessWhenTheLampIsOff()
        {
            Lamp lamp = new Lamp();
            lamp.ChangeBrightness(66);
            Assert.Equal(0, lamp.BrightnessPercentage);
        }

        [Fact]
        public void ChangeBrightness_WhenTheLampIsOnAndTheNewBrightnessValueIs66TheBritghnessPercentageWillBeSetAt66()
        {
            Lamp lamp = new Lamp(52);
            lamp.ChangeBrightness(66);
            Assert.Equal(66, lamp.BrightnessPercentage);
        }
    }
}
