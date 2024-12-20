using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class TextureQualityViewModel : QualityViewModel<TextureQualitySettings>
    {
        private float texureMIP;

        public float TextureMIP
        {
            get { return texureMIP; }
            set { 
                texureMIP = value; 
                this.OnPropertyChanged("TextureMIP"); 
            }
        }

        private int anisotropicIndex;

        public int AnisotropicIndex
        {
            get { return anisotropicIndex; }
            set
            {
                anisotropicIndex = value;
                this.OnPropertyChanged("AnisotropicIndex");
            }
        }

        private bool amortizeCPUToGPUCopy;

        public bool AmortizeCPUToGPUCopy
        {
            get { return amortizeCPUToGPUCopy; }
            set { 
                amortizeCPUToGPUCopy = value;
                this.OnPropertyChanged("AmortizeCPUToGPUCopy");
            }
        }

        private int streamLimitPerFrameIndex;

        public int StreamLimitPerFrameIndex
        {
            get { return streamLimitPerFrameIndex; }
            set
            {
                streamLimitPerFrameIndex = value;
                this.OnPropertyChanged("StreamLimitPerFrameIndex");
            }
        }

        private int mipPreferenceIndex;

        public int MipPreferenceIndex
        {
            get { return mipPreferenceIndex; }
            set
            {
                mipPreferenceIndex = value;
                this.OnPropertyChanged("MipPreferenceIndex");
            }
        }

        private int streamingPoolIndex;

        public int StreamingPoolIndex
        {
            get { return streamingPoolIndex; }
            set
            {
                streamingPoolIndex = value;
                this.OnPropertyChanged("StreamingPoolIndex");
            }
        }

        private int textureCopySpeedIndex;

        public int TextureCopySpeedIndex
        {
            get { return textureCopySpeedIndex; }
            set
            {
                textureCopySpeedIndex = value;
                this.OnPropertyChanged("TextureCopySpeedIndex");
            }
        }

        private int textureGenerationSpeedIndex;

        public int TextureGenerationSpeedIndex
        {
            get { return textureGenerationSpeedIndex; }
            set
            {
                textureGenerationSpeedIndex = value;
                this.OnPropertyChanged("TextureGenerationSpeedIndex");
            }
        }

        private float vtPoolSizeScaleGroup0;

        public float VTPoolSizeScaleGroup0
        {
            get { return vtPoolSizeScaleGroup0; }
            set
            {
                vtPoolSizeScaleGroup0 = value;
                this.OnPropertyChanged("VTPoolSizeScaleGroup0");
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
                    VTPoolSizeScaleGroup0 = 1f;
                    break;
                case Presets.HIGH:
                    VTPoolSizeScaleGroup0 = 1.5f;
                    break;
                case Presets.ULTRA:
                case Presets.INSANE:
                case Presets.EPIC:
                    VTPoolSizeScaleGroup0 = 2;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new TextureQualitySettings()
            {
                r_Streaming_MipBias = 0,
                r_MipMapLODBias = texureMIP,

                r_MaxAnisotropy = anisotropicIndex switch
                {
                    0 => 1,
                    1 => 2,
                    2 => 4,
                    3 => 8,
                    4 => 16,
                    _ => 8
                },
                r_VT_MaxAnisotropy = anisotropicIndex switch
                {
                    0 => 1,
                    1 => 2,
                    2 => 4,
                    3 => 8,
                    4 => 16,
                    _ => 8
                },

                r_Streaming_UseFixedPoolSize = 1,
                r_Streaming_AmortizeCPUToGPUCopy = amortizeCPUToGPUCopy ? 1 : 0,
                r_Streaming_MaxNumTexturesToStreamPerFrame = streamLimitPerFrameIndex switch
                {
                    0 => 0,
                    1 => 10,
                    2 => 5,
                    3 => 3,
                    4 => 1,
                    _ => 0,
                },
                r_Streaming_Boost = mipPreferenceIndex switch
                {
                    0 => -2,
                    1 => 1,
                    2 => 2,
                    _ => 1,
                },
                r_Streaming_DropMips = 0,
                r_Streaming_MaxEffectiveScreenSize = 0,
                r_Streaming_LimitPoolSizeToVRAM = 1,

                r_Streaming_PoolSize = streamingPoolIndex switch
                {
                    0 => 256,
                    1 => 512,
                    2 => 1024,
                    3 => 2048,
                    4 => 3072,
                    _ => 3072
                },
                r_VT_PoolSizeScale_Group0 = vtPoolSizeScaleGroup0,
                r_VT_PoolSizeScale_Group1 = 0.2f,
                r_VT_PoolSizeScale_Group2 = 0.05f,

                r_VT_MaxUploadsPerFrame = textureCopySpeedIndex switch
                {
                    0 => 16,
                    1 => 32,
                    2 => 64,
                    3 => 128,
                    _ => 128
                },
                r_VT_MaxTilesProducedPerFrame = textureGenerationSpeedIndex switch
                {
                    0 => 16,
                    1 => 32,
                    2 => 64,
                    3 => 128,
                    _ => 128
                }
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public TextureQualityViewModel() : base("Textures: ")
        {
        }
    }
}
