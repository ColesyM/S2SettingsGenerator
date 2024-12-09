using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct MaterialQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.MaterialQualityLevel")]
        public int r_MaterialQualityLevel=3; //; Epic quality.For more information about the values look "r.MaterialQualityLevel" definition
        [IniPropertyAttribute("r.AnisotropicMaterials")]
        public int r_AnisotropicMaterials= 1;

        public MaterialQualitySettings()
        {
        }
    }
}
