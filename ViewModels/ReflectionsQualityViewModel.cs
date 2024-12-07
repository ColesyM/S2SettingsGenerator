using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class ReflectionsQualityViewModel : QualityViewModel<ReflectionQualitySettings>
    {
        private int ssrQualityIndex;

        public int SSRQualityIndex
        {
            get { return ssrQualityIndex; }
            set
            {
                ssrQualityIndex = value;
                this.OnPropertyChanged("SSRQualityIndex");
            }
        }

        private bool halfResScene;

        public bool HalfResScene
        {
            get { return halfResScene; }
            set
            {
                halfResScene = value;
                this.OnPropertyChanged("HalfResScene");
            }
        }

        private bool lumenReflections;

        public bool LumenReflections
        {
            get { return lumenReflections; }
            set
            {
                lumenReflections = value;
                this.OnPropertyChanged("LumenReflections");
            }
        }

        private bool traceMeshReflections;

        public bool TraceMeshReflections
        {
            get { return traceMeshReflections; }
            set
            {
                traceMeshReflections = value;
                this.OnPropertyChanged("TraceMeshReflections");
            }
        }

        private int reflectionDownSampleIndex;

        public int ReflectionDownSampleIndex
        {
            get { return reflectionDownSampleIndex; }
            set { 
                reflectionDownSampleIndex = value;
                this.OnPropertyChanged("ReflectionDownSampleIndex");
            }
        }

        private float maxRoughness;

        public float MaxRoughness
        {
            get { return maxRoughness; }
            set { 
                maxRoughness = value;
                this.OnPropertyChanged("MaxRoughness");
            }
        }

        private int reflectionFilterSampleCountIndex;

        public int ReflectionFilterSampleCountIndex
        {
            get { return reflectionFilterSampleCountIndex; }
            set { 
                reflectionFilterSampleCountIndex = value;
                this.OnPropertyChanged("ReflectionFilterSampleCountIndex");
            }
        }

        private bool skipEmissiveOpaque;

        public bool SkipEmissiveOpaque
        {
            get { return skipEmissiveOpaque; }
            set { 
                skipEmissiveOpaque = value;
                this.OnPropertyChanged("SkipEmissiveOpaque");
            }
        }

        private bool skipEmissiveFront;

        public bool SkipEmissiveFront
        {
            get { return skipEmissiveFront; }
            set
            {
                skipEmissiveFront = value;
                this.OnPropertyChanged("SkipEmissiveFront");
            }
        }

        private bool lumenTransparency;

        public bool LumenTransparency
        {
            get { return lumenTransparency; }
            set
            {
                lumenTransparency = value;
                this.OnPropertyChanged("LumenTransparency");
            }
        }

        private bool useSceneColor;

        public bool UseSceneColor
        {
            get { return useSceneColor; }
            set
            {
                useSceneColor = value;
                this.OnPropertyChanged("UseSceneColor");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new ReflectionQualitySettings()
            {
                r_ReflectionMethod_Override = 1,
                r_SSR_Quality = ssrQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    _ => 3
                },
                r_SSR_HalfResSceneColor = halfResScene ? 1 : 0,
                r_Lumen_Reflections_Allow = lumenReflections ? 1 : 0,
                r_Lumen_Reflections_TraceMeshSDFs = traceMeshReflections ? 1 : 0,
                r_Lumen_Reflections_DownsampleFactor = reflectionDownSampleIndex switch
                {
                    0 => 0,
                    1 => 8,
                    2 => 4,
                    3 => 2,
                    4 => 1,
                    _ => 3
                },
                r_Lumen_Reflections_MaxRoughnessToTrace = maxRoughness,
                r_Lumen_Reflections_BilateralFilter_SpatialKernelRadius = 0.001f,
                r_Lumen_Reflections_BilateralFilter_NumSamples = reflectionFilterSampleCountIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 4,
                    _ => 2
                },
                r_Lumen_Reflections_SkipEmissive_Opaque = skipEmissiveOpaque ? 1 : 0,
                r_Lumen_Reflections_SkipEmissive_SLW = 1,
                r_Lumen_Reflections_SkipEmissive_FrontLayer = skipEmissiveFront ? 1 : 0,
                r_Lumen_TranslucencyReflections_FrontLayer_Allow = lumenTransparency ? 1 : 0,
                r_Lumen_TranslucencyReflections_FrontLayer_Enable = lumenTransparency ? 1 : 0,
                r_Lumen_Reflections_SampleSceneColorAtHit = useSceneColor ? 1 : 0
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public ReflectionsQualityViewModel() : base("Reflections: ")
        {
        }
    }
}