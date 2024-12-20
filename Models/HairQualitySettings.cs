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
        [IniPropertyAttribute("r.HairStrands.SkyAO")]
        public int r_HairStrands_SkyAO=1;
        [IniPropertyAttribute("r.HairStrands.SkyAO.SampleCount")]
        public int r_HairStrands_SkyAO_SampleCount = 4;
        [IniPropertyAttribute("r.HairStrands.Visibility.MSAA.SamplePerPixel")]
        public int r_HairStrands_Visibility_MSAA_SamplePerPixel = 4;
        [IniPropertyAttribute("r.HairStrands.Interpolation.UseSingleGuide")]
        public int r_HairStrands_Interpolation_UseSingleGuide = 0;
        [IniPropertyAttribute("r.HairStrands.Voxelization")]
        public int r_HairStrands_Voxelization = 1;
        [IniPropertyAttribute("mg.HairQuality")]
        public int mg_HairQuality=3;
        [IniPropertyAttribute("r.HairStrands.Voxelization.Virtual.VoxelPageCountPerDim")]
        public int r_HairStrands_Voxelization_Virtual_VoxelPageCountPerDim = 7;
        [IniPropertyAttribute("r.HairStrands.Voxelization.Virtual.VoxelPageResolution")]
        public int r_HairStrands_Voxelization_Virtual_VoxelPageResolution = 16;

        public HairQualitySettings()
        {
        }
    }
}
