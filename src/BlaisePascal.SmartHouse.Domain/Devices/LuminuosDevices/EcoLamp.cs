using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices.Abstraction.ValueObjects;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class EcoLamp : AbstractLamp
    {
        public override Brightness DefaultBrigthness { get; protected set; } = Brightness.CreateNew(35);
        public override Brightness MaxBrightness { get; protected set; } = Brightness.CreateNew(75);
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        private DateTime? autoOffAtUtc;

        public EcoLamp(Brightness brightness, Name name) : base(brightness, name)
        {

        }
        public EcoLamp(Name name) : base(name)
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
            AbstractLampValidator.CheckIsOn(Status);
            AbstractLampValidator.IsPositive(value);
            Brightness = Brightness.CreateNewEco(Brightness + value);
            LastModified = DateTime.UtcNow;
            ResetAutoOffIfNeeded();
        }

        public override void Dimmer(int value)
        {
            AbstractLampValidator.CheckIsOn(Status);
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
            if (Status == DeviceStatus.On &&
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

