using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    internal struct MaterialQualitySettings
    {
        public int r_MaterialQualityLevel=3; //; Epic quality.For more information about the values look "r.MaterialQualityLevel" definition
        public int r_AnisotropicMaterials= 1;

        public MaterialQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.MaterialQualityLevel={r_MaterialQualityLevel}");
            sb.AppendLine($"r.AnisotropicMaterials={r_AnisotropicMaterials}");
        }
    }
}
