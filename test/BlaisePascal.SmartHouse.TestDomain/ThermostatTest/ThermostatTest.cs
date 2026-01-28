using BlaisePascal.SmartHouse.Domain.Thermostat;

namespace BlaisePascal.SmartHouse.TestDomain.ThermostatTest
{
    //FINISHED
    public class ThermostatTest
    {
        [Fact]
        public void SetTemperature_CannotSetTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperature(100));
        }
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
        public void SetTemperature_CannotSetDefaultTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.SetTemperature());
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
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.IncreaseTemperature());
        }

        [Fact]
        public void IncreaseTemperature_ValueCannotBeNegative()
        {
            Thermostat thermostat = new("Thermo1");
            Assert.Throws<ArgumentException>(() => thermostat.IncreaseTemperature(-1));
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
            Thermostat thermostat = new("Thermo1");
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.IncreaseTemperature(7));
        }

        [Fact]
        public void DecreaseTemperture_WithoutParametersTemperatureIsDecreasedByDefaultValue()
        {
            Thermostat thermostat = new("Thermo1");
            thermostat.DecreaseTemperature();
            Assert.Equal(14, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenDefaultValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Thermostat thermostat = new("Thermo1", 1);
            thermostat.DecreaseTemperature();
            Assert.Equal(thermostat.MinTemperature, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotDecreaseByDefaultValueWhenDeviceIsOff()
        {
            Thermostat thermostat = new("Thermo");
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.DecreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_WhenValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Thermostat thermostat = new("Thermo");
            thermostat.DecreaseTemperature(40);
            Assert.Equal(thermostat.MinTemperature, thermostat.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_ValueCannotBeNegative()
        {
            Thermostat thermostat = new("Thermo");
            Assert.Throws<ArgumentException>(() => thermostat.DecreaseTemperature(-1));
        }

        [Fact]
        public void DecreaseTemperature_CannotDecreaseTemperatureWhenDeviceIsOff()
        {
            Thermostat thermostat = new("Thermo");
            thermostat.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => thermostat.DecreaseTemperature(8));
        }

        [Fact]
        public void DecreaseTemperature_WhenValueDoesNotOverFlowTheRangeTemperatureIsSetCorrectly()
        {
            Thermostat thermostat = new("Thermo");
            thermostat.DecreaseTemperature(2);
            Assert.Equal(16, thermostat.Temperature);
        }
    }
}
