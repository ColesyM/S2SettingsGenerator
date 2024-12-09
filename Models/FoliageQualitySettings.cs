using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct FoliageQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("foliage.MinimumScreenSize")]
        public float foliage_MinimumScreenSize=0.000005f;
        [IniPropertyAttribute("foliage.LODDistanceScale")]
        public float foliage_LODDistanceScale = 1.0f;
        [IniPropertyAttribute("foliage.MaxTrianglesToRender")]
        public int foliage_MaxTrianglesToRender = 100000000;
        [IniPropertyAttribute("fg.CullDistanceScale.Grass")]
        public float fg_CullDistanceScale_Grass = 1;
        [IniPropertyAttribute("fg.CullDistanceScale.Trees")]
        public float fg_CullDistanceScale_Trees = 1;
        [IniPropertyAttribute("fg.DensityScale.Grass")]
        public float fg_DensityScale_Grass = 1;

        public FoliageQualitySettings()
        {
        }
    }
}
