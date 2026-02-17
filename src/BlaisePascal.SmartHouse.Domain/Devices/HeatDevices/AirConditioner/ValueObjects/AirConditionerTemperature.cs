using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects
{
    public sealed record AirConditionerTemperature
    {
        public int value { get; init; }

        private AirConditionerTemperature(int temperature)
        {
            value = temperature;
        }

        public static AirConditionerTemperature CreateNew(int temperature)
        {
            return new AirConditionerTemperature(AirConditionerValidator.TemperatureValueValidator(temperature));
        }


        public static int operator +(AirConditionerTemperature temperature, int value)
        {
            return temperature.value + value;
        }

        public static int operator -(AirConditionerTemperature temperature, int value)
        {
            return temperature.value - value;
        }
    }
}
