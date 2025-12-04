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
            if (rotation < minRotationDegrees)
                rotation = minRotationDegrees;
            else if (rotation > maxRotationDegrees)
                rotation = maxRotationDegrees;
            return rotation;
        }
        public static float ZoomValidator (float zoom)
        {
            if (zoom < minZoom)
                zoom = minZoom;
            else if (zoom > maxZoom)
                zoom = maxZoom;
            return zoom;
        }
    }
}
