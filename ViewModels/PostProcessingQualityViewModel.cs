using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class PostProcessingQualityViewModel : QualityViewModel<PostProcessQualitySettings>
    {
        private int renderTargetPool;

        public int RenderTargetPool
        {
            get { return renderTargetPool; }
            set { 
                renderTargetPool = value;
                this.OnPropertyChanged("RenderTargetPool");
            }
        }

        private int lensFlareQualityIndex;

        public int LensFlareQualityIndex
        {
            get { return lensFlareQualityIndex; }
            set
            {
                lensFlareQualityIndex = value;
                this.OnPropertyChanged("LensFlareQualityIndex");
            }
        }

        private bool improveFringeQuality;

        public bool ImproveFringeQuality
        {
            get { return improveFringeQuality; }
            set { 
                improveFringeQuality = value;
                this.OnPropertyChanged("ImproveFringeQuality");
            }
        }

        private bool eyeAdaptation;

        public bool EyeAdaptation
        {
            get { return eyeAdaptation; }
            set
            {
                eyeAdaptation = value;
                this.OnPropertyChanged("EyeAdaptation");
            }
        }

        private float eyeAdaptationLensAttenuation;

        public float EyeAdaptationLensAttenuation
        {
            get { return eyeAdaptationLensAttenuation; }
            set
            {
                eyeAdaptationLensAttenuation = value;
                this.OnPropertyChanged("EyeAdaptationLensAttenuation");
            }
        }

        private int bloomQualityIndex;

        public int BloomQualityIndex
        {
            get { return bloomQualityIndex; }
            set
            {
                bloomQualityIndex = value;
                this.OnPropertyChanged("BloomQualityIndex");
            }
        }

        private int blurOptimizationIndex;

        public int BlurOptimizationIndex
        {
            get { return blurOptimizationIndex; }
            set
            {
                blurOptimizationIndex = value;
                this.OnPropertyChanged("BlurOptimizationIndex");
            }
        }

        private int upscaleQualityIndex;

        public int UpscaleQualityIndex
        {
            get { return upscaleQualityIndex; }
            set
            {
                upscaleQualityIndex = value;
                this.OnPropertyChanged("UpscaleQualityIndex");
            }
        }

        private bool grainQuant;

        public bool GrainQuant
        {
            get { return grainQuant; }
            set { 
                grainQuant = value;
                this.OnPropertyChanged("GrainQuant");
            }
        }

        private bool lightShafts;

        public bool LightShafts
        {
            get { return lightShafts; }
            set
            {
                lightShafts = value;
                this.OnPropertyChanged("LightShafts");
            }
        }

        private int lightshaftQualityIndex;

        public int LightshaftQualityIndex
        {
            get { return lightshaftQualityIndex; }
            set
            {
                lightshaftQualityIndex = value;
                this.OnPropertyChanged("LightshaftQualityIndex");
            }
        }


        private int filteringQualityIndex;

        public int FilteringQualityIndex
        {
            get { return filteringQualityIndex; }
            set
            {
                filteringQualityIndex = value;
                this.OnPropertyChanged("FilteringQualityIndex");
            }
        }

        private int toneMapperIndex;

        public int ToneMapperIndex
        {
            get { return toneMapperIndex; }
            set
            {
                toneMapperIndex = value;
                this.OnPropertyChanged("ToneMapperIndex");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new PostProcessQualitySettings()
            {
                r_RenderTargetPoolMin = renderTargetPool,
                r_LensFlareQuality = lensFlareQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                r_SceneColorFringeQuality = improveFringeQuality ? 1 : 0,
                r_EyeAdaptationQuality = eyeAdaptation ? 2 : 0,
                r_EyeAdaptation_LensAttenuation = eyeAdaptationLensAttenuation,
                r_BloomQuality = bloomQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    5 => 5,
                    _ => 5
                },
                r_FastBlurThreshold = blurOptimizationIndex switch
                {
                    0 => 0,
                    1 => 3,
                    2 => 7,
                    3 => 100,
                    _ => 100
                },
                r_Upscale_Quality = upscaleQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    5 => 5,
                    _ => 3
                },
                r_Tonemapper_GrainQuantization = grainQuant ? 1 : 0,
                r_LightShaftQuality = lightShafts ? 1 : 0,
                r_LightShaftDownSampleFactor = lightshaftQualityIndex switch
                {
                    0 => 8,
                    1 => 4,
                    2 => 2,
                    3 => 1,
                    _ => 2,
                },
                r_Filter_SizeScale = filteringQualityIndex switch
                {
                    0 => 0.6f,
                    1 => 0.8f,
                    2 => 1f,
                    _ => 1f
                },
                r_Tonemapper_Quality = toneMapperIndex switch
                {
                    0 => 0,
                    1 => 2,
                    2 => 4,
                    3 => 5,
                    _ => 5
                }
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public PostProcessingQualityViewModel() : base("Post Processing: ")
        {
        }
    }
}