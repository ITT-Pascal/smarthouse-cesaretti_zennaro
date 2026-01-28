using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void TurnLampsOn_TurnsBothLampsOn()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.TurnLampsOn();
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
            Assert.Equal(DeviceStatus.On, secondLamp.Status);
        }
        [Fact]
        public void TurnLampsOn_ById_TurnsSpecifiedLampOn()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.TurnLampsOn(firstLamp.Id);
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
            Assert.Equal(DeviceStatus.Off, secondLamp.Status);
        }
        [Fact]
        public void TurnLampsOn_ByName_TurnsSpecifiedLampOn()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.TurnLampsOn("lamp2");
            Assert.Equal(DeviceStatus.Off, firstLamp.Status);
            Assert.Equal(DeviceStatus.On, secondLamp.Status);
        }
        [Fact]
        public void TurnLampsOnByName_NonValidName_ThrowsArgumentException()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.TurnLampsOn("invalidName"));
        }
        [Fact]
        public void TurnLampsOnById_NonValidId_ThrowsArgumentException()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.TurnLampsOn(Guid.NewGuid()));
        }
        [Fact]
        public void EcoTurnLampsOn_ById_TurnsSpecifiedEcoLampOn()
        {
            EcoLamp firstLamp = new("ecolamp1");
            Lamp secondLamp = new("ecoLamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.EcoTurnLampsOn(firstLamp.Id);
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
        }
        [Fact]
        public void EcoTurnLampsOn_ById_CannotTurnOnStandardLamp()
        {
            EcoLamp firstLamp = new("ecolamp1");
            Lamp secondLamp = new("ecoLamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.EcoTurnLampsOn(secondLamp.Id));
        }
        [Fact]
        public void EcoTurnLampsOn_ByName_TurnSpecifiedEcoLampOn()
        {
            EcoLamp firstLamp = new("ecolamp1");
            Lamp secondLamp = new("ecoLamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.EcoTurnLampsOn(firstLamp.Name);
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
        }
        [Fact]
        public void EcoTurnLampsOn_ByName_CannotTurnOnStandardLamp()
        {
            EcoLamp firstLamp = new("ecolamp1");
            Lamp secondLamp = new("ecoLamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            Assert.Throws<ArgumentException>(() => twoLampDevice.EcoTurnLampsOn(secondLamp.Name));
        }
    }
}
