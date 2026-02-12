using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class EcoLamp : AbstractLamp
    {
        public override Brightness MaxBrightness { get; protected set; } = Brightness.CreateNew(70);
        public override Brightness DefaultBrigthness { get; protected set; } = Brightness.CreateNew(35);
        private const int DefaultAutoOffMinutes = 10;
        private const int MinAutoOffMinutes = 1;

        private DateTime? autoOffAtUtc;

        public EcoLamp(int brightness, string name) : base(brightness, name)
        {

        }
        public EcoLamp(string name) : base(name)
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

        public override void SetBrightness(int value)
        {
            base.SetBrightness(value);
            ResetAutoOffIfNeeded();
        }

        public override void Dimmer(int value)
        {
            base.Dimmer(value);
            ResetAutoOffIfNeeded();
        }

        public override void Brighten(int value)
        {
            base.Brighten(value);
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
}
