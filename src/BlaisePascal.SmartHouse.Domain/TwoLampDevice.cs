using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class TwoLampDevice
    {
        public AbstractLamp[] Lamps { get; private set; }
        public TwoLampDevice(AbstractLamp firstLamp, AbstractLamp secondLamp)
        {
            Lamps = new AbstractLamp[3];
            Lamps[1] = firstLamp;
            Lamps[2] = secondLamp;
        }
        public void TurnLampsOn()
        {
            for (int i = 1; i < Lamps.Length; i++)
            {
                if (!Lamps[i].IsOn)
                    Lamps[i].SwitchOn_Off();
            }
        }
        public void TurnLampsOff()
        {
            for (int i = 1; i < Lamps.Length; i++)
            {
                if (Lamps[i].IsOn)
                    Lamps[i].SwitchOn_Off();
            }
        }
        public void SwitchLamp(int lampNumber)
        {
            if (lampNumber < 1 || lampNumber >= Lamps.Length)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].SwitchOn_Off();
        }
        public void ChangeLampBrightness(int lampNumber, int newBrightness)
        {
            if (lampNumber < 1 || lampNumber >= Lamps.Length)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].ChangeBrightness(newBrightness);
        }
        public void ChangeBothLampsBrightness(int newBrightness)
        {
            for (int i = 1; i < Lamps.Length; i++)
            {
                Lamps[i].ChangeBrightness(newBrightness);
            }
        }
        public void IncreaseLampBrightness(int lampNumber, int increaseBy)
        {
            if (lampNumber < 1 || lampNumber >= Lamps.Length)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].IncreaseBrightness(increaseBy);
        }
        public void DecreaseLampBrightness(int lampNumber, int decreaseBy)
        {
            if (lampNumber < 1 || lampNumber >= Lamps.Length)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].DecreaseBrightness(decreaseBy);
        }
        public void IncreaseBothLampsBrightness(int increaseBy)
        {
            for (int i = 1; i < Lamps.Length; i++)
            {
                Lamps[i].IncreaseBrightness(increaseBy);
            }
        }
        public void DecreaseBothLampsBrightness(int decreaseBy)
        {
            for (int i = 1; i < Lamps.Length; i++)
            {
                Lamps[i].DecreaseBrightness(decreaseBy);
            }
        }
        public void EcoSwitchOnLamps(TimeSpan timer)
        {
            for (int i = 1; i < Lamps.Length; i++)
            {
                if (Lamps[i] is EcoLamp ecoLamp)
                    ecoLamp.EcoSwitchOn(timer);
                else if (!Lamps[i].IsOn)
                    Lamps[i].SwitchOn_Off();
            }
        }
    }
}
