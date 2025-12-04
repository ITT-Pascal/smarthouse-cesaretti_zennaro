using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain.OtherDeviceTest
{
    public class ThermostatTest
    {
        [Fact]
        public void Constructor_WhenCreatingThermostat_ItSetTheInitialTemperature()
        {
            int initialTemperature = 25;
            Thermostat thermostat = new("Thermo1", initialTemperature);
            Assert.Equal(initialTemperature, thermostat.Temperature);
        }
        [Fact]
        public void Constructor_WhenCreatingThermostat_ItSetTheStatusToDeviceStatusOn()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Equal(Domain.ObjectStatus.DeviceStatus.On, thermostat.Status);
        }
        [Fact]
        public void Constructor_WhenCreatingThermostatWithoutInitialTemperature_ItSetTheDefaultTemperature()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Equal(thermostat.Temperature, thermostat.Temperature);
        }
        [Fact]
        public void Constructor_WhenCreatingThermostat_ItSetTheDefaultStepToOne()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Equal(1, thermostat.Step);
        }
        [Fact]
        public void Constructor_CannotCreateThermostatWithInvalidInitialTemperature()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Thermostat("Thermo1", -100));
        }
        [Fact]
        public void IncreaseTemperature_WhenCalledWithoutStep_IncreasesTemperatureByDefaultStep()
        {
            Thermostat thermostat = new("Thermo1");
            int expectedStep = 1;
            int expectedTemperature = thermostat.Temperature + expectedStep;
            thermostat.IncreaseTemperature();
            Assert.Equal(expectedTemperature, thermostat.Temperature);
        }
        [Fact]
        public void IncreaseTemperature_WhenCalledWithStep_IncreasesTemperatureByStep()
        {
            Thermostat thermostat = new("Thermo1");
            int expectedStep = 5;
            int expectedTemperature = thermostat.Temperature + expectedStep;
            thermostat.IncreaseTemperature(expectedStep);
            Assert.Equal(expectedTemperature, thermostat.Temperature);
        }
        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureBeyondMaxLimit()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.IncreaseTemperature(100));
        }
        [Fact]
        public void DecreaseTemperature_WhenCalledWithoutStep_DecreasesTemperatureByDefaultStep()
        {
            Thermostat thermostat = new("Thermo1");
            int expectedStep = 1;
            int expectedTemperature = thermostat.Temperature - expectedStep;
            thermostat.DecreaseTemperature();
            Assert.Equal(expectedTemperature, thermostat.Temperature);
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
        [Fact]
        public void SetTemperature_SetsTemperatureToSpecifiedValue()
        {
            Thermostat thermostat = new("Thermo1");
            int newTemperature = 30;
            thermostat.SetTemperature(newTemperature);
            Assert.Equal(newTemperature, thermostat.Temperature);
        }
        [Fact]
        public void SetTemperature_CannotSetTemperatureBeyondMinLimit()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTemperature(-10));
        }
        [Fact]
        public void SetTemperature_CannotSetTemperatureBeyondMaxLimit()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<ArgumentOutOfRangeException>(() => thermostat.SetTemperature(100));
        }
    }
}
