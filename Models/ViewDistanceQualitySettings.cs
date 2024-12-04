using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct ViewDistanceQualitySettings : ISettingsModel
    {
        public int r_SkeletalMeshLODBias = 0;
        public float r_ViewDistanceScale = 1.0f;
        public int gsc_ForceCompositionStreamingDistance = -1;
        public int wp_Runtime_HLOD = 1;
        public float r_LightMaxDrawDistanceScale = 1;

        public ViewDistanceQualitySettings()
        {

        }
        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.SkeletalMeshLODBias={r_SkeletalMeshLODBias}");
            sb.AppendLine($"r.ViewDistanceScale={r_ViewDistanceScale}");
            sb.AppendLine($"gsc.ForceCompositionStreamingDistance={gsc_ForceCompositionStreamingDistance}");
            sb.AppendLine($"wp.Runtime.HLOD={wp_Runtime_HLOD}");
            sb.AppendLine($"r.LightMaxDrawDistanceScale={r_LightMaxDrawDistanceScale}");
        }
    }
}
