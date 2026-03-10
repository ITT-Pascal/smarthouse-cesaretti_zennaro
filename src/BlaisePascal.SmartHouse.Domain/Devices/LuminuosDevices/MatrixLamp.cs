using BlaisePascal.SmartHouse.Domain.Devices.Abstraction;
using BlaisePascal.SmartHouse.Domain.Devices.Abstraction.ValueObjects;
using BlaisePascal.SmartHouse.Domain.Devices.Illumination.Abstraction;

namespace BlaisePascal.SmartHouse.Domain.Devices.LuminuosDevices
{
    public class MatrixLamp: AbstractDevice
    {
        public AbstractLamp[,] Matrix {  get; private set; }

        public override DeviceStatus DeviceStatus
        {
            get
            {
                DeviceStatus matrixStatus = DeviceStatus.Off;

                if (Matrix.GetLength(0) == 0 || Matrix.GetLength(1) == 0)
                {
                    matrixStatus = DeviceStatus.Off;
                }

                foreach (AbstractLamp lamp in Matrix)
                {
                    if (lamp.DeviceStatus == DeviceStatus.On)
                    {
                        matrixStatus = DeviceStatus.On;
                        break;
                    }
                }

                return matrixStatus;
            }
            protected set { }
        }



        public MatrixLamp(int r, int c, Name name) : base(name)
        {
            Matrix = new AbstractLamp[r, c];
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Matrix[i, j] = new Lamp(Name.CreateNew($"led{i}-{j}"));
                }
            }
        }
        
        public MatrixLamp(AbstractLamp[,] matrix, Name name): base(name)
        {
            Matrix = matrix;
        }

        public override void SwitchOff()
        {
            foreach(AbstractLamp led in Matrix)
            {
                led.SwitchOff();
            }
        }

        public override void SwitchOn()
        {
            foreach (AbstractLamp led in Matrix)
            {
                led.SwitchOn();
            }
        }

        public void SwitchOffInPosition(int row, int col)
        {
            if(row < 0 && row > Matrix.GetLength(0))
            {
                throw new ArgumentException("row not valid");
            }

            if (col < 0 && col > Matrix.GetLength(1))
            {
                throw new ArgumentException("column not valid");
            }

            Matrix[row, col].SwitchOff();
        }

        public void SwitchOnInPosition(int row, int col)
        {
            if (row < 0 && row > Matrix.GetLength(0))
            {
                throw new ArgumentException("row not valid");
            }

            if (col < 0 && col > Matrix.GetLength(1))
            {
                throw new ArgumentException("column not valid");
            }

            Matrix[row, col].SwitchOn();
        }

        public void AddLampInPosition(int row, int col, AbstractLamp lamp)
        {
            if (row < 0 && row > Matrix.GetLength(0))
            {
                throw new IndexOutOfRangeException("row not valid");
            }

            if (col < 0 && col > Matrix.GetLength(1))
            {
                throw new IndexOutOfRangeException("column not valid");
            }

            Matrix[row, col] = lamp;
        }


        public void RemoveLampInPosition(int row, int col, AbstractLamp lamp)
        {
            if (row < 0 && row > Matrix.GetLength(0))
            {
                throw new IndexOutOfRangeException("row not valid");
            }

            if (col < 0 && col > Matrix.GetLength(1))
            {
                throw new IndexOutOfRangeException("column not valid");
            }

            Matrix[row, col] = null;
        }

        public AbstractLamp? FindMinBrightnessLed()
        {
            Brightness minBrightness = Matrix[0, 0].Brightness;

            foreach(AbstractLamp lamp in Matrix)
            {
                if(lamp.Brightness < minBrightness)
                {
                    minBrightness = lamp.Brightness;
                }
            }

            foreach(AbstractLamp lamp in Matrix)
            {
                if(lamp.Brightness == minBrightness)
                {
                    return lamp;
                }
            } 

            return null;
        }

        public AbstractLamp? FindMaxBrightnessLed()
        {
            Brightness maxBrightness = Matrix[0, 0].Brightness;

            foreach (AbstractLamp lamp in Matrix)
            {
                if (lamp.Brightness > maxBrightness)
                {
                    maxBrightness = lamp.Brightness;
                }
            }

            foreach (AbstractLamp lamp in Matrix)
            {
                if (lamp.Brightness == maxBrightness)
                {
                    return lamp;
                }
            }

            return null;
        }
    }
}
