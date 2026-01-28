using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Illumination;

namespace BlaisePascal.SmartHouse.TestDomain.IlluminationTest
{
    public class EcoLampTest
    {
        [Fact]
        public void SwitchOn_SwitchOnTheLamp()
        {
            EcoLamp ecoLamp = new(50, "lamp1");
            Assert.Equal(DeviceStatus.On, ecoLamp.Status);
        }

        [Fact]
        public void SwitchOn_CannotSwitchOnWhenLampIsAlradyOn()
        {
            EcoLamp ecoLamp = new (50, "lamp1");
            Assert.Throws<InvalidOperationException>(() => ecoLamp.SwitchOn());
        }

        [Fact]
        public void SwitchOff_SwitchOffTheLamp()
        {
            EcoLamp ecoLamp = new (50, "lamp1");
            ecoLamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, ecoLamp.Status);
        }

        [Fact]
        public void SwitchOff_CannotSwitchOffWhenLampIsAlradyOff()
        {
            EcoLamp ecoLamp = new ("lamp1");
            Assert.Throws<InvalidOperationException>(() => ecoLamp.SwitchOff());
        }

        [Fact]
        public void Brighten_StepCannotBeNegative()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            Assert.Throws<ArgumentException>(() => ecoLamp.Brighten(-1));
        }

        [Fact]
        public void Brightnes_CannotBrightenWhenLampIsOff()
        {
            EcoLamp ecoLamp = new("Lamp1");
            Assert.Throws<InvalidOperationException>(() => ecoLamp.Brighten(80));
        }

        [Fact]
        public void Brighten_WhenStepIsGreaterThanMaxBrightnessIsSetAtMax()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.Brighten(100);
            Assert.Equal(100, ecoLamp.Brightness);
        }

        [Fact]
        public void Brighten_WhenStepIsInMinMaxLampIsBrightnenCorrectly()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.Brighten(10);
            Assert.Equal(30, ecoLamp.Brightness);
        }

        [Fact]
        public void Dimmer_StepCannotBeNegative()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            Assert.Throws<ArgumentException>(() => ecoLamp.Dimmer(-1));
        }

        [Fact]
        public void Dimmer_CannotDimmerWhenLampIsOff()
        {
            EcoLamp ecoLamp = new("Lamp1");
            Assert.Throws<InvalidOperationException>(() => ecoLamp.Dimmer(80));
        }

        [Fact]
        public void Dimmer_WhenStepIsLowerThanMinBrightnessIsSetAtMin()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.Dimmer(100);
            Assert.Equal(0, ecoLamp.Brightness);
        }

        [Fact]
        public void Dimmer_WhenStepIsInMinMaxLampIsDimmerCorrectly()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.Dimmer(10);
            Assert.Equal(10, ecoLamp.Brightness);
        }
       
        [Fact]
        public void SetBrightness_CannotSetBrightnessWhenLampIsOff()
        {
            EcoLamp ecoLamp = new("Lamp1");
            Assert.Throws<InvalidOperationException>(() => ecoLamp.SetBrightness(10));
        }

        [Fact]
        public void SetBrightness_WhenValueIsGreaterThanMaxBrightnessIsSetAtMax()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.SetBrightness(500);
            Assert.Equal(ecoLamp.MaxBrightness, ecoLamp.Brightness);
        }

        [Fact]
        public void SetBrightness_WhenValueIsLowerThanMinBrightnessIsSetAtMin()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.SetBrightness(-1);
            Assert.Equal(ecoLamp.MinBrigthness, ecoLamp.Brightness);
        }

        [Fact]
        public void SetBrightness_WhenValueIsRightBrightnessIsSetCorrectly()
        {
            EcoLamp ecoLamp = new(20, "Lamp1");
            ecoLamp.SetBrightness(50);
            Assert.Equal(50, ecoLamp.Brightness);
        }
    }
}
