namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.Thermostat.ValueObjects
{
    public sealed record ThermostatTemperature
    {
        public int value { get; init; }

        private ThermostatTemperature(int temperature)
        {
            value = temperature;
        }
        
        public static ThermostatTemperature CreateNew(int temperature)
        {
            return new ThermostatTemperature(ThermostatValidator.TemperatureValueValidator(temperature));
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
