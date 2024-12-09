using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct ObjectDetailQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.Nanite.ViewMeshLODBias.Offset")]
        public float r_Nanite_ViewMeshLODBias_Offset = 0f; //; vk: defalut value
        [IniPropertyAttribute("r.Nanite.ViewMeshLODBias.Min")]
        public float r_Nanite_ViewMeshLODBias_Min = -2f; //; vk: defalut value
        [IniPropertyAttribute("r.Nanite.MaxPixelsPerEdge")]
        public int r_Nanite_MaxPixelsPerEdge = 1;
        [IniPropertyAttribute("r.SkeletalMeshLODBias")]
        public int r_SkeletalMeshLODBias = 0;
        [IniPropertyAttribute("r.DetailMode")]
        public int r_DetailMode = 2;
        [IniPropertyAttribute("mg.CharacterQuality")]
        public int mg_CharacterQuality = 3;
        [IniPropertyAttribute("mg.MaxActorWithSimulation")]
        public int mg_MaxActorWithSimulation = 15;
        [IniPropertyAttribute("mg.MaxAttaches")]
        public int mg_MaxAttaches = -1;

        public ObjectDetailQualitySettings()
        {
        }
    }
}
