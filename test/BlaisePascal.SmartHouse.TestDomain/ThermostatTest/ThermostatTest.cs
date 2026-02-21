using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat;

namespace BlaisePascal.SmartHouse.TestDomain.ThermostatTest
{
    public class ThermostatTest
    {
        [Fact]
        public void SetTemperature_CannotSetTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperature(Temperature.CreateNew(100)));
        }

        [Fact]
        public void SetTemperature_WhenValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SetTemperature(Temperature.CreateNew(200));
            Assert.Equal(thermostat.MaxTemperature, thermostat.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SetTemperature(Temperature.CreateNew(-200));
            Assert.Equal(thermostat.MinTemperature, thermostat.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenValueDoesNotOverFLowTheRangeTemperatureIsSetCorrectly()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SetTemperature(Temperature.CreateNew(20));
           Temperature expected = Temperature.CreateNew(20);
            Assert.Equal(expected, thermostat.Temperature);
        }

        [Fact]
        public void SetTemperature_CannotSetDefaultTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperature());
        }

        [Fact]
        public void SetTemperature_WithoutParametersTemperatureIsSetAtDefaultValue()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"), Temperature.CreateNew(30));
            thermostat.SetTemperature();
            Assert.Equal(thermostat.DefaultTemperature, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureByDefaultValueWhenDeviceIsOff()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.IncreaseTemperature());
        }

        [Fact]
        public void IncreaseTemperature_WithoutParametersTemperatureIsIncreasedByDefaultValue()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"), Temperature.CreateNew(10));
            thermostat.IncreaseTemperature();
             Temperature expected = Temperature.CreateNew(14);
            Assert.Equal(expected, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenDefaultValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"), Temperature.CreateNew(29));
            thermostat.IncreaseTemperature();
            Assert.Equal(thermostat.MaxTemperature, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.IncreaseTemperature(7));
        }

        [Fact]
        public void IncreaseTemperature_ValueCannotBeNegative()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            Assert.Throws<ArgumentException>(() => thermostat.IncreaseTemperature(-1));
        }
        [Fact]
        public void IncreaseTemperature_WhenValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.IncreaseTemperature(50);
            Assert.Equal(thermostat.MaxTemperature, thermostat.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenValueDoesNotOverFlowTheRangeTemperatureIsSetCorrectly()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"), Temperature.CreateNew(20));
            thermostat.IncreaseTemperature(5);
            Temperature expected = Temperature.CreateNew(25);
            Assert.Equal(expected, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotDecreaseByDefaultValueWhenDeviceIsOff()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.DecreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_WhenDefaultValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"), Temperature.CreateNew(1));
            thermostat.DecreaseTemperature();
            Assert.Equal(thermostat.MinTemperature, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperture_WithoutParametersTemperatureIsDecreasedByDefaultValue()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.DecreaseTemperature();
            Temperature expected = Temperature.CreateNew(14);
            Assert.Equal(expected, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotDecreaseTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.DecreaseTemperature(8));
        }

        [Fact]
        public void DecreaseTemperature_ValueCannotBeNegative()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            Assert.Throws<ArgumentException>(() => thermostat.DecreaseTemperature(-1));
        }

        [Fact]
        public void DecreaseTemperature_WhenValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.DecreaseTemperature(40);
            Assert.Equal(thermostat.MinTemperature, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenValueDoesNotOverFlowTheRangeTemperatureIsSetCorrectly()
        {
            Thermostat thermostat = new(Name.CreateNew("Thermo1"));
            thermostat.DecreaseTemperature(2);
            Temperature expected = Temperature.CreateNew(16);
            Assert.Equal(expected, thermostat.Temperature);
        }
    }
}
