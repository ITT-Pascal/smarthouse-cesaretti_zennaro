using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.Devices.CCTV.ValueObjects
{
    public sealed record Rotation
    {
        public float Value { get; init; }
        private Rotation(float rotation)
        {
            Value = rotation;
        }
        public static Rotation CreateNew(float rotation)
        {
            return new Rotation(CCTVValidator.RotationValidator(rotation));
        }

        public static float operator +(Rotation rotation, float value)
        {
            return rotation.Value + value;
        }
        public static float operator -(Rotation rotation, float value)
        {
            return rotation.Value - value;
        }
    }
}
