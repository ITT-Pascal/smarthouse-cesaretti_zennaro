using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class EcoLampTest
    {
        [Fact]
        public void SwitchOff_SwitchOffTheLamp()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(50), Name.CreateNew("ecolamp1"));
            ecoLamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOff_CannotSwitchOffWhenLampIsAlradyOff()
        {
            EcoLamp ecoLamp = new(Name.CreateNew("ecolamp1"));
            ecoLamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => ecoLamp.SwitchOff());
        }

        [Fact]
        public void SwitchOn_SwitchOnTheLamp()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(50), Name.CreateNew("ecolamp"));
            Assert.Equal(DeviceStatus.On, ecoLamp.DeviceStatus);
        }

        [Fact]
        public void SwitchOn_CannotSwitchOnWhenLampIsAlradyOn()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(50), Name.CreateNew("ecolamp1"));
            Assert.Throws<InvalidOperationException>(() => ecoLamp.SwitchOn());
        }

        [Fact]
        public void SetBrightness_CannotSetBrightnessWhenLampIsOff()
        {
            EcoLamp ecoLamp = new(Name.CreateNew("ecolamp"));
            ecoLamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => ecoLamp.SetBrightness(Brightness.CreateNew(10)));
        }

        [Fact]
        public void SetBrightness_WhenValueIsGreaterThanMaxBrightnessIsSetAtMax()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.SetBrightness(Brightness.CreateNew(500));
            Assert.Equal(ecoLamp.MaxBrightness, ecoLamp.Brightness);
        }

        [Fact]
        public void SetBrightness_WhenValueIsLowerThanMinBrightnessIsSetAtMin()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.SetBrightness(Brightness.CreateNew(-1));
            Assert.Equal(ecoLamp.MinBrigthness, ecoLamp.Brightness);
        }

        [Fact]
        public void SetBrightness_WhenValueIsRightBrightnessIsSetCorrectly()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.SetBrightness(Brightness.CreateNew(50));
            Brightness expected = Brightness.CreateNew(50);
            Assert.Equal(expected, ecoLamp.Brightness);
        }

        [Fact]
        public void Brighten_CannotBrightenWhenLampIsOff()
        {
            EcoLamp ecoLamp = new(Name.CreateNew("ecolamp"));
            ecoLamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => ecoLamp.Brighten(80));
        }

        [Fact]
        public void Brighten_StepCannotBeNegative()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            Assert.Throws<ArgumentException>(() => ecoLamp.Brighten(-1));
        }

        [Fact]
        public void Brighten_WhenStepIsGreaterThanMaxBrightnessIsSetAtMax()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.Brighten(100);
            Assert.Equal(ecoLamp.MaxBrightness, ecoLamp.Brightness);
        }

        [Fact]
        public void Brighten_WhenStepIsInMinMaxLampIsBrightnenCorrectly()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.Brighten(10);
            Brightness expected = Brightness.CreateNew(30);
            Assert.Equal(expected, ecoLamp.Brightness);
        }

        [Fact]
        public void Dimmer_CannotDimmerWhenLampIsOff()
        {
            EcoLamp ecoLamp = new(Name.CreateNew("ecolamp"));
            ecoLamp.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => ecoLamp.Dimmer(80));
        }

        [Fact]
        public void Dimmer_StepCannotBeNegative()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            Assert.Throws<ArgumentException>(() => ecoLamp.Dimmer(-1));
        }

        [Fact]
        public void Dimmer_WhenStepIsLowerThanMinBrightnessIsSetAtMin()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.Dimmer(100);
            Assert.Equal(ecoLamp.MinBrigthness, ecoLamp.Brightness);
        }

        [Fact]
        public void Dimmer_WhenStepIsInMinMaxLampIsDimmerCorrectly()
        {
            EcoLamp ecoLamp = new(Brightness.CreateNew(20), Name.CreateNew("ecolamp"));
            ecoLamp.Dimmer(10);
            Brightness expected = Brightness.CreateNew(10);
            Assert.Equal(expected, ecoLamp.Brightness);
        }
    }
}
