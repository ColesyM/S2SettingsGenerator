using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.Models
{
    public struct VolumetricFogQualitySettings: ISettingsModel
    {
        public int r_VolumetricFog = 1;
        public int r_VolumetricFog_GridPixelSize = 8;
        public int r_VolumetricFog_GridSizeZ = 128;
        public int r_VolumetricFog_HistoryMissSupersampleCount = 4;
        public int r_VolumetricFog_ShadowWorldBias = 75;
        public float r_VolumetricFog_ShadowViewBias = 0.35f;

        public VolumetricFogQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.VolumetricFog={r_VolumetricFog}");
            sb.AppendLine($"r.VolumetricFog.GridPixelSize={r_VolumetricFog_GridPixelSize}");
            sb.AppendLine($"r.VolumetricFog.GridSizeZ={r_VolumetricFog_GridSizeZ}");
            sb.AppendLine($"r.VolumetricFog.HistoryMissSupersampleCount={r_VolumetricFog_HistoryMissSupersampleCount}");
            sb.AppendLine($"r.VolumetricFog.ShadowWorldBias={r_VolumetricFog_ShadowWorldBias}");
            sb.AppendLine($"r.VolumetricFog.ShadowViewBias={r_VolumetricFog_ShadowViewBias}");
        }
    }
}
