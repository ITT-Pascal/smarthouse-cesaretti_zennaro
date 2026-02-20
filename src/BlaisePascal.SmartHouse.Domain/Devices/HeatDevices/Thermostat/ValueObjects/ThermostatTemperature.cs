namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.ValueObjects
{
    public sealed record ThermostatTemperature
    {
        public const int MaxTemperature = 30;
        public const int MinTemperature = 10;
        public int value { get; init; }

        private ThermostatTemperature(int temperature)
        {
            value = temperature;
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
            return temperature.value + value;
        }

        public static int operator -(ThermostatTemperature temperature, int value)
        {
            return temperature.value - value;
        }
    }
}
