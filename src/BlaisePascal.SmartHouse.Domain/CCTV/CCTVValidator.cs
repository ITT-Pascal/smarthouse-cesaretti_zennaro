using BlaisePascal.SmartHouse.Domain.Asbtraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    public static class CCTVValidator
    {
        public const float maxRotationDegrees = 90;
        public const float minRotationDegrees = -90;
        public const float maxZoom = 10;
        public const float minZoom = 0.5f;

        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("Cannot modify CCTV when device is off");
        }

        public static int CheckIsPositive(int value)
        {
            if(value <= 0)
                throw new ArgumentOutOfRangeException("value must be positive");
        }
        public static float RotationValidator (float rotation)
        {
            if (rotation < minRotationDegrees || rotation > maxRotationDegrees)
                throw new ArgumentOutOfRangeException($"Rotation must be between {minRotationDegrees} and {maxRotationDegrees} degrees.");
            return rotation;
        }

        public static float ZoomValidator (float zoom)
        {
            if (zoom < minZoom || zoom > maxZoom)
                throw new ArgumentOutOfRangeException($"Zoom must be between {minZoom} and {maxZoom}.");
            return zoom;
        }

        public static int IsValuePositive(int value)
        {
            if (value < minZoom || value > maxZoom)
                throw new ArgumentOutOfRangeException($"Zoom must be between {minZoom} and {maxZoom}.");
            
            return value;
        }
    }
}
