namespace BlaisePascal.SmartHouse.Domain.Devices.AirConditioner.ValueObjects
{
    public sealed record Temperature
    {
        public int value { get; init; }

        private Temperature(int temperature)
        {
            value = temperature;
        }

        public static Temperature CreateNew(int temperature)
        {
           if(temperature < AirConditionerValidator.MinTemperature || temperature > AirConditionerValidator.MaxTemperature)
                throw new ArgumentException($"Temperature must be between {AirConditionerValidator.MinTemperature} and {AirConditionerValidator.MaxTemperature}");
            
            return new Temperature(temperature);
        }


        public static int operator +(Temperature temperature, int value)
        {
            return temperature.value + value;
        }

        public static int operator -(Temperature temperature, int value)
        {
            return temperature.value - value;
        }


        public static bool operator ==(int value,Temperature temperature)
        {
            return value == temperature.value;
        }
        public static bool operator !=(int value, Temperature temperature)
        {
            return value != temperature.value;
        }
    }
}
