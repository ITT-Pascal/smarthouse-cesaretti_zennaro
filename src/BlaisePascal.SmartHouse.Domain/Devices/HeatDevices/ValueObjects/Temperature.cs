using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects
{
    public sealed record Temperature
    {
        private const int MinAirConditionerTemperature = 10;
        private const int MaxAirConditionerTemperature = 50;
        private const int MinThermostatTemperature = 10;
        private const int MaxThermostatTemperature = 30;

        public int Value { get; init; }

        private Temperature(int temperature)
        {
            Value = temperature;
        }

        public static Temperature CreateNew(int temperature)
        {
            return new Temperature(temperature);
        }

        public static Temperature AirConditionerCreateNew(int temperature)
        {
            if(temperature < MinAirConditionerTemperature) 
                temperature = MinAirConditionerTemperature;

            if(temperature > MaxAirConditionerTemperature)
                temperature = MaxAirConditionerTemperature;

            return new Temperature(temperature);
        }

        public static Temperature ThermostatCreateNew(int temperature)
        {
            if(temperature < MinThermostatTemperature) 
                temperature = MinThermostatTemperature;

            if(temperature > MaxThermostatTemperature)
                temperature = MaxThermostatTemperature;

            return new Temperature(temperature);
        }

        public static int operator +(Temperature temperature, int value)
        {
            return temperature.Value + value;
        }

        public static int operator -(Temperature temperature, int value)
        {
            return temperature.Value - value;
        }
    }
}
