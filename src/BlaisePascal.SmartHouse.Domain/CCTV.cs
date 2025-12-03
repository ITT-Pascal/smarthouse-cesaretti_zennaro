using BlaisePascal.SmartHouse.Domain.Asbtraction;
using BlaisePascal.SmartHouse.Domain.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class CCTV : AbstractDevice
    {
        public bool IsRecording { get; set; }
        public float ZoomValue {  get; set; }
        public float Rotation {  get; set; }
        public CCTV(string name) : base(name)
        {
            ZoomValue = 1;
            Rotation = 0;
            IsRecording = false;
        }
        public void Rotate(float degrees)
        {
            Rotation = CCTVValidator.RotationValidator(Rotation + degrees);
        }
        public void Zoom(float zoom)
        {
            ZoomValue = CCTVValidator.ZoomValidator(ZoomValue + zoom);
        }
    }
}
