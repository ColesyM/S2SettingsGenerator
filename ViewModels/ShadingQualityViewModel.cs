using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class ShadingQualityViewModel : QualityViewModel<ShadingQualitySettings>
    {
        private int sceneFormatIndex;

        public int SceneFormatIndex
        {
            get { return sceneFormatIndex; }
            set { 
                sceneFormatIndex = value; 
                this.OnPropertyChanged("SceneFormatIndex");
            }
        }

        private bool translucentLighting;

        public bool TranslucentLighting
        {
            get { return translucentLighting; }
            set
            {
                translucentLighting = value;
                this.OnPropertyChanged("TranslucentLighting");
            }
        }

        private int translucentLightingDimensionsIndex;

        public int TranslucentLightingDimensionsIndex
        {
            get { return translucentLightingDimensionsIndex; }
            set
            {
                translucentLightingDimensionsIndex = value;
                this.OnPropertyChanged("TranslucentLightingDimensionsIndex");
            }
        }

        private bool blurTranslucent;

        public bool BlurTranslucent
        {
            get { return blurTranslucent; }
            set { 
                blurTranslucent = value;
                this.OnPropertyChanged("BlurTranslucent");
            }
        }

        private bool subsurfaceScattering;

        public bool SubsurfaceScattering
        {
            get { return subsurfaceScattering; }
            set
            {
                subsurfaceScattering = value;
                this.OnPropertyChanged("SubsurfaceScattering");
            }
        }

        private bool screenSpaceSubsurfaceScattering;

        public bool ScreenSpaceSubsurfaceScattering
        {
            get { return screenSpaceSubsurfaceScattering; }
            set
            {
                screenSpaceSubsurfaceScattering = value;
                this.OnPropertyChanged("ScreenSpaceSubsurfaceScattering");
            }
        }

        private int subsurfaceScatteringSamplesIndex;

        public int SubsurfaceScatteringSamplesIndex
        {
            get { return subsurfaceScatteringSamplesIndex; }
            set
            {
                subsurfaceScatteringSamplesIndex = value;
                this.OnPropertyChanged("SubsurfaceScatteringSamplesIndex");
            }
        }

        private bool higherQualitySubsurfaceScattering;

        public bool HigherQualitySubsurfaceScattering
        {
            get { return higherQualitySubsurfaceScattering; }
            set
            {
                higherQualitySubsurfaceScattering = value;
                this.OnPropertyChanged("HigherQualitySubsurfaceScattering");
            }
        }

        private bool lowerQualitySubsurfaceScattering;

        public bool LowerQualitySubsurfaceScattering
        {
            get { return lowerQualitySubsurfaceScattering; }
            set
            {
                lowerQualitySubsurfaceScattering = value;
                this.OnPropertyChanged("LowerQualitySubsurfaceScattering");
            }
        }

        private int ambientOcclusionFactorIndex;

        public int AmbientOcclusionFactorIndex
        {
            get { return ambientOcclusionFactorIndex; }
            set
            {
                ambientOcclusionFactorIndex = value;
                this.OnPropertyChanged("AmbientOcclusionFactorIndex");
            }
        }

        private int ambientOcclusionQualityIndex;

        public int AmbientOcclusionQualityIndex
        {
            get { return ambientOcclusionQualityIndex; }
            set
            {
                ambientOcclusionQualityIndex = value;
                this.OnPropertyChanged("AmbientOcclusionQualityIndex");
            }
        }

        private bool alwaysRequestMaxAmbientOcclusion;

        public bool AlwaysRequestMaxAmbientOcclusion
        {
            get { return alwaysRequestMaxAmbientOcclusion; }
            set
            {
                alwaysRequestMaxAmbientOcclusion = value;
                this.OnPropertyChanged("AlwaysRequestMaxAmbientOcclusion");
            }
        }

        private int ambientOcclusionQuality;

        public int AmbientOcclusionQuality
        {
            get { return ambientOcclusionQuality; }
            set
            {
                ambientOcclusionQuality = value;
                this.OnPropertyChanged("AmbientOcclusionQuality");
            }
        }

        private int ambientOcclusionRadius;

        public int AmbientOcclusionRadius
        {
            get { return ambientOcclusionRadius; }
            set
            {
                ambientOcclusionRadius = value;
                this.OnPropertyChanged("AmbientOcclusionRadius");
            }
        }

        private bool translucentShadowFilter;

        public bool TranslucentShadowFilter
        {
            get { return translucentShadowFilter; }
            set { 
                translucentShadowFilter = value;
                this.OnPropertyChanged("TranslucentShadowFilter");
            }
        }


        public override void PopulateSettingsModel()
        {
            Settings = new ShadingQualitySettings()
            {
                r_SceneColorFormat = sceneFormatIndex switch
                {
                    0 => 3,
                    1 => 4,
                    _ => 4
                },
                r_TranslucentLightingVolume = translucentLighting ? 1 : 0,
                r_TranslucencyLightingVolumeDim = translucentLightingDimensionsIndex switch
                {
                    0 => 32,
                    1 => 64,
                    2 => 128,
                    _ => 64
                },
                r_TranslucencyVolumeBlur = blurTranslucent ? 1 : 0,
                r_SubsurfaceScatteringPass = subsurfaceScattering ? 1 : 0,
                r_SSS_Scale = screenSpaceSubsurfaceScattering ? 1.0f : 0f,
                r_SSS_SampleSet = subsurfaceScatteringSamplesIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                r_SSS_Quality = higherQualitySubsurfaceScattering ? -1 : 0,
                r_SSS_HalfRes = lowerQualitySubsurfaceScattering ? 1 : 0,
                r_AmbientOcclusionMipLevelFactor = ambientOcclusionFactorIndex switch
                {
                    0 => 0,
                    1 => 0.5f,
                    2 => 1,
                    _ => 10,
                },
                r_AmbientOcclusionMaxQuality = alwaysRequestMaxAmbientOcclusion ? 100 : ambientOcclusionQuality,
                r_AmbientOcclusionLevels = ambientOcclusionQualityIndex switch
                {
                    0 => -1,
                    1 => 0,
                    2 => 1,
                    3 => 2,
                    4 => 3,
                    _ => -1
                },
                r_AmbientOcclusionRadiusScale = AmbientOcclusionRadius,
                r_TranslucencyLightingVolume_UseShadowFiltering = translucentShadowFilter ? 1 : 0
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public ShadingQualityViewModel() : base("Shading: ")
        {
        }
    }
}
