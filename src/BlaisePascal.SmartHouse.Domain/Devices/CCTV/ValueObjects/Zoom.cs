using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects
{
    public sealed record Zoom
    {
        public float value { get; init; }

        private Zoom(float zoom)
        {
            value = zoom;
        }   

        public static Zoom CreateNew(float zoom)
        {
            return new Zoom(CCTVValidator.ZoomValidator(zoom));
        }

        public static float operator +(Zoom zoom, float value)
        {
            return zoom.value + value;
        }
        public static float operator -(Zoom zoom, float value)
        {
            return zoom.value - value;
        }
    }
}
