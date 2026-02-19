using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.Illumination
{
    public class TwoLampDevice: AbstractDevice
    {
        public AbstractLamp FirstLamp { get; private set; }
        public AbstractLamp SecondLamp { get; private set; }
        public DeviceStatus DeviceStatus
        {
            get
            {
                DeviceStatus Status = DeviceStatus.Off;
                
                if (FirstLamp.Status == DeviceStatus.On || SecondLamp.Status == DeviceStatus.On)
                    return DeviceStatus.On;

                return Status;
            }

            private set { }
        }


        public TwoLampDevice(AbstractLamp firstLamp, AbstractLamp secondLamp, Name name): base(name)
        {
            FirstLamp = firstLamp;
            SecondLamp = secondLamp;
        }


        public override void SwitchOn()
        {
            if(FirstLamp.Status == DeviceStatus.Off)
                FirstLamp.SwitchOn();

            if(SecondLamp.Status == DeviceStatus.Off)
                SecondLamp.SwitchOn();  
        }

        public void SwitchLampOn(Guid id)
        {
            if (FirstLamp.Id == id) 
            {
                FirstLamp.SwitchOn();
            }
            else if(SecondLamp.Id == id)
            {
                SecondLamp.SwitchOn();
            }
            else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void SwitchLampOn(string name)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.SwitchOn();
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.SwitchOn();
            } else
            {
                throw new ArgumentException("non valid name");
            }
        }

        public void EcoSwitchOn(Guid id)
        {
            if (FirstLamp.Id == id && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn();
            } else if(SecondLamp.Id == id && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn();
            } else
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void EcoSwitchOnLamp(string name)
        {
            if (FirstLamp.Name == name && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn();
            }
            else if (SecondLamp.Name == name && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn();
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }

        public void EcoSwitchOnLamp(Guid id, int timer)
        {
            if (FirstLamp.Id == id && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn(timer);
            }
            else if (SecondLamp.Id == id && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn(timer);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }

        public void EcoSwitchOnLamp(string name, int timer)
        {
            if (FirstLamp.Name == name && FirstLamp is EcoLamp firstLamp)
            {
                firstLamp.EcoSwitchOn(timer);
            }
            else if (SecondLamp.Name == name && SecondLamp is EcoLamp secondLamp)
            {
                secondLamp.EcoSwitchOn(timer);
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }

        public override void SwitchOff()
        {
            if(FirstLamp.Status == DeviceStatus.On)
                FirstLamp.SwitchOff();

            if(SecondLamp.Status == DeviceStatus.On)
                SecondLamp.SwitchOff();
        }

        public void SwitchLampOff(Guid id)
        {
            if (FirstLamp.Id == id)
            {
                FirstLamp.SwitchOff();
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.SwitchOff();
            }
            else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void SwitchLampOff(string name)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.SwitchOff();
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.SwitchOff();
            } else
            {
                throw new ArgumentException("non valid name");
                
            }
        }

        public void SetBothLampsBrightness(Brightness newBrightness)
        {
            FirstLamp.SetBrightness(newBrightness);
            SecondLamp.SetBrightness(newBrightness);
        }

        public void SetLampBrightness(Guid id, Brightness newBrightness)
        {
            if(FirstLamp.Id == id)
            {
                FirstLamp.SetBrightness(newBrightness);
            }
            else if(SecondLamp.Id == id)
            {
                SecondLamp.SetBrightness(newBrightness);
            } else
            {
                throw new ArgumentException("non valid id");
            }
        }

        public void SetLampBrightness(string name, int newBrightness)
        {
            if (FirstLamp.Name == name)
            {
                FirstLamp.SetBrightness(newBrightness);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.SetBrightness(newBrightness);
            }
            else
            {
                throw new ArgumentException("non valid name");
            }
        }

        public void BrightenLamp(int value)
        {
            FirstLamp.Brighten(value);
            SecondLamp.Brighten(value);
        }

        public void IncreaseLampBrightness(Guid id, int step)
        {

            if (FirstLamp.Id == id)
            {
                FirstLamp.Brighten(step);
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.Brighten(step);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }


        public void IncreaseLampBrightness(string name, int step)
        {

            if (FirstLamp.Name == name)
            {
                FirstLamp.Brighten(step);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.Brighten(step);
            } else
            {
                throw new ArgumentException("not valid name");
            }
        }


        public void DecreaseBothLampsBrightness(int step)
        {
            FirstLamp.Dimmer(step);
            SecondLamp.Dimmer(step);
        }

        public void DecreaseLampBrightness(Guid id, int step)
        {

            if (FirstLamp.Id == id)
            {
                FirstLamp.Dimmer(step);
            }
            else if (SecondLamp.Id == id)
            {
                SecondLamp.Dimmer(step);
            }
            else
            {
                throw new ArgumentException("not valid id");
            }
        }


        public void DecreaseLampBrightness(string name, int step)
        {

            if (FirstLamp.Name == name)
            {
                FirstLamp.Dimmer(step);
            }
            else if (SecondLamp.Name == name)
            {
                SecondLamp.Dimmer(step);
            }
            else
            {
                throw new ArgumentException("not valid name");
            }
        }
    }
}
