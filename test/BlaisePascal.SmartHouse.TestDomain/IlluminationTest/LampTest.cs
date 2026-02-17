using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using System.Diagnostics;

namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class LampTest
    {
        [Fact]
        public void SwitchOff_SwitchOffTheLamp()
        {
            Lamp lamp = new(Brightness.CreateNew(50), Name.CreateNew("lamp1"));
            lamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

        [Fact]
        public void SwitchOff_CannotSwitchOffWhenLampIsAlradyOff()
        {
            Lamp lamp = new(Name.CreateNew("lamp1"));
            lamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => lamp.SwitchOff());
        }

        [Fact]
        public void SwitchOn_SwitchOnTheLamp()
        {
            Lamp lamp = new(Name.CreateNew("lamp1"));
            lamp.SwitchOff();
            lamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }

        [Fact]
        public void SwitchOn_CannotSwitchOnWhenLampIsAlradyOn()
        {
            Lamp lamp = new(Brightness.CreateNew(50), Name.CreateNew("lamp1"));
            Assert.Throws<InvalidOperationException>(() => lamp.SwitchOn());
        }

        [Fact]
        public void SetBrightness_CannotSetBrightnessWhenLampIsOff()
        {
            Lamp lamp = new(Name.CreateNew("lamp1"));
            lamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => lamp.SetBrightness(10));
        }

        [Fact]
        public void SetBrightness_WhenValueIsGreaterThanMaxBrightnessIsSetAtMax()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.SetBrightness(500);
            Assert.Equal(lamp.MaxBrightness, lamp.Brightness);
        }

        [Fact]
        public void SetBrightness_WhenValueIsLowerThanMinBrightnessIsSetAtMin()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.SetBrightness(-1);
            Assert.Equal(lamp.MinBrigthness, lamp.Brightness);
        }

        [Fact]
        public void SetBrightness_WhenValueIsRightBrightnessIsSetCorrectly()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.SetBrightness(50);
            Brightness expected = Brightness.CreateNew(50);
            Assert.Equal(expected, lamp.Brightness);
        }

        [Fact]
        public void Brightne_CannotBrightenWhenLampIsOff()
        {
            Lamp lamp = new(Name.CreateNew("lamp1"));
            lamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => lamp.Brighten(80));
        }

        [Fact]
        public void Brighten_StepCannotBeNegative()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            Assert.Throws<ArgumentException>(() => lamp.Brighten(-1));
        }

        [Fact]
        public void Brighten_WhenStepIsGreaterThanMaxBrightnessIsSetAtMax()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.Brighten(100);
            Brightness expected = Brightness.CreateNew(100);
            Assert.Equal(expected, lamp.Brightness);
        }

        [Fact]
        public void Brighten_WhenStepIsInMinMaxLampIsBrightnenCorrectly()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.Brighten(10);
            Brightness expected = Brightness.CreateNew(30);
            Assert.Equal(expected, lamp.Brightness);
        }

        [Fact]
        public void Dimmer_CannotDimmerWhenLampIsOff()
        {
            Lamp lamp = new(Name.CreateNew("lamp1"));
            lamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => lamp.Dimmer(80));
        }

        [Fact]
        public void Dimmer_StepCannotBeNegative()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            Assert.Throws<ArgumentException>(() => lamp.Dimmer(-1));
        }

        [Fact]
        public void Dimmer_WhenStepIsLowerThanMinBrightnessIsSetAtMin()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.Dimmer(100);
            Brightness expected = Brightness.CreateNew(0);
            Assert.Equal(expected, lamp.Brightness);
        }

        [Fact]
        public void Dimmer_WhenStepIsInMinMaxLampIsDimmerCorrectly()
        {
            Lamp lamp = new(Brightness.CreateNew(20), Name.CreateNew("lamp1"));
            lamp.Dimmer(10);
            Brightness expected = Brightness.CreateNew(10);
            Assert.Equal(expected, lamp.Brightness);
        }
    }
}
