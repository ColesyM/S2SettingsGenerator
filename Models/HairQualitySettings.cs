using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct HairQualitySettings : ISettingsModel
    {
        public int r_HairStrands_SkyAO=1;
        public int r_HairStrands_SkyAO_SampleCount = 4;
        public int r_HairStrands_Visibility_MSAA_SamplePerPixel = 4;
        public int r_HairStrands_Interpolation_UseSingleGuide = 0;
        public int r_HairStrands_Voxelization = 1;
        public int mg_HairQuality=3;

        public HairQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.HairStrands.SkyAO={r_HairStrands_SkyAO}");
            sb.AppendLine($"r.HairStrands.SkyAO.SampleCount={r_HairStrands_SkyAO_SampleCount}");

            sb.AppendLine($"r.HairStrands.Visibility.MSAA.SamplePerPixel={r_HairStrands_Visibility_MSAA_SamplePerPixel}");
            sb.AppendLine($"r.HairStrands.Interpolation.UseSingleGuide={r_HairStrands_Interpolation_UseSingleGuide}");

            sb.AppendLine($"r.HairStrands.Voxelization={r_HairStrands_Voxelization}");
            sb.AppendLine($"mg.HairQuality={mg_HairQuality}");
        }
    }
}
