﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct FoliageQualitySettings : ISettingsModel
    {
        public float foliage_MinimumScreenSize=0.000005f;
        public float foliage_LODDistanceScale = 1.0f;
        public int foliage_MaxTrianglesToRender = 100000000;
        public float fg_CullDistanceScale_Grass = 1;
        public float fg_CullDistanceScale_Trees = 1;
        public float fg_DensityScale_Grass = 1;

        public FoliageQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"foliage.MinimumScreenSize={foliage_MinimumScreenSize.ToString("n7")}");
            sb.AppendLine($"foliage.LODDistanceScale={foliage_LODDistanceScale}");
            sb.AppendLine($"foliage.MaxTrianglesToRender={foliage_MaxTrianglesToRender}");

            sb.AppendLine($"fg.CullDistanceScale.Grass={fg_CullDistanceScale_Grass}");
            sb.AppendLine($"fg.CullDistanceScale.Trees={fg_CullDistanceScale_Trees}");

            sb.AppendLine($"fg.DensityScale.Grass={fg_DensityScale_Grass}");
        }
    }
}
