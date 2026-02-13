using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.ValueObjects
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
           if(temperature < AirConditionerValidator.MinTemperature || temperature > AirConditionerValidator.MaxTemperature)
                throw new ArgumentException($"Temperature must be between {AirConditionerValidator.MinTemperature} and {AirConditionerValidator.MaxTemperature}");
            
            return new AirConditionerTemperature(temperature);
        }


        public static int operator +(AirConditionerTemperature temperature, int value)
        {
            return temperature.value + value;
        }

        public static int operator -(AirConditionerTemperature temperature, int value)
        {
            return temperature.value - value;
        }


        public static bool operator ==(int value,AirConditionerTemperature temperature)
        {
            return value == temperature.value;
        }
        public static bool operator !=(int value, AirConditionerTemperature temperature)
        {
            return value != temperature.value;
        }
    }
}
