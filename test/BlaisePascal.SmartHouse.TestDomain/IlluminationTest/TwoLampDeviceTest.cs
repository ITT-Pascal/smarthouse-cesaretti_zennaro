using BlaisePascal.SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.On, firstLamp.Status);
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.On, secondLamp.Status);
        }
        [Fact]
        public void TurnLampsOn_ById_TurnsSpecifiedLampOn()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.TurnLampsOn(firstLamp.Id);
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.On, firstLamp.Status);
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.Off, secondLamp.Status);
        }
        [Fact]
        public void TurnLampsOn_ByName_TurnsSpecifiedLampOn()
        {
            Lamp firstLamp = new("lamp1");
            Lamp secondLamp = new("lamp2");
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp);
            twoLampDevice.TurnLampsOn("lamp2");
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.Off, firstLamp.Status);
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.On, secondLamp.Status);
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
    }
}
