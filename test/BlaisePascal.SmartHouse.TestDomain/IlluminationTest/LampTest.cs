using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.ObjectStatus;
using BlaisePascal.SmartHouse.Domain.Illumination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain
{
    public class LampTest
    {
        public class EcoLampTest
        {
            [Fact]
            public void SwitchOn_SwitchOnTheLamp()
            {
                Lamp lamp = new("lamp1");
                lamp.SwitchOn();
                Assert.Equal(DeviceStatus.On, lamp.Status);
            }

            [Fact]
            public void SwitchOn_CannotSwitchOnWhenLampIsAlradyOn()
            {
                Lamp ecoLamp = new(50, "lamp1");
                Assert.Throws<InvalidOperationException>(() => ecoLamp.SwitchOn());
            }

            [Fact]
            public void SwitchOff_SwitchOffTheLamp()
            {
                Lamp ecoLamp = new(50, "lamp1");
                ecoLamp.SwitchOff();
                Assert.Equal(DeviceStatus.Off, ecoLamp.Status);
            }

            [Fact]
            public void SwitchOff_CannotSwitchOffWhenLampIsAlradyOff()
            {
                Lamp ecoLamp = new("lamp1");
                Assert.Throws<InvalidOperationException>(() => ecoLamp.SwitchOff());
            }

            [Fact]
            public void Brighten_StepCannotBeNegative()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                Assert.Throws<ArgumentException>(() => ecoLamp.Brighten(-1));
            }

            [Fact]
            public void Brightnes_CannotBrightenWhenLampIsOff()
            {
                Lamp ecoLamp = new("Lamp1");
                Assert.Throws<InvalidOperationException>(() => ecoLamp.Brighten(80));
            }

            [Fact]
            public void Brighten_WhenStepIsGreaterThanMaxBrightnessIsSetAtMax()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.Brighten(100);
                Assert.Equal(100, ecoLamp.Brightness);
            }

            [Fact]
            public void Brighten_WhenStepIsInMinMaxLampIsBrightnenCorrectly()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.Brighten(10);
                Assert.Equal(30, ecoLamp.Brightness);
            }

            [Fact]
            public void Dimmer_StepCannotBeNegative()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                Assert.Throws<ArgumentException>(() => ecoLamp.Dimmer(-1));
            }

            [Fact]
            public void Dimmer_CannotDimmerWhenLampIsOff()
            {
                Lamp ecoLamp = new("Lamp1");
                Assert.Throws<InvalidOperationException>(() => ecoLamp.Dimmer(80));
            }

            [Fact]
            public void Dimmer_WhenStepIsLowerThanMinBrightnessIsSetAtMin()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.Dimmer(100);
                Assert.Equal(0, ecoLamp.Brightness);
            }

            [Fact]
            public void Dimmer_WhenStepIsInMinMaxLampIsDimmerCorrectly()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.Dimmer(10);
                Assert.Equal(10, ecoLamp.Brightness);
            }

            [Fact]
            public void SetBrightness_CannotSetBrightnessWhenLampIsOff()
            {
                Lamp ecoLamp = new("Lamp1");
                Assert.Throws<InvalidOperationException>(() => ecoLamp.SetBrightness(10));
            }

            [Fact]
            public void SetBrightness_WhenValueIsGreaterThanMaxBrightnessIsSetAtMax()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.SetBrightness(500);
                Assert.Equal(ecoLamp.MaxBrightness, ecoLamp.Brightness);
            }

            [Fact]
            public void SetBrightness_WhenValueIsLowerThanMinBrightnessIsSetAtMin()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.SetBrightness(-1);
                Assert.Equal(ecoLamp.MinBrigthness, ecoLamp.Brightness);
            }

            [Fact]
            public void SetBrightness_WhenValueIsRightBrightnessIsSetCorrectly()
            {
                Lamp ecoLamp = new(20, "Lamp1");
                ecoLamp.SetBrightness(50);
                Assert.Equal(50, ecoLamp.Brightness);
            }
        }

    }   
}
