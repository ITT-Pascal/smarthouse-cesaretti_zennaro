using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices
{
    public class EcoLamp : AbstractLamp
    {
        public override Brightness DefaultBrigthness { get; protected set; } = Brightness.CreateNew(35);
        public override Brightness MaxBrightness { get; protected set; } = Brightness.CreateNew(75);
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        private DateTime? autoOffAtUtc;

        public EcoLamp(Name name) : base(name)
        {

        }

        public EcoLamp(Brightness brightness, Name name) : base(brightness, name)
        {

        }

        public EcoLamp(Guid id, Name name, DeviceStatus status, DateTime creationHour, DateTime lastModified, Brightness brightness) : base(id, name, status, creationHour, lastModified, brightness)
        {

        }
        public override void SwitchOn()
        {
            EcoSwitchOn(enableAutoOff: false);
        }

        public void EcoSwitchOn(bool enableAutoOff)
        {
            base.SwitchOn();
            autoOffAtUtc = enableAutoOff
                ? DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes)
                : null;
        }

        public void EcoSwitchOn(int autoOffMinutes)
        {
            if (autoOffMinutes < MinAutoOffMinutes)
                throw new ArgumentOutOfRangeException(nameof(autoOffMinutes));

            base.SwitchOn();
            autoOffAtUtc = DateTime.UtcNow.AddMinutes(autoOffMinutes);
        }

        public override void SetBrightness(Brightness brightness)
        {
            Brightness newBrightness = Brightness.CreateNewEco(brightness.Value);
            base.SetBrightness(newBrightness);
            ResetAutoOffIfNeeded();
        }

        public override void Brighten(int value)
        {
            AbstractLampValidator.CheckIsOn(DeviceStatus);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNewEco(Brightness + value);
            LastModified = DateTime.UtcNow;
            ResetAutoOffIfNeeded();
        }

        public override void Dimmer(int value)
        {
            AbstractLampValidator.CheckIsOn(DeviceStatus);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNewEco(Brightness - value);
            LastModified = DateTime.UtcNow;
            ResetAutoOffIfNeeded();
        }

        public override void SwitchOff()
        {
            base.SwitchOff();
            autoOffAtUtc = null;
        }

        public void EcoSwitchOn()
        {
            if (DeviceStatus == DeviceStatus.On &&
                autoOffAtUtc.HasValue &&
                DateTime.UtcNow >= autoOffAtUtc.Value)
            {
                SwitchOff();
            }
        }

        private void ResetAutoOffIfNeeded()
        {
            if (autoOffAtUtc.HasValue)
                autoOffAtUtc = DateTime.UtcNow.AddMinutes(DefaultAutoOffMinutes);
        }
    }
}

