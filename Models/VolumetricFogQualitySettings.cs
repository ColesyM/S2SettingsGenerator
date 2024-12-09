using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.Models
{
    public struct VolumetricFogQualitySettings: ISettingsModel
    {
        [IniPropertyAttribute("r.VolumetricFog")]
        public int r_VolumetricFog = 1;
        [IniPropertyAttribute("r.VolumetricFog.GridPixelSize")]
        public int r_VolumetricFog_GridPixelSize = 8;
        [IniPropertyAttribute("r.VolumetricFog.GridSizeZ")]
        public int r_VolumetricFog_GridSizeZ = 128;
        [IniPropertyAttribute("r.VolumetricFog.HistoryMissSupersampleCount")]
        public int r_VolumetricFog_HistoryMissSupersampleCount = 4;
        [IniPropertyAttribute("r.VolumetricFog.ShadowWorldBias")]
        public int r_VolumetricFog_ShadowWorldBias = 75;
        [IniPropertyAttribute("r.VolumetricFog.ShadowViewBias")]
        public float r_VolumetricFog_ShadowViewBias = 0.35f;

        public VolumetricFogQualitySettings()
        {
        }
    }
}
