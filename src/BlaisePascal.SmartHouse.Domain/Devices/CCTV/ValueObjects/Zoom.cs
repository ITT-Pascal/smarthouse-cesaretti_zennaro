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
            if(zoom < CCTVValidator.MinZoom || zoom > CCTVValidator.MaxZoom)
                throw new ArgumentException($"Zoom must be between {CCTVValidator.MinZoom} and {CCTVValidator.MaxZoom}");
            
            return new Zoom(zoom);
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
