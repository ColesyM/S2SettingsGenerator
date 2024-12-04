using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    internal struct ReflectionQualitySettings
    {
        public int r_ReflectionMethod_Override = 1;

        public int r_SSR_Quality=3;
        public int r_SSR_HalfResSceneColor = 0;

        public int r_Lumen_Reflections_Allow=1;
        public int r_Lumen_Reflections_TraceMeshSDFs=0;
        public int r_Lumen_Reflections_DownsampleFactor=2;
        public float r_Lumen_Reflections_MaxRoughnessToTrace = 0.3f;
        public float r_Lumen_Reflections_BilateralFilter_SpatialKernelRadius=0.001f;
        public int r_Lumen_Reflections_BilateralFilter_NumSamples = 4;

        public int r_Lumen_Reflections_SkipEmissive_Opaque=1;
        public int r_Lumen_Reflections_SkipEmissive_SLW = 1;
        public int r_Lumen_Reflections_SkipEmissive_FrontLayer = 1;

        public int r_Lumen_TranslucencyReflections_FrontLayer_Allow=1;
        public int r_Lumen_TranslucencyReflections_FrontLayer_Enable = 1;
        public int r_Lumen_Reflections_SampleSceneColorAtHit = 1;

        public ReflectionQualitySettings()
        {

        }
        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.ReflectionMethod.Override={r_ReflectionMethod_Override}");
            sb.AppendLine($"r.SSR.Quality={r_SSR_Quality}");
            sb.AppendLine($"r.SSR.HalfResSceneColor={r_SSR_HalfResSceneColor}");
            sb.AppendLine($"r.Lumen.Reflections.Allow={r_Lumen_Reflections_Allow}");
            sb.AppendLine($"r.Lumen.Reflections.TraceMeshSDFs={r_Lumen_Reflections_TraceMeshSDFs}");
            sb.AppendLine($"r.Lumen.Reflections.DownsampleFactor={r_Lumen_Reflections_DownsampleFactor}");
            sb.AppendLine($"r.Lumen.Reflections.MaxRoughnessToTrace={r_Lumen_Reflections_MaxRoughnessToTrace}");
            sb.AppendLine($"r.Lumen.Reflections.BilateralFilter.SpatialKernelRadius={r_Lumen_Reflections_BilateralFilter_SpatialKernelRadius}");
            sb.AppendLine($"r.Lumen.Reflections.BilateralFilter.NumSamples={r_Lumen_Reflections_BilateralFilter_NumSamples}");
            sb.AppendLine($"r.Lumen.Reflections.SkipEmissive.Opaque={r_Lumen_Reflections_SkipEmissive_Opaque}");
            sb.AppendLine($"r.Lumen.Reflections.SkipEmissive.SLW={r_Lumen_Reflections_SkipEmissive_SLW}");
            sb.AppendLine($"r.Lumen.Reflections.SkipEmissive.FrontLayer={r_Lumen_Reflections_SkipEmissive_FrontLayer}");
            sb.AppendLine($"r.Lumen.TranslucencyReflections.FrontLayer.Allow={r_Lumen_TranslucencyReflections_FrontLayer_Allow}");
            sb.AppendLine($"r.Lumen.TranslucencyReflections.FrontLayer.Enable={r_Lumen_TranslucencyReflections_FrontLayer_Enable}");
            sb.AppendLine($"r.Lumen.Reflections.SampleSceneColorAtHit={r_Lumen_Reflections_SampleSceneColorAtHit}");
        }

    }
}
