using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV
{
    public static class CCTVValidator
    {
        public const float MaxRotationDegrees = 90;
        public const float MinRotationDegrees = -90;
        public const float MaxZoom = 10;
        public const float MinZoom = 1;

        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("Cannot modify CCTV when device is off");
        }

        public static void CheckIsPositive(float value)
        {
            if(value <= 0)
                throw new ArgumentException("value must be positive");
        }

        public static float RotationValidator (float rotation)
        {
            if (rotation < MinRotationDegrees)
                return MinRotationDegrees;

            if (rotation > MaxRotationDegrees)
                return MaxRotationDegrees;

            return rotation;
        }

        public static float ZoomValidator (float zoom)
        {
            if (zoom < MinZoom)
                return MinZoom;

            if (zoom > MaxZoom)
                return MaxZoom;

            return zoom;
        }
    }
}
