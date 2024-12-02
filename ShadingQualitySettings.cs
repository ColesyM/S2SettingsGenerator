using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    internal struct ShadingQualitySettings
    {
        public int r_SceneColorFormat = 4; //; PF_FloatRGBA 64Bit
        public int r_TranslucentLightingVolume = 1;
        public int r_TranslucencyLightingVolumeDim = 64;
        public int r_TranslucencyVolumeBlur = 1;
        public int r_SubsurfaceScatteringPass = 1;
        public float r_SSS_Scale= 1f;
        public int r_SSS_SampleSet= 2;
        public int r_SSS_Quality= 1;
        public int r_SSS_HalfRes = 0;
        public float r_AmbientOcclusionMipLevelFactor = 10f;
        public int r_AmbientOcclusionMaxQuality = 100;
        public int r_AmbientOcclusionLevels = -1;
        public float r_AmbientOcclusionRadiusScale = 1.0f;
        public int r_TranslucencyLightingVolume_UseShadowFiltering = 1;

        public ShadingQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.SceneColorFormat={r_SceneColorFormat}");
            sb.AppendLine($"r.SceneColorFormat={r_SceneColorFormat}");
            sb.AppendLine($"r.TranslucentLightingVolume={r_TranslucentLightingVolume}");
            sb.AppendLine($"r.ranslucencyLightingVolumeDim={r_TranslucencyLightingVolumeDim}");
            sb.AppendLine($"r.TranslucencyVolumeBlur={r_TranslucencyVolumeBlur}");
            sb.AppendLine($"r.SubsurfaceScatteringPass={r_SubsurfaceScatteringPass}");
            sb.AppendLine($"r.SSS.Scale={r_SSS_Scale}");
            sb.AppendLine($"r.SSS.SampleSet={r_SSS_SampleSet}");
            sb.AppendLine($"r.SSS.Quality={r_SSS_Quality}");
            sb.AppendLine($"r.SSS.HalfRes={r_SSS_HalfRes}");
            sb.AppendLine($"r.AmbientOcclusionMipLevelFactor={r_AmbientOcclusionMipLevelFactor}");
            sb.AppendLine($"r.AmbientOcclusionMaxQuality={r_AmbientOcclusionMaxQuality}");
            sb.AppendLine($"rmbientOcclusionLevels.={r_AmbientOcclusionLevels}");
            sb.AppendLine($"r.AmbientOcclusionRadiusScal={r_AmbientOcclusionRadiusScale}");
            sb.AppendLine($"r.TranslucencyLightingVolume.UseShadowFiltering={r_TranslucencyLightingVolume_UseShadowFiltering}");
        }
    }
}
