using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.Models
{
    public struct VolumetricCloudsQualitySettings: ISettingsModel
    {
        public int r_VolumetricCloud_SkyAO = 1;
        public int r_VolumetricCloud_SkyAO_MaxResolution = 128;
        public int r_VolumetricCloud_ViewRaySampleMaxCount = 196;
        public int r_VolumetricCloud_DistanceToSampleMaxCount = 80;
        public int r_VolumetricCloud_ReflectionRaySampleMaxCount = 60;
        public int r_VolumetricCloud_Shadow_ViewRaySampleMaxCount = 4;


        public VolumetricCloudsQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.VolumetricCloud.SkyAO={r_VolumetricCloud_SkyAO}");
            sb.AppendLine($"r.VolumetricCloud.SkyAO.MaxResolution={r_VolumetricCloud_SkyAO_MaxResolution}");
            sb.AppendLine($"r.VolumetricCloud.ViewRaySampleMaxCount={r_VolumetricCloud_ViewRaySampleMaxCount}");
            sb.AppendLine($"r.VolumetricCloud.DistanceToSampleMaxCount={r_VolumetricCloud_DistanceToSampleMaxCount}");
            sb.AppendLine($"r.VolumetricCloud.ReflectionRaySampleMaxCount={r_VolumetricCloud_ReflectionRaySampleMaxCount}");
            sb.AppendLine($"r.VolumetricCloud.Shadow.ViewRaySampleMaxCount={r_VolumetricCloud_Shadow_ViewRaySampleMaxCount}");
        }
    }
}
