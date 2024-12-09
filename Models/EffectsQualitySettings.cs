using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct EffectsQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.RefractionQuality")]
        public int r_RefractionQuality = 2;
        [IniPropertyAttribute("r.EmitterSpawnRateScale")]
        public float r_EmitterSpawnRateScale = 1.0f;
        [IniPropertyAttribute("r.ParticleLightQuality")]
        public int r_ParticleLightQuality = 2;
        [IniPropertyAttribute("fx.Niagara.QualityLevel")]
        public int fx_Niagara_QualityLevel = 3;
        [IniPropertyAttribute("fx.Niagara.MaxAdvanceTicks")]
        public int fx_Niagara_MaxAdvanceTicks = 20;
        [IniPropertyAttribute("r.Refraction.Blur.TemporalAA")]
        public int r_Refraction_Blur_TemporalAA = 1;

        public EffectsQualitySettings()
        {
        }
    }
}
