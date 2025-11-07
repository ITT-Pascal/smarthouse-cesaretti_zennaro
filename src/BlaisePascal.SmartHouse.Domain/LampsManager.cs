using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class LampsManager
    {
        public List<AbstractLamp> Lamps { get; private set; }
        public LampsManager()
        {
            Lamps = new List<AbstractLamp>();
        }
        public void AddLamp(AbstractLamp lamp)
        {
            Lamps.Add(lamp);
        }
        public void TurnLampsOn()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (!Lamps[i].IsOn)
                    Lamps[i].SwitchOn_Off();
            }
        }
        public void TurnLampsOff()
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i].IsOn)
                    Lamps[i].SwitchOn_Off();
            }
        }
        public void SwitchLamp(int lampNumber)
        {
            if (lampNumber < 0 || lampNumber >= Lamps.Count)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].SwitchOn_Off();
        }
        public void ChangeLampBrightness(int lampNumber, int newBrightness)
        {
            if (lampNumber < 0 || lampNumber >= Lamps.Count)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].ChangeBrightness(newBrightness);
        }
        public void ChangeAllLampsBrightness(int newBrightness)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].ChangeBrightness(newBrightness);
            }
        }
        public void IncreaseLampBrightness(int lampNumber, int increaseBy)
        {
            if (lampNumber < 0 || lampNumber >= Lamps.Count)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].IncreaseBrightness(increaseBy);
        }
        public void DecreaseLampBrightness(int lampNumber, int decreaseBy)
        {
            if (lampNumber < 0 || lampNumber >= Lamps.Count)
                throw new ArgumentException("Lamp number not valid");
            Lamps[lampNumber].DecreaseBrightness(decreaseBy);
        }
        public void IncreaseAllLampsBrightness(int increaseBy)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].IncreaseBrightness(increaseBy);
            }
        }
        public void DecreaseAllLampsBrightness(int decreaseBy)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                Lamps[i].DecreaseBrightness(decreaseBy);
            }
        }
        public void EcoSwitchOnLamps(TimeSpan timer)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i] is EcoLamp ecoLamp)
                    ecoLamp.EcoSwitchOn(timer);
                else if (!Lamps[i].IsOn)
                    Lamps[i].SwitchOn_Off();
            }
        }
        public void ExclusiveEcoSwitchOnLamps(TimeSpan timer)
        {
            for (int i = 0; i < Lamps.Count; i++)
            {
                if (Lamps[i] is EcoLamp ecoLamp)
                    ecoLamp.EcoSwitchOn(timer);
            }
        }
    }
}
