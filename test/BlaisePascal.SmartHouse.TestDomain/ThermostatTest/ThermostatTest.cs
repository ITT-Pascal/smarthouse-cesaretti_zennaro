using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Thermostat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain.ThermostatTest
{
    public class ThermostatTest
    {
        [Fact]
        public void SetTemperature_WhenValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.SetTemperature(200);
            Assert.Equal(thermostat.MaxTemperature, thermostat.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.SetTemperature(-200);
            Assert.Equal(thermostat.MinTemperature, thermostat.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenValueDoesNotOverFLowTheRangeTemperatureIsSetCorrectly()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.SetTemperature(20);
            Assert.Equal(20, thermostat.Temperature);
        }

        [Fact]
        public void SetTemperature_WithoutParametersTemperatureIsSetAtDefaultValue()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.SetTemperature();
            Assert.Equal(thermostat.DefaultTemperature, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WithoutParametersTemperatureIsIncreasedByDefaultValue()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.IncreaseTemperature();
            Assert.Equal(22, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenDefaultValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Thermostat thermostat = new("Thermo1", 29);
            thermostat.IncreaseTemperature();
            Assert.Equal(thermostat.MaxTemperature, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureByDefaultValueWhenDeviceIsOff()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<InvalidOperationException> (() => thermostat.IncreaseTemperature());
        }

        [Fact]
        public void IncreaseTemperature_ValueCannotBeNegative()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<ArgumentException> (() => thermostat.IncreaseTemperature(-1));
        }
        [Fact]
        public void IncreaseTemperature_WhenValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.IncreaseTemperature(50);
            Assert.Equal(thermostat.MaxTemperature, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenValueDoesNotOverFlowTheRangeTemperatureIsSetCorrectly()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.IncreaseTemperature(5);
            Assert.Equal(23, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            Thermostat Thermostat = new("Thermo1");
            Assert.Throws<InvalidOperationException>(() => Thermostat.IncreaseTemperature(7));
        }
        
        public void DecreaseTemperture_WithoutParametersTemperatureIsDecreasedByDefaultValue()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.DecreaseTemperature();
            Assert.Equal(14, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenCalledWithStep_DecreasesTemperatureByStep()
        {
            Thermostat thermostat = new("Thermo1");
            int expectedStep = 5;
            int expectedTemperature = thermostat.Temperature - expectedStep;
            thermostat.DecreaseTemperature(expectedStep);
            Assert.Equal(expectedTemperature, thermostat.Temperature);
        }
        [Fact]
        public void DecreaseTemperature_CannotDecreaseTemperatureBeyondMinLimit()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.DecreaseTemperature(100));
        }
    }
}
