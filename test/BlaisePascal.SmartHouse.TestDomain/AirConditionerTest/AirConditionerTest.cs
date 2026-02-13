using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.TestDomain.AirConditionerTest
{
    //FINISHED
    public class AirConditionerTest
    {
        [Fact]
        public void SetTemperature_CannotSetTemperatureWhenDeviceIsOff()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore");
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.SetTemperature(1));
        }
        
        [Fact]
        public void SetTemperature_WhenNewTemperatureIsLowerThanMinTemperatureIsSetAtMin()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new ("condizionatore", 10);
            airConditioner.SetTemperature(-1);
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenNewTemperatureIsGreaterThanMaxTemperatureIsSetAtMax()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SetTemperature(100);
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenTemperatureIsInMinMaxItIsSetCorrectly()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SetTemperature(35);
            Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature expected = Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature.CreateNew(35);
            Assert.Equal(expected, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseByDefaultValueWhenDeviceIsOff()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore");
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.IncreaseTemperature());
        }

        [Fact]
        public void IncreaseTemperatura_WhenDefaultValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 45);
            airConditioner.IncreaseTemperature();
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WithoutParameterTemperatureWillBeIncreaseByDefaultValue()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 30);
            airConditioner.IncreaseTemperature();
            Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature expected = Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature.CreateNew(40);
            Assert.Equal(expected, airConditioner.Temperature);
        }


        [Fact]
        public void IncreaseTemperature_WhenItIsIncreasedOverTheMaxTemperatureIsSetAtMax()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 50);
            airConditioner.IncreaseTemperature();
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.IncreaseTemperature(1));
        }

        [Fact]
        public void IncreaseTemperature_ValueCannotBeNegative()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            Assert.Throws<ArgumentException>(() => airConditioner.IncreaseTemperature(-1));
        }

        [Fact]
        public void IncreaseTemperature_WhenValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 45);
            airConditioner.IncreaseTemperature(10);
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenValueIsRightTemperatureIsSetCorrectly()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.IncreaseTemperature(10);
            Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature expected = Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature.CreateNew(30);
            Assert.Equal(expected, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotDecreaseByDefaultValueWhenDeviceIsOff()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.DecreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_WhenDefaultValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 5);
            airConditioner.DecreaseTemperature();
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WithoutParameterTemperatureWillBeDecreaseByDefaultValue()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 30);
            airConditioner.DecreaseTemperature();
            Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature expected = Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature.CreateNew(20);
            Assert.Equal(expected, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.DecreaseTemperature(1));
        }

        [Fact]
        public void DecreaseTemperature_ValueCannotBeNegative()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 10);
            Assert.Throws<ArgumentException>(() => airConditioner.DecreaseTemperature(-1));
        }

        [Fact]
        public void DecreaseTemperature_WhenValueIsLowerThanMinTemperatureIsSetAtMin()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.DecreaseTemperature(70);
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenValueIsRightTemperatureIsSetCorrectly()
        {
            Domain.Devices.HeatDevices.AirConditioner.AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.DecreaseTemperature(10);
            Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature expected = Domain.Devices.HeatDevices.ValueObjects.AirConditionerTemperature.CreateNew(10);
            Assert.Equal(expected, airConditioner.Temperature);
        }
    }
}
