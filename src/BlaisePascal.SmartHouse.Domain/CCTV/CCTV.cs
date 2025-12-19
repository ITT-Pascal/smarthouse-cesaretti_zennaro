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
        public bool IsRecording { get; private set; }
        public float ZoomValue {  get; private set; }
        public float RotationValue {  get; private set; }
        public CCTV(string name) : base(name)
        {
            ZoomValue = 0;
            RotationValue = 0;
            IsRecording = false;
        }

        public CCTV(string name, bool isRecording, float zoomValue, float rotation): base(name)
        {
            IsRecording = isRecording;
            ZoomValue = zoomValue;
            RotationValue = rotation;
        }

        public void SetRotationDegrees(float degrees)
        {
            CCTVValidator.CheckIsOn(Status);
            RotationValue = CCTVValidator.RotationValidator(degrees);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseRotationDegrees(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            RotationValue = Math.Min(CCTVValidator.RotationValidator(value));
        } 

        public void DecreaseRotationDegrees(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            RotationValue = Math.Max(MinRotationDegrees, RotationValue - CCTVValidator.IsValuePositive(value));
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

            RotationValue = Math.Min(MaxZoom, ZoomValue + CCTVValidator.IsValuePositive(value));
            LastModified = DateTime.Now;
        }

        public void DecreaseZoom(int value)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("cannot set CCTV when it is off");

            RotationValue = Math.Max(MinZoom, ZoomValue - CCTVValidator.IsValuePositive(value));
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
