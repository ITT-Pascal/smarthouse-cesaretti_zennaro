using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner;
using BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices.AirConditioner.ValueObjects
{
    public sealed record Temperature
    {
        private const int MinAirConditionerTemperature = 10;
        private const int MaxAirConditionerTemperature = 50;
        private const int MinThermostatTemperature = 10;
        private const int MaxThermostatTemperature = 30;
        private const int DeaultAirConditionerTemperature = 18;
        private const int DefaultThermostatTemperature = 18;

        public int Value { get; init; }

        private Temperature(int temperature)
        {
            Value = temperature;
        }

        public static Temperature CreateNew(int temperature)
        {
            return new Temperature(temperature);
        }

        public static Temperature CreateNewMin(TemperatureType temperatureType)
        {
            Temperature minTemperature;

            if(temperatureType == TemperatureType.AIR_CONDITIONER)
            {
                minTemperature = CreateNew(MinAirConditionerTemperature);
            } else
            {
                minTemperature = CreateNew(MinThermostatTemperature);
            }

            return minTemperature;
        }

        public static Temperature CreateNewMax(TemperatureType temperatureType)
        {
            Temperature maxTemperature;

            if(temperatureType == TemperatureType.AIR_CONDITIONER)
            {
                maxTemperature = CreateNew(MaxAirConditionerTemperature);
            } else
            {
                maxTemperature = CreateNew(DefaultThermostatTemperature);
            }

            return maxTemperature;
        }

        public static Temperature CreateNewDefault(TemperatureType temperatureType)
        {
            Temperature defaultTemperature;

            if(temperatureType == TemperatureType.AIR_CONDITIONER)
            {
                defaultTemperature = CreateNew(DeaultAirConditionerTemperature);
            } else
            {
                defaultTemperature = CreateNew(DefaultThermostatTemperature);
            }

            return defaultTemperature;

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
