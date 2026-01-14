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
        public const float MaxRotationDegrees = 90;
        public const float MinRotationDegrees = -90;
        public const float MaxZoom = 10;
        public const float MinZoom = 0.5f;

        public static void CheckIsOn(DeviceStatus status)
        {
            if (status != DeviceStatus.On)
                throw new InvalidOperationException("Cannot modify CCTV when device is off");
        }

        public static void CheckIsPositive(int value)
        {
            if(value <= 0)
                throw new ArgumentOutOfRangeException("value must be positive");
        }
        public static float RotationValidator (float rotation)
        {
            if (rotation < MinRotationDegrees || rotation > MaxRotationDegrees)
                throw new ArgumentOutOfRangeException($"Rotation must be between {MinRotationDegrees} and {MaxRotationDegrees} degrees.");
            return rotation;
        }

        public static float ZoomValidator (float zoom)
        {
            if (zoom < MinZoom || zoom > MaxZoom)
                throw new ArgumentOutOfRangeException($"Zoom must be between {MinZoom} and {MaxZoom}.");
            return zoom;
        }

        public static int IsValuePositive(int value)
        {
            if (value < MinZoom || value > MaxZoom)
                throw new ArgumentOutOfRangeException($"Zoom must be between {MinZoom} and {MaxZoom}.");
            
            return value;
        }
    }
}
