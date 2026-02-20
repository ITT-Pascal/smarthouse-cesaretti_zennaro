namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.ValueObjects
{
    public sealed record ThermostatTemperature
    {
        public const int MaxTemperature = 30;
        public const int MinTemperature = 10;
        public int Value { get; init; }

        private ThermostatTemperature(int temperature)
        {
            Value = temperature;
        }
        
        public static ThermostatTemperature CreateNew(int temperature)
        {
            if(temperature < MinTemperature)
                temperature = MinTemperature;

            if (temperature > MaxTemperature)
                temperature = MaxTemperature;
            
            return new ThermostatTemperature(temperature);
        }

        public static int operator +(ThermostatTemperature temperature, int value)
        {
            return temperature.Value + value;
        }

        public static int operator -(ThermostatTemperature temperature, int value)
        {
            return temperature.Value - value;
        }
    }
}
