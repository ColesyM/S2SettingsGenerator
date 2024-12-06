using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator.ViewModels
{
    public class FogQualityViewModel : QualityViewModel<VolumetricFogQualitySettings>
    {
        private bool volumetricFog;

        public bool VolumetricFog
        {
            get { return volumetricFog; }
            set { 
                volumetricFog = value;
                this.OnPropertyChanged("VolumetricFog");
            }
        }

        private int fogResIndex;

        public int FogResIndex
        {
            get { return fogResIndex; }
            set { 
                fogResIndex = value;
                this.OnPropertyChanged("FogResIndex");
            }
        }

        private int fogSuperSampleCount;

        public int FogSuperSampleCount
        {
            get { return fogSuperSampleCount; }
            set { 
                fogSuperSampleCount = value;
                this.OnPropertyChanged("FogSuperSampleCount");
            }
        }


        public override void PopulateSettingsModel()
        {
            Settings = new VolumetricFogQualitySettings()
            {
                r_VolumetricFog = volumetricFog ? 1 : 0,
                r_VolumetricFog_GridPixelSize = fogResIndex switch
                {
                    0 => 64,
                    1 => 32,
                    2 => 16,
                    3 => 8,
                    4 => 4,
                    _ => 8,
                },
                r_VolumetricFog_GridSizeZ = fogResIndex switch
                {
                    0 => 32,
                    1 => 64,
                    2 => 64,
                    3 => 128,
                    4 => 256,
                    _ => 128,
                },
                r_VolumetricFog_HistoryMissSupersampleCount = fogSuperSampleCount,
                r_VolumetricFog_ShadowWorldBias = fogResIndex switch
                {
                    0 => 110,
                    1 => 110,
                    2 => 110,
                    3 => 75,
                    4 => 50,
                    _ => 75,
                },
                r_VolumetricFog_ShadowViewBias = fogResIndex switch
                {
                    0 => 0.75f,
                    1 => 0.75f,
                    2 => 0.75f,
                    3 => 0.35f,
                    4 => 0.25f,
                    _ => 0.35f,
                },
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public FogQualityViewModel() : base("Fog: ")
        {
        }
    }
}