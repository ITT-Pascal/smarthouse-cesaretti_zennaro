using BlaisePascal.SmartHouse.Domain;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class UnitTest1
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
    }
}
