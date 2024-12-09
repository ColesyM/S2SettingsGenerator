using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct PostProcessQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.RenderTargetPoolMin")]
        public int r_RenderTargetPoolMin = 400;
        [IniPropertyAttribute("r.LensFlareQuality")]
        public int r_LensFlareQuality = 2;
        [IniPropertyAttribute("r.SceneColorFringeQuality")]
        public int r_SceneColorFringeQuality = 1;
        [IniPropertyAttribute("r.EyeAdaptationQuality")]
        public int r_EyeAdaptationQuality = 2;
        [IniPropertyAttribute("r.EyeAdaptation.LensAttenuation")]
        public float r_EyeAdaptation_LensAttenuation = 0.78f;
        [IniPropertyAttribute("r.BloomQuality")]
        public int r_BloomQuality = 5;
        [IniPropertyAttribute("r.FastBlurThreshold")]
        public int r_FastBlurThreshold = 100;
        [IniPropertyAttribute("r.Upscale.Quality")]
        public int r_Upscale_Quality = 3;
        [IniPropertyAttribute("r.Tonemapper.GrainQuantization")]
        public int r_Tonemapper_GrainQuantization = 1;
        [IniPropertyAttribute("r.LightShaftQuality")]
        public int r_LightShaftQuality = 1;
        [IniPropertyAttribute("r.LightShaftDownSampleFactor")]
        public int r_LightShaftDownSampleFactor = 2;
        [IniPropertyAttribute("r.Filter.SizeScale")]
        public float r_Filter_SizeScale = 1f;
        [IniPropertyAttribute("r.Tonemapper.Quality")]
        public int r_Tonemapper_Quality = 5;

        public PostProcessQualitySettings()
        {
        }
    }
}
