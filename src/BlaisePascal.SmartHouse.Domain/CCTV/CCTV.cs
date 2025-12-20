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
        
        public CCTV(string name, bool isRecording, float zoomValue, float rotation): base(name)
        {
            IsRecording = isRecording;
            ZoomValue = zoomValue;
            RotationValue = rotation;
        }

        public CCTV(string name): this(name, false, 0, 0)
        {
            ZoomValue = 0;
            RotationValue = 0;
            IsRecording = false;
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
            float newRotationValue = CCTVValidator.RotationValidator(value) + RotationValue;
            RotationValue = Math.Min(newRotationValue, CCTVValidator.maxRotationDegrees);
        } 

        public void DecreaseRotationDegrees(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            float newRotationValue = RotationValue - CCTVValidator.RotationValidator(value);
            RotationValue = Math.Max(CCTVValidator.minRotationDegrees, newRotationValue);
            LastModified = DateTime.Now;
        }

        public void SetZoom(float zoom)
        {
            CCTVValidator.CheckIsOn(Status);
            ZoomValue = CCTVValidator.ZoomValidator(zoom);
            LastModified = DateTime.UtcNow;
        }

        public void IncreaseZoom(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            float newZoomValue = CCTVValidator.RotationValidator(value) + ZoomValue;
            RotationValue = Math.Min(CCTVValidator.maxZoom, newZoomValue);
            LastModified = DateTime.Now;
        }

        public void DecreaseZoom(int value)
        {
            CCTVValidator.CheckIsOn(Status);
            float newZoomValue = ZoomValue - CCTVValidator.IsValuePositive(value);
            RotationValue = Math.Max(CCTVValidator.minZoom, ZoomValue);
            LastModified = DateTime.Now;
        }
        public void StartRecording()
        {
            CCTVValidator.CheckIsOn(Status);
            IsRecording = true;
            LastModified = DateTime.UtcNow;
        }
        public void StopRecording()
        {
            CCTVValidator.CheckIsOn(Status);
            IsRecording = false;
            LastModified = DateTime.UtcNow;
        }

        public float GetMaxZoom()
        {
            return CCTVValidator.maxZoom;
        }

        public float GetMinZoom()
        {
            return CCTVValidator.minZoom;
        }

        public float GetMaxRotationDegrees()
        {
            return CCTVValidator.maxRotationDegrees;
        }

        public float GetMinRotationDegrees()
        {
            return CCTVValidator.minRotationDegrees;
        }
    }
}
