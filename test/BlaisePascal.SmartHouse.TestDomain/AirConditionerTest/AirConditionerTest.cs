using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects;

namespace BlaisePascal.SmartHouse.TestDomain.AirConditionerTest
{
    public class AirConditionerTest
    {

        [Fact]
        public void SetTemperature_CannotSetTemperatureWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"));
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.SetTemperature(AirConditionerTemperature.CreateNew(10)));
        }
        
        [Fact]
        public void SetTemperature_WhenNewTemperatureIsLowerThanMinTemperatureIsSetAtMin()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"));
            airConditioner.SetTemperature(AirConditionerTemperature.CreateNew(-100));
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenNewTemperatureIsGreaterThanMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(10));
            airConditioner.SetTemperature(AirConditionerTemperature.CreateNew(100));
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void SetTemperature_WhenTemperatureIsInMinMaxItIsSetCorrectly()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(10));
            airConditioner.SetTemperature(AirConditionerTemperature.CreateNew(35));
            AirConditionerTemperature expected = AirConditionerTemperature.CreateNew(35);
            Assert.Equal(expected, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseByDefaultValueWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"));
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.IncreaseTemperature());
        }

        [Fact]
        public void IncreaseTemperatura_WhenDefaultValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore") , AirConditionerTemperature.CreateNew(45));
            airConditioner.IncreaseTemperature();
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WithoutParameterTemperatureWillBeIncreaseByDefaultValue()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore") , AirConditionerTemperature.CreateNew(30));
            airConditioner.IncreaseTemperature();
            AirConditionerTemperature expected = AirConditionerTemperature.CreateNew(40);
            Assert.Equal(expected, airConditioner.Temperature);
        }


        [Fact]
        public void IncreaseTemperature_WhenItIsIncreasedOverTheMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(50));
            airConditioner.IncreaseTemperature();
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(10));
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.IncreaseTemperature(1));
        }

        [Fact]
        public void IncreaseTemperature_ValueCannotBeNegative()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(10));
            Assert.Throws<ArgumentException>(() => airConditioner.IncreaseTemperature(-1));
        }

        [Fact]
        public void IncreaseTemperature_WhenValueGoesOverTheMaxTemperatureIsSetAtMax()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(45));
            airConditioner.IncreaseTemperature(10);
            Assert.Equal(airConditioner.MaxTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void IncreaseTemperature_WhenValueIsRightTemperatureIsSetCorrectly()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(20));
            airConditioner.IncreaseTemperature(10);
            AirConditionerTemperature expected = AirConditionerTemperature.CreateNew(30);
            Assert.Equal(expected, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotDecreaseByDefaultValueWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore") , AirConditionerTemperature.CreateNew(10));
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.DecreaseTemperature());
        }

        [Fact]
        public void DecreaseTemperature_WhenDefaultValueGoesUnderTheMinTemperatureIsSetAtMin()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(5));
            airConditioner.DecreaseTemperature();
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WithoutParameterTemperatureWillBeDecreaseByDefaultValue()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(30));
            airConditioner.DecreaseTemperature();
            AirConditionerTemperature expected = AirConditionerTemperature.CreateNew(20);
            Assert.Equal(expected, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_CannotIncreaseTemperatureWhenDeviceIsOff()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(10));
            airConditioner.SwitchOff();
            Assert.Throws<InvalidOperationException>(() => airConditioner.DecreaseTemperature(1));
        }

        [Fact]
        public void DecreaseTemperature_ValueCannotBeNegative()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(10));
            Assert.Throws<ArgumentException>(() => airConditioner.DecreaseTemperature(-1));
        }

        [Fact]
        public void DecreaseTemperature_WhenValueIsLowerThanMinTemperatureIsSetAtMin()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(20));
            airConditioner.DecreaseTemperature(70);
            Assert.Equal(airConditioner.MinTemperature, airConditioner.Temperature);
        }

        [Fact]
        public void DecreaseTemperature_WhenValueIsRightTemperatureIsSetCorrectly()
        {
            AirConditioner airConditioner = new(Name.CreateNew("condizionatore"), AirConditionerTemperature.CreateNew(20));
            airConditioner.DecreaseTemperature(10);
            AirConditionerTemperature expected = AirConditionerTemperature.CreateNew(10);
            Assert.Equal(expected, airConditioner.Temperature);
        }
    }
}
