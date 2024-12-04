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
        public int r_RefractionQuality = 2;
        public float r_EmitterSpawnRateScale = 1.0f;
        public int r_ParticleLightQuality = 2;
        public int fx_Niagara_QualityLevel = 3;
        public int fx_Niagara_MaxAdvanceTicks = 20;
        public int r_Refraction_Blur_TemporalAA = 1;

        public EffectsQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.RefractionQuality={r_RefractionQuality}");
            sb.AppendLine($"r.EmitterSpawnRateScale={r_EmitterSpawnRateScale}");

            sb.AppendLine($"r.ParticleLightQuality={r_ParticleLightQuality}");
            sb.AppendLine($"r.Niagara.QualityLevel={fx_Niagara_QualityLevel}");

            sb.AppendLine($"r.Niagara.MaxAdvanceTicks={fx_Niagara_MaxAdvanceTicks}");
            sb.AppendLine($"r.Refraction.Blur.TemporalAA={r_Refraction_Blur_TemporalAA}");
        }
    }
}
