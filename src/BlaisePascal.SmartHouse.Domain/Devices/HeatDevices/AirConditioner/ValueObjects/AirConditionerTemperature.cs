using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects
{
    public sealed record AirConditionerTemperature
    {
        public const int MaxTemperature = 50;
        public const int MinTemperature = 0;
        public int Value { get; init; }

        private AirConditionerTemperature(int temperature)
        {
            Value = temperature;
        }

        public static AirConditionerTemperature CreateNew(int temperature)
        {
            if(temperature < MinTemperature)
                temperature = MinTemperature;

            if(temperature > MaxTemperature)
                temperature = MaxTemperature;

            return new AirConditionerTemperature(temperature);
        }


        public static int operator +(AirConditionerTemperature temperature, int value)
        {
            return temperature.Value + value;
        }

        public static int operator -(AirConditionerTemperature temperature, int value)
        {
            return temperature.Value - value;
        }
    }
}
