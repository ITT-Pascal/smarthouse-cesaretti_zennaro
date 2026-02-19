using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void Constructor_WhenAtLeastOneLampIsOnDeviceIsOn()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Equal(DeviceStatus.On, twoLampDevice.Status);
        }

        [Fact]
        public void SwitchOn_SwitchOnTheLampsThatAreOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchOn();
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
            Assert.Equal(DeviceStatus.On, secondLamp.Status);
        }

        [Fact]
        public void SwitchLampOn_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException> (() => twoLampDevice.SwitchLampOn(Guid.NewGuid()));
        }

        [Fact]
        public void SwitchLampOn_TurnOnLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOn(firstLamp.Id);
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
            Assert.Equal(DeviceStatus.On, secondLamp.Status);
        }

        [Fact]
        public void SwitchLampOn_CannotSwitchOnLampIfItIsAlreadyOn_Id()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException> (()=> twoLampDevice.SwitchLampOn(firstLamp.Id));
        }
        [Fact]
        public void SwitchLampOn_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLampOn("ciao"));
        }

        [Fact]
        public void SwitchLampOn_SwitchOnLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOn("lamp1");
            Assert.Equal(DeviceStatus.On, firstLamp.Status);
            Assert.Equal(DeviceStatus.On, secondLamp.Status);
        }

        [Fact]
        public void SwitchLampOn_CannotSwitchOnLampIfItIsAlreadyOn_Name()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOn("lamp1"));
        }

        [Fact]
        public void SwitchOff_SwitchOffTheLampsThatAreOn()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchOff();
            Assert.Equal(DeviceStatus.Off, firstLamp.Status);
            Assert.Equal(DeviceStatus.Off, secondLamp.Status);
        }

        [Fact]
        public void SwitchLampOff_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOff(Guid.NewGuid()));
        }
        [Fact]
        public void SwitchLampOff_SwitchOffLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(firstLamp.Id);
            Assert.Equal(DeviceStatus.Off, firstLamp.Status);
            Assert.Equal(DeviceStatus.On, secondLamp.Status);
        }

        [Fact]
        public void SwitchLampOff_CannotSwitchOffLampIfItIsAlreadyOff_Id()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOff(firstLamp.Id));
        }

        [Fact]
        public void SwitchLampOff_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOff("ciao"));
        }

        [Fact]
        public void SwitchLampOff_SwitchOffLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff("lamp1");
            Assert.Equal(DeviceStatus.Off, firstLamp.Status);
            Assert.Equal(DeviceStatus.Off, secondLamp.Status);
        }

        [Fact]
        public void SwitchLampOff_CannotSwitchOffLampIfItIsAlreadyOff_Name()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            secondLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOff("lamp1"));
        }

        [Fact]
        public void SetBothLampsBrightness_CannotSetBrightnessIfOneLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(50));
            twoLampDevice.SwitchLampOff("lamp1");
            Assert.Throws<InvalidOperationException> (() => twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(50))):
        }
        [Fact]
        public void SetBothLampsBrightness_SetBrightnessOfBothLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(50);
            Brightness expected = Brightness.CreateNew(50);
            Assert.Equal(expected, firstLamp.Brightness);
            Assert.Equal(expected, secondLamp.Brightness);
        }
}
