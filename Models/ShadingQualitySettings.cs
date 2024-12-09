using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct ShadingQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.SceneColorFormat")]
        public int r_SceneColorFormat = 4; //; PF_FloatRGBA 64Bit
        [IniPropertyAttribute("r.TranslucentLightingVolume")]
        public int r_TranslucentLightingVolume = 1;
        [IniPropertyAttribute("r.TranslucencyLightingVolumeDim")]
        public int r_TranslucencyLightingVolumeDim = 64;
        [IniPropertyAttribute("r.TranslucencyVolumeBlur")]
        public int r_TranslucencyVolumeBlur = 1;
        [IniPropertyAttribute("r.SubsurfaceScatteringPass")]
        public int r_SubsurfaceScatteringPass = 1;
        [IniPropertyAttribute("r.SubsurfaceScattering")]
        public int r_SubsurfaceScattering = 1;
        [IniPropertyAttribute("r.SSS.Scale")]
        public float r_SSS_Scale= 1f;
        [IniPropertyAttribute("r.SSS.SampleSet")]
        public int r_SSS_SampleSet= 2;
        [IniPropertyAttribute("r.SSS.Quality")]
        public int r_SSS_Quality= 1;
        [IniPropertyAttribute("r.SSS.HalfRes")]
        public int r_SSS_HalfRes = 0;
        [IniPropertyAttribute("r.AmbientOcclusionMipLevelFactor")]
        public float r_AmbientOcclusionMipLevelFactor = 10f;
        [IniPropertyAttribute("r.AmbientOcclusionMaxQuality")]
        public int r_AmbientOcclusionMaxQuality = 100;
        [IniPropertyAttribute("r.AmbientOcclusionLevels")]
        public int r_AmbientOcclusionLevels = -1;
        [IniPropertyAttribute("r.AmbientOcclusionRadiusScale")]
        public float r_AmbientOcclusionRadiusScale = 1.0f;
        [IniPropertyAttribute("r.TranslucencyLightingVolume.UseShadowFiltering")]
        public int r_TranslucencyLightingVolume_UseShadowFiltering = 1;

        public ShadingQualitySettings()
        {
        }
    }
}
