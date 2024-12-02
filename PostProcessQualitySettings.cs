using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    internal struct PostProcessQualitySettings
    {
        public int r_RenderTargetPoolMin = 400;
        public int r_LensFlareQuality = 2;
        public int r_SceneColorFringeQuality = 1;
        public int r_EyeAdaptationQuality = 2;
        public int r_BloomQuality = 5;
        public int r_FastBlurThreshold = 100;
        public int r_Upscale_Quality = 3;
        public int r_Tonemapper_GrainQuantization = 1;
        public int r_LightShaftQuality = 1;
        public int r_LightShaftDownSampleFactor = 2;
        public float r_Filter_SizeScale = 1f;
        public int r_Tonemapper_Quality = 5;

        public PostProcessQualitySettings()
        {

        }
        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.RenderTargetPoolMin={r_RenderTargetPoolMin}");
            sb.AppendLine($"r.LensFlareQuality={r_LensFlareQuality}");
            sb.AppendLine($"r.SceneColorFringeQuality={r_SceneColorFringeQuality}");
            sb.AppendLine($"r.EyeAdaptationQuality={r_EyeAdaptationQuality}");
            sb.AppendLine($"r.BloomQuality={r_BloomQuality}");
            sb.AppendLine($"r.FastBlurThreshold={r_FastBlurThreshold}");
            sb.AppendLine($"r.Upscale.Quality={r_Upscale_Quality}");
            sb.AppendLine($"r.Tonemapper.GrainQuantization={r_Tonemapper_GrainQuantization}");
            sb.AppendLine($"r.LightShaftQuality={r_LightShaftQuality}");
            sb.AppendLine($"r.LightShaftDownSampleFactor={r_LightShaftDownSampleFactor}");
            sb.AppendLine($"r.Filter.SizeScale={r_Filter_SizeScale}");
            sb.AppendLine($"r.Tonemapper.Quality={r_Tonemapper_Quality}");
        }

    }
}
