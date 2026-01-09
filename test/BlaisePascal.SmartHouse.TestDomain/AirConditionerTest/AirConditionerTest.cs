using BlaisePascal.SmartHouse.Domain.AirConditioner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.TestDomain.AirConditionerTest
{
    public class AirConditionerTest
    {
        [Fact]
        public void SetTemperature_CannotSetTemperatureWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new("condizionatore");
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.SetTemperature(1));
        }
        
        [Fact]
        public void SetTemperature_WhenNewTemperatureIsLowerThanMinTemperatureIsSetAtMin()
        {
            AirConditioner airConditioner = new ("condizionatore", 10);
            airConditioner.SetTemperature(-1);
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenNewTemperatureIsGreaterThanMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SetTemperature(100);
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenTemperatureIsInMinMaxItIsSetCorrectly()
        {
            AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SetTemperature(35);
            Assert.Equal(35, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WithoutParameterTemperatureWillBeIncreaseByDefaultValue()
        {
            AirConditioner airConditioner = new("condizionatore", 30);
            airConditioner.IncreaseTemperature();
            Assert.Equal(40, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenItIsIncreasedOverTheMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new("condizionatore", 50);
            airConditioner.IncreaseTemperature();
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_ValueCannotBeNegative()
        {
            AirConditioner airConditioner = new("condizionatore", 10);
            Assert.Throws<ArgumentException>(() => airConditioner.IncreaseTemperature(-1));
        }

        [Fact]
        public void IncreaseTemperature_WhenValueIsGreaterThanMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.IncreaseTemperature(70);
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenValueIsRightTemperatureIsSetCorrectly()
        {
            AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.IncreaseTemperature(10);
            Assert.Equal(30, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.IncreaseTemperature(1));
        }

        [Fact]
        public void DecreaseTemperature_WithoutParameterTemperatureWillBeDecreaseByDefaultValue()
        {
            AirConditioner airConditioner = new("condizionatore", 30);
            airConditioner.DecreaseTemperature();
            Assert.Equal(20, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenItIsIncreasedLowerThanMinTemperatureIsSetAtMin()
        {
            AirConditioner airConditioner = new("condizionatore", 0);
            airConditioner.DecreaseTemperature();
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_ValueCannotBeNegative()
        {
            AirConditioner airConditioner = new("condizionatore", 10);
            Assert.Throws<ArgumentException>(() => airConditioner.DecreaseTemperature(-1));
        }

        [Fact]
        public void DecreaseTemperature_WhenValueIsLowerThanMinTemperatureIsSetAtMin()
        {
            AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.DecreaseTemperature(70);
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenValueIsRightTemperatureIsSetCorrectly()
        {
            AirConditioner airConditioner = new("condizionatore", 20);
            airConditioner.DecreaseTemperature(10);
            Assert.Equal(10, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new("condizionatore", 10);
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.DecreaseTemperature(1));
        }

    }

}
