﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct ObjectDetailQualitySettings : ISettingsModel
    {
        public float r_Nanite_ViewMeshLODBias_Offset = 0f; //; vk: defalut value
        public float r_Nanite_ViewMeshLODBias_Min = -2f; //; vk: defalut value
        public int r_Nanite_MaxPixelsPerEdge = 1;
        public int r_SkeletalMeshLODBias = 0;
        public int r_DetailMode = 2;
        public int mg_CharacterQuality = 3;
        public int mg_MaxActorWithSimulation = 15;
        public int mg_MaxAttaches = -1;

        public ObjectDetailQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.Nanite.ViewMeshLODBias.Offset={r_Nanite_ViewMeshLODBias_Offset}");
            sb.AppendLine($"r.Nanite.ViewMeshLODBias.Min={r_Nanite_ViewMeshLODBias_Min}");
            sb.AppendLine($"r.Nanite.MaxPixelsPerEdge={r_Nanite_MaxPixelsPerEdge}");
            sb.AppendLine($"r.SkeletalMeshLODBias={r_SkeletalMeshLODBias}");
            sb.AppendLine($"r.DetailMode={r_DetailMode}");
            sb.AppendLine($"mg.CharacterQuality={mg_CharacterQuality}");
            sb.AppendLine($"mg.MaxActorWithSimulation={mg_MaxActorWithSimulation}");
            sb.AppendLine($"mg.MaxAttaches={mg_MaxAttaches}");
        }
    }
}
