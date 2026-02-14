using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects
{
    public sealed record Rotation
    {
        public float value { get; init; }
        private Rotation(float rotation)
        {
            value = rotation;
        }
        public static Rotation CreateNew(float rotation)
        {
            CCTVValidator.RotationValidator(rotation);
            return new Rotation(rotation);
        }

        public static float operator +(Rotation rotation, int value)
        {
            return rotation.value + value;
        }
        public static float operator -(Rotation rotation, int value)
        {
            return rotation.value - value;
        }
    }
}
