using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{

    public class MaterialsQualityViewModel : QualityViewModel<MaterialQualitySettings>
    {
        private int materialQualityIndex;

        public int MaterialQualityIndex
        {
            get { return materialQualityIndex; }
            set { 
                materialQualityIndex = value;
                this.OnPropertyChanged("MaterialQualityIndex");
            }
        }

        private bool materialAnisotropic;

        public bool MaterialAnisotropic
        {
            get { return materialAnisotropic; }
            set
            {
                materialAnisotropic = value;
                this.OnPropertyChanged("MaterialAnisotropic");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new MaterialQualitySettings()
            {
                r_MaterialQualityLevel = materialQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 3
                },
                r_AnisotropicMaterials = materialAnisotropic ? 1 : 0
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public MaterialsQualityViewModel() : base("Materials: ")
        {
        }
    }
}