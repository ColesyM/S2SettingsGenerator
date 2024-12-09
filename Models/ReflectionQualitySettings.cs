using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct ReflectionQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.ReflectionMethod.Override")]
        public int r_ReflectionMethod_Override = 1;
        [IniPropertyAttribute("r.SSR.Quality")]
        public int r_SSR_Quality=3;
        [IniPropertyAttribute("r.SSR.HalfResSceneColor")]
        public int r_SSR_HalfResSceneColor = 0;
        [IniPropertyAttribute("r.Lumen.Reflections.Allow")]
        public int r_Lumen_Reflections_Allow=1;
        [IniPropertyAttribute("r.Lumen.Reflections.TraceMeshSDFs")]
        public int r_Lumen_Reflections_TraceMeshSDFs=0;
        [IniPropertyAttribute("r.Lumen.Reflections.DownsampleFactor")]
        public int r_Lumen_Reflections_DownsampleFactor=2;
        [IniPropertyAttribute("r.Lumen.Reflections.MaxRoughnessToTrace")]
        public float r_Lumen_Reflections_MaxRoughnessToTrace = 0.3f;
        [IniPropertyAttribute("r.Lumen.Reflections.BilateralFilter.SpatialKernelRadius")]
        public float r_Lumen_Reflections_BilateralFilter_SpatialKernelRadius=0.001f;
        [IniPropertyAttribute("r.Lumen.Reflections.BilateralFilter.NumSamples")]
        public int r_Lumen_Reflections_BilateralFilter_NumSamples = 4;
        [IniPropertyAttribute("r.Lumen.Reflections.SkipEmissive.Opaque")]
        public int r_Lumen_Reflections_SkipEmissive_Opaque=1;
        [IniPropertyAttribute("r.Lumen.Reflections.SkipEmissive.SLW")]
        public int r_Lumen_Reflections_SkipEmissive_SLW = 1;
        [IniPropertyAttribute("r.Lumen.Reflections.SkipEmissive.FrontLayer")]
        public int r_Lumen_Reflections_SkipEmissive_FrontLayer = 1;
        [IniPropertyAttribute("r.Lumen.TranslucencyReflections.FrontLayer.Allow")]
        public int r_Lumen_TranslucencyReflections_FrontLayer_Allow=1;
        [IniPropertyAttribute("r.Lumen.TranslucencyReflections.FrontLayer.Enable")]
        public int r_Lumen_TranslucencyReflections_FrontLayer_Enable = 1;
        [IniPropertyAttribute("r.Lumen.Reflections.SampleSceneColorAtHit")]
        public int r_Lumen_Reflections_SampleSceneColorAtHit = 1;

        public ReflectionQualitySettings()
        {
        }
    }
}
