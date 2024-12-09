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
        [IniPropertyAttribute("r.SkeletalMeshLODBias")]
        public int r_SkeletalMeshLODBias = 0;
        [IniPropertyAttribute("r.ViewDistanceScale")]
        public float r_ViewDistanceScale = 1.0f;
        [IniPropertyAttribute("gsc.ForceCompositionStreamingDistance")]
        public int gsc_ForceCompositionStreamingDistance = -1;
        [IniPropertyAttribute("wp.Runtime.HLOD")]
        public int wp_Runtime_HLOD = 1;
        [IniPropertyAttribute("r.LightMaxDrawDistanceScale")]
        public float r_LightMaxDrawDistanceScale = 1;

        public ViewDistanceQualitySettings()
        {
        }
    }
}
