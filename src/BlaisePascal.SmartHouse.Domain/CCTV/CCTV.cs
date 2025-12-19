using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTV
{
    public class CCTV : AbstractDevice
    {
        public float MaxRotationDegrees { get; private set; } = 90;
        public float MinRotationDegrees { get; private set; } = -90;
        public float MaxZoom { get; private set; } = 10;
        public float MinZoom { get; private set; } = 0.5f;
        public bool IsRecording { get; private set; }
        public float ZoomValue {  get; private set; }
        public float Rotation {  get; private set; }
        public CCTV(string name) : base(name)
        {
            ZoomValue = 1;
            Rotation = 0;
            IsRecording = false;
        }
        public void SetRotationDegrees(float degrees)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");
        
            Rotation = CCTVValidator.RotationValidator(degrees);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseRotationDegrees(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            Rotation = Math.Min(MaxRotationDegrees, Rotation + CCTVValidator.IsValuePositive(value));
        }

        public void DecreaseRotationDegrees(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            Rotation = Math.Max(MinRotationDegrees, Rotation - CCTVValidator.IsValuePositive(value));
            LastModified = DateTime.Now;
        }

        public void SetZoom(float zoom)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            ZoomValue = CCTVValidator.ZoomValidator(zoom);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseZoom(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            Rotation = Math.Min(MaxZoom, ZoomValue + CCTVValidator.IsValuePositive(value));
            LastModified = DateTime.Now;
        }

        public void DecreaseZoom(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            Rotation = Math.Max(MinZoom, ZoomValue - CCTVValidator.IsValuePositive(value));
            LastModified = DateTime.Now;
        }
        public void StartRecording()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            IsRecording = true;
            LastModified = DateTime.UtcNow;
        }
        public void StopRecording()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            IsRecording = false;
            LastModified = DateTime.UtcNow;
        }
    }
}
