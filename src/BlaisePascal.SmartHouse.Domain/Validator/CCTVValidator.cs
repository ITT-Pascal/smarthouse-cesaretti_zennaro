using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Validator
{
    public static class CCTVValidator
    {
        public const float maxRotationDegrees = 90;
        public const float minRotationDegrees = -90;
        public const float maxZoom = 10;
        public const float minZoom = 0.5f;
        public static float RotationValidator (float rotation)
        {
            float newRotation = 0;
            if (rotation < minRotationDegrees)
                newRotation = minRotationDegrees;
            else if (rotation > maxRotationDegrees)
                newRotation = maxRotationDegrees;
            else
                newRotation = rotation;
            return newRotation;
        }
        public static float ZoomValidator (float zoom)
        {
            float newZoom = 0;
            if (zoom < minZoom)
                newZoom = minZoom;
            else if (zoom > maxZoom)
                newZoom = maxZoom;
            else
                newZoom = zoom;
            return zoom;
        }
    }
}
