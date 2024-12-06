using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class HairQualityViewModel : QualityViewModel<HairQualitySettings>
    {
        private bool hairAO;

        public bool HairAO
        {
            get { return hairAO; }
            set
            {
                hairAO = value;
                this.OnPropertyChanged("HairAO");
            }
        }

        private int hairAOSamples;

        public int HairAOSamples
        {
            get { return hairAOSamples; }
            set { 
                hairAOSamples = value;
                this.OnPropertyChanged("HairAOSamples");
            }
        }

        private int hairStrandVisibility;

        public int HairStrandVisibility
        {
            get { return hairStrandVisibility; }
            set { 
                hairStrandVisibility = value;
                this.OnPropertyChanged("HairStrandVisibility");
            }
        }

        private bool hairLightingAndShadows;

        public bool HairLightingAndShadows
        {
            get { return hairLightingAndShadows; }
            set
            {
                hairLightingAndShadows = value;
                this.OnPropertyChanged("HairLightingAndShadows");
            }
        }

        private int hairQuality;

        public int HairQuality
        {
            get { return hairQuality; }
            set
            {
                hairQuality = value;
                this.OnPropertyChanged("HairQuality");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new HairQualitySettings()
            {
                r_HairStrands_SkyAO = hairAO ? 1 : 0,
                r_HairStrands_SkyAO_SampleCount = hairAOSamples,
                r_HairStrands_Visibility_MSAA_SamplePerPixel = hairStrandVisibility,
                r_HairStrands_Interpolation_UseSingleGuide = 0,
                r_HairStrands_Voxelization = hairLightingAndShadows ? 0 : 1,
                mg_HairQuality = hairQuality
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public HairQualityViewModel() : base("Hair: ")
        {
        }
    }
}