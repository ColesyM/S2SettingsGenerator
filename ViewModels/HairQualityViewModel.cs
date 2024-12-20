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

        private int voxelPageCountPerDim;

        public int VoxelPageCountPerDim
        {
            get { return voxelPageCountPerDim; }
            set
            {
                voxelPageCountPerDim = value;
                this.OnPropertyChanged("VoxelPageCountPerDim");
            }
        }

        private int voxelPageResolution;

        public int VoxelPageResolution
        {
            get { return voxelPageResolution; }
            set
            {
                voxelPageResolution = value;
                this.OnPropertyChanged("VoxelPageResolution");
            }
        }

        public void ApplyPreset(Presets preset)
        {
            switch (preset)
            {
                case Presets.POTATO:
                case Presets.VERY_LOW:
                case Presets.LOW:
                case Presets.MEDIUM:
                case Presets.HIGH:
                    VoxelPageCountPerDim = 7;
                    voxelPageResolution = 16;
                    break;
                case Presets.ULTRA:
                case Presets.INSANE:
                case Presets.EPIC:
                    VoxelPageCountPerDim = 14;
                    voxelPageResolution = 32;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
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
                mg_HairQuality = hairQuality,
                r_HairStrands_Voxelization_Virtual_VoxelPageCountPerDim = 7,
                r_HairStrands_Voxelization_Virtual_VoxelPageResolution = 16
    };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public HairQualityViewModel() : base("Hair: ")
        {
        }
    }
}