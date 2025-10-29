using BlaisePascal.SmartHouse.Domain;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class LampTest
    {
        [Fact]
        public void LampSwitch_WhenLampIsOff_ShouldTurnOn()
        {
            // Arrange
            Lamp lamp = new Lamp(false, 100);
            // Act
            lamp.SwitchOn_Off();
            // Assert
            Assert.True(lamp.IsOn);
        }
        [Fact]
        public void LampChangeBrightness_WhenChangeBrightnessFrom52To66_ShouldSetBrightnessTo66()
        {
            Lamp lamp = new Lamp(true, 52);
            lamp.ChangeBrightness(66);
            Assert.Equal(66, lamp.BrightnessPercentage);
        }
    }
}
