namespace BlaisePascal.SmartHouse.Domain.Devices.HeatDevices
{
    public interface IHeatDevices
    {
        void SetTemperature(ITemperature temperature);
        void SetTemperature();
        void IncreaseTemperature();
        void IncreaseTemperature(int value);
        void DecreaseTemperature();
        void DecreaseTemperature(int value);
    }
}
