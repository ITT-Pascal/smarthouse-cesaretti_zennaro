using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Validator
{
    public static class CCTVValidator
    {
        private const float maxRotationDegrees = 90;
        private const float minRotationDegrees = -90;
        private const float maxZoom = 10;
        private const float minZoom = 0.5f;
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
    }
}
