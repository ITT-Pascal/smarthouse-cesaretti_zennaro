using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices;
using System.Security.Cryptography.X509Certificates;

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
            Assert.Equal(DeviceStatus.On, twoLampDevice.DeviceStatus);
        }

        [Fact]
        public void SwitchOn_SwitchOnTheLampsThatAreOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchOn();
            Assert.Equal(DeviceStatus.On, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchLampOn_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLampOn(Guid.NewGuid()));
        }

        [Fact]
        public void SwitchLampOn_Id_TurnOnLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOn(firstLamp.Id);
            Assert.Equal(DeviceStatus.On, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchLampOn_Id_CannotSwitchOnLampIfItIsAlreadyOn_Id()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOn(firstLamp.Id));
        }
        [Fact]
        public void SwitchLampOn_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLampOn("ciao"));
        }

        [Fact]
        public void SwitchLampOn_Name_SwitchOnLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOn("lamp1");
            Assert.Equal(DeviceStatus.On, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchLampOn_Name_CannotSwitchOnLampIfItIsAlreadyOn_Name()
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
            Assert.Equal(DeviceStatus.Off, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.Off, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchLampOff_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLampOff(Guid.NewGuid()));
        }
        [Fact]
        public void SwitchLampOff_Id_SwitchOffLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(firstLamp.Id);
            Assert.Equal(DeviceStatus.Off, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchLampOff_Id_CannotSwitchOffLampIfItIsAlreadyOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOff(firstLamp.Id));
        }

        [Fact]
        public void SwitchLampOff_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SwitchLampOff(Name.CreateNew("ciao")));
        }

        [Fact]
        public void SwitchLampOff_Name_SwitchOffLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Equal(DeviceStatus.Off, firstLamp.DeviceStatus);
            Assert.Equal(DeviceStatus.On, secondLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchLampOff_Name_CannotSwitchOffLampIfItIsAlreadyOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            firstLamp.SwitchOff();
            secondLamp.SwitchOff();
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1")));
        }

        [Fact]
        public void SetBothLampsBrightness_CannotSetBrightnessIfOneLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(50)));
        }

        [Fact]
        public void SetBothLampBrightness_WhenValueGoesOverTheMaxBrightnessIsSetAtMax()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(700));
            Assert.Equal(Brightness.CreateNew(75), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(100), secondLamp.Brightness);
        }

        [Fact]
        public void SetBothLampBrightness_WhenValueGoesUnderTheMinBrightnessIsSetAtMin()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(-10));
            Assert.Equal(Brightness.CreateNew(0), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(0), secondLamp.Brightness);
        }

        [Fact]
        public void SetBothLampsBrightness_SetBrightnessOfBothLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(50));
            Brightness expected = Brightness.CreateNew(50);
            Assert.Equal(expected, firstLamp.Brightness);
            Assert.Equal(expected, secondLamp.Brightness);
        }

        [Fact]
        public void SetLampBrightness_Id_CannotSetBrightnessIfOneLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SetLampBrightness(firstLamp.Id, Brightness.CreateNew(50)));
        }

        [Fact]
        public void SetLampBrightness_Id_CannotSetBrightnessIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SetLampBrightness(Guid.NewGuid(), Brightness.CreateNew(50)));
        }

        [Fact]
        public void SetLampBrightness_Id_SetBrightnessOfTheLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(firstLamp.Id, Brightness.CreateNew(50));
            Assert.Equal(Brightness.CreateNew(50), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void SetLampBrightness_Id_WhenValueGoesOverTheMaxBrightnessIsSetAtMax()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(firstLamp.Id, Brightness.CreateNew(700));
            Assert.Equal(firstLamp.MaxBrightness, firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void SetLampBrightness_Id_WhenValueGoesUnderTheMinBrightnessIsSetAtMin()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(firstLamp.Id, Brightness.CreateNew(-10));
            Assert.Equal(firstLamp.MinBrigthness, firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void SetLampBrightness_Name_CannotSetBrightnessIfOneLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.SetLampBrightness(Name.CreateNew("lamp1"), Brightness.CreateNew(50)));
        }
        [Fact]
        public void SetLampBrightness_Name_CannotSetBrightnessIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.SetLampBrightness(Name.CreateNew("ciao"), Brightness.CreateNew(50)));
        }
        [Fact]
        public void SetLampBrightness_Name_SetBrightnessOfTheLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(Name.CreateNew("lamp1"), Brightness.CreateNew(50));
            Assert.Equal(Brightness.CreateNew(50), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }
        [Fact]
        public void SetLampBrightness_Name_WhenValueGoesOverTheMaxBrightnessIsSetAtMax()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(Name.CreateNew("ecolamp1"), Brightness.CreateNew(700));
            Assert.Equal(firstLamp.MaxBrightness, firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }
        [Fact]
        public void SetLampBrightness_Name_WhenValueGoesUnderTheMinBrightnessIsSetAtMin()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(Name.CreateNew("ecolamp1"), Brightness.CreateNew(-10));
            Assert.Equal(firstLamp.MinBrigthness, firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void BrightenBothLamps_CannotBrightenIfOneLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.BrightenBothLamps(10));
        }

        [Fact]
        public void BrightenBothLamps_ValueCannotBeNegative()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.BrightenBothLamps(-10));
        }

        [Fact]
        public void BrightenBothLamps_BrightenBothLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.BrightenBothLamps(10);
            Assert.Equal(Brightness.CreateNew(60), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(60), secondLamp.Brightness);
        }

        [Fact]
        public void BrightenBothLamps_WhenValueGoesOverTheMaxBrightnessIsSetAtMax()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(70));
            twoLampDevice.BrightenBothLamps(10);
            Assert.Equal(Brightness.CreateNew(75), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(80), secondLamp.Brightness);
        }

        [Fact]
        public void BrightenLamp_Id_CannotBrightenIfTheLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.BrightenLamp(firstLamp.Id, 19));
        }


        [Fact]
        public void BrightneLamp_Id_ValueCannotBeNegative()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.BrightenLamp(firstLamp.Id, -10));
        }

        [Fact]
        public void BrightenLamp_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.BrightenLamp(Guid.NewGuid(), 10));
        }

        [Fact]
        public void BrightenLamp_Id_BrightenLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.BrightenLamp(firstLamp.Id, 10);
            Assert.Equal(Brightness.CreateNew(60), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void BrightenLamp_Id_WhenValueGoesOverTheMaxBrightnessIsSetAtMax()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(firstLamp.Id, Brightness.CreateNew(70));
            twoLampDevice.BrightenLamp(firstLamp.Id, 10);
            Assert.Equal(Brightness.CreateNew(75), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void BrightenLamp_Name_CannotBrightenIfTheLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.BrightenLamp(Name.CreateNew("lamp1"), 19));
        }

        [Fact]
        public void BrightneLamp_Name_ValueCannotBeNegative()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.BrightenLamp(Name.CreateNew("lamp1"), -10));
        }

        [Fact]
        public void BrightenLamp_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.BrightenLamp(Name.CreateNew("ciao"), 10));
        }

        [Fact]
        public void BrightenLamp_Name_BrightenLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.BrightenLamp(Name.CreateNew("lamp1"), 10);
            Assert.Equal(Brightness.CreateNew(60), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void BrightnessLamp_Name_WhenValueGoesOverTheMaxBrightnessIsSetAtMax()
        {
            EcoLamp firstLamp = new(Name.CreateNew("ecolamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp1"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(Name.CreateNew("ecolamp1"), Brightness.CreateNew(70));
            twoLampDevice.BrightenLamp(Name.CreateNew("ecolamp1"), 10);
            Assert.Equal(Brightness.CreateNew(75), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void DimmerBothLamps_CannotDimmerIfOneLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.DimmerBothLamps(10));
        }
        [Fact]
        public void DimmerBothLamps_ValueCannotBeNegative()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.DimmerBothLamps(-10));
        }
        [Fact]
        public void DimmerBothLamps_DimmerBothLamps()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(50));
            twoLampDevice.DimmerBothLamps(10);
            Assert.Equal(Brightness.CreateNew(40), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(40), secondLamp.Brightness);
        }
        [Fact]
        public void DimmerBothLamps_WhenValueGoesUnderTheMinBrightnessIsSetAtMin()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetBothLampsBrightness(Brightness.CreateNew(5));
            twoLampDevice.DimmerBothLamps(10);
            Assert.Equal(Brightness.CreateNew(0), firstLamp.Brightness);
            Assert.Equal(Brightness.CreateNew(0), secondLamp.Brightness);
        }

        [Fact]
        public void DimmerLamp_Id_CannotDimIfTheLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.DimmerLamp(firstLamp.Id, 10));
        }
        [Fact]
        public void DimmerLamp_Id_ValueCannotBeNegative()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.DimmerLamp(firstLamp.Id, -10));
        }
        [Fact]
        public void DimmerLamp_Id_ThrowsExceptionIfIdIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.DimmerLamp(Guid.NewGuid(), 10));
        }
        [Fact]
        public void DimmerLamp_Id_DimmerLampWithThatId()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.DimmerLamp(firstLamp.Id, 10);
            Assert.Equal(Brightness.CreateNew(40), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void DimmerLamp_Id_WhenValueGoesUnderTheMinBrightnessIsSetAtMin()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(firstLamp.Id, Brightness.CreateNew(5));
            twoLampDevice.DimmerLamp(firstLamp.Id, 10);
            Assert.Equal(Brightness.CreateNew(0), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }

        [Fact]
        public void DimmerLamp_Name_CannotDimmerIfTheLampIsOff()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SwitchLampOff(Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => twoLampDevice.DimmerLamp(Name.CreateNew("lamp1"), 10));
        }
        [Fact]
        public void DimmerLamp_Name_ValueCannotBeNegative()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.DimmerLamp(Name.CreateNew("lamp1"), -10));
        }
        [Fact]
        public void DimmerLamp_Name_ThrowsExceptionIfNameIsNotFound()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            Assert.Throws<ArgumentException>(() => twoLampDevice.DimmerLamp(Name.CreateNew("ciao"), 10));
        }
        [Fact]
        public void DimmerLamp_Name_DimmerLampWithThatName()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.DimmerLamp(Name.CreateNew("lamp1"), 10);
            Assert.Equal(Brightness.CreateNew(40), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }
        [Fact]
        public void DimmerLamp_Name_WhenValueGoesUnderTheMinBrightnessIsSetAtMin()
        {
            Lamp firstLamp = new(Name.CreateNew("lamp1"));
            Lamp secondLamp = new(Name.CreateNew("lamp2"));
            TwoLampDevice twoLampDevice = new(firstLamp, secondLamp, Name.CreateNew("twoLampDevice"));
            twoLampDevice.SetLampBrightness(Name.CreateNew("lamp1"), Brightness.CreateNew(5));
            twoLampDevice.DimmerLamp(Name.CreateNew("lamp1"), 10);
            Assert.Equal(Brightness.CreateNew(0), firstLamp.Brightness);
            Assert.Equal(secondLamp.DefaultBrigthness, secondLamp.Brightness);
        }
    }
}