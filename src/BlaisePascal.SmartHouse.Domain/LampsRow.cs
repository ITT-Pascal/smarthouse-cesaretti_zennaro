using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{

    public class LampsRow
    {
        public List<AbstractLamp> Lamps { get; private set; }
        public DeviceStatus LampStatus { get; private set; }


        public LampsRow()
        {
            Lamps = new List<AbstractLamp>();
            LampStatus = DeviceStatus.Off;
        }

        public void SwitchOn()
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                lamp.SwitchOn();

            }
        }

        public void SwitchOn(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id && lamp.Status == DeviceStatus.Off)
                {
                    lamp.SwitchOn();
                }
                else
                {
                    throw new ArgumentException("not valid id");
                }
            }
        }

        public void SwitchOn(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name && lamp.Status == DeviceStatus.Off)
                {
                    lamp.SwitchOn();
                }
                else
                {
                    throw new ArgumentException("not valid name");
                }
            }
        }

        public void SwitchOff()
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                lamp.SwitchOn();
            }
        }
        public void SwitchOff(Guid id)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id && lamp.Status == DeviceStatus.Off)
                {
                    lamp.SwitchOff();
                }
                else
                {
                    throw new ArgumentException("not valid id");
                }
            }
        }

        public void SwitchOff(string name)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name && lamp.Status == DeviceStatus.Off)
                {
                    lamp.SwitchOff();
                }
                else
                {
                    throw new ArgumentException("not valid name");
                }
            }
        }

        public void Addlamp(AbstractLamp lamp)
        {
            Lamps.Add(lamp);
        }

        public void AddLampInPosition(AbstractLamp lamp, int position)
        {
            Lamps.Insert(position, lamp);
        }

        public void RemoveLamp(Guid id)
        {
            foreach (Lamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    Lamps.Remove(lamp);
                }
                else
                {
                    throw new ArgumentException("not valid id");
                }
            }
        }

        public void RemoveLamp(string name)
        {
            foreach (Lamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    Lamps.Remove(lamp);
                }
                else
                {
                    throw new ArgumentException("not valid name");
                }
            }
        }

        public void RemoveInPosition(int position)
        {
            Lamps.RemoveAt(LampValidator.IsValidPosition(position, 0, Lamps.Count - 1));
        }

        public void SetIntensityForAllLamps(int newBrightness)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                lamp.ChangeBrightness(newBrightness);
            }
        }
        public void SetIntensityForLamp(Guid id, int intensity)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    lamp.ChangeBrightness(intensity);
                }
            }
        }

        public void SetIntensityForLamp(string name, int intensity)
        {
            foreach (AbstractLamp lamp in Lamps)
            {
                if (lamp.Name == name)
                {
                    lamp.ChangeBrightness(intensity);
                }
            }
        }

        public AbstractLamp? FindLampWithMaxIntensity()
        {
             int maxLampBrightness = 0;
             bool hasFinded = false;
             foreach(AbstractLamp lamp in Lamps)
             {
                if(lamp.BrightnessPercentage > maxLampBrightness)
                {
                    maxLampBrightness = lamp.BrightnessPercentage;
                }
             }

            while (hasFinded == false) 
            { 
            }


             

             
        }

        public List<AbstractLamp> FindLampsByIntensityRange(int min, int max)
        {
            List<AbstractLamp> lampsInIntensityRange = new List<AbstractLamp>();
            foreach(AbstractLamp lamp in Lamps)
            {
                if(lamp.BrightnessPercentage >= min && lamp.BrightnessPercentage <= max)
                {
                    lampsInIntensityRange.Add(lamp);
                }
            }

            return lampsInIntensityRange;
        }

        public List<AbstractLamp> FindAllOn()
        {
            List<AbstractLamp> lampsOn = new List<AbstractLamp>();
            {
                foreach(AbstractLamp lamp in Lamps)
                {
                    if(lamp.Status == DeviceStatus.On)
                    {
                        lampsOn.Add(lamp);
                    }
                }
            }

            return lampsOn;
        }

        public List<AbstractLamp> FindAllOff()
        {
            List<AbstractLamp> lampsOff = new List<AbstractLamp>();
            {
                foreach (AbstractLamp lamp in Lamps)
                {
                    if (lamp.Status == DeviceStatus.Off)
                    {
                        lampsOff.Add(lamp);
                    }
                }
            }

            return lampsOff;
        }

        public AbstractLamp? FindLampById(Guid id)
        {
            int lampToReturn = 0;
            if(Lamps.Count == 0) 
                return null;

            foreach(AbstractLamp lamp in Lamps)
            {
                if (lamp.Id == id)
                {
                    return lamp;
                    lampToReturn++;
                }
            }


            if(Lamps.Count < 0)
            {
                return null;
            }
            
        }




    }
}

      

