using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects
{
    public sealed record Zoom
    {
        public float Value { get; init; }

        private Zoom(float zoom)
        {
            Value = zoom;
        }   

        public static Zoom CreateNew(float zoom)
        {
            return new Zoom(CCTVValidator.ZoomValidator(zoom));
        }

        public static float operator +(Zoom zoom, float value)
        {
            return zoom.Value + value;
        }
        public static float operator -(Zoom zoom, float value)
        {
            return zoom.Value - value;
        }
    }
}
