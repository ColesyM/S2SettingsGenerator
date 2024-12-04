using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class DOFQualityViewModel : QualityViewModel<DOFQualitySettings>
    {
        private int dofQualityIndex;

        public int DOFQualityIndex
        {
            get { return dofQualityIndex; }
            set { 
                dofQualityIndex = value;
                OnPropertyChanged("DOFQualityIndex");
            }
        }

        private int dofFilteringIndex;

        public int DOFFilteringIndex
        {
            get { return dofFilteringIndex; }
            set
            {
                dofFilteringIndex = value;
                OnPropertyChanged("DOFFilteringIndex");
            }
        }

        private bool isBokehEnabled;

        public bool IsBokehEnabled
        {
            get { return isBokehEnabled; }
            set { 
                isBokehEnabled = value;
                OnPropertyChanged("IsBokehEnabled");
            }
        }

        private int dofGatherRingIndex;

        public int DOFGatherRingIndex
        {
            get { return dofGatherRingIndex; }
            set
            {
                dofGatherRingIndex = value;
                OnPropertyChanged("DOFGatherRingIndex");
            }
        }

        private bool foregroundComposoting;

        public bool ForegroundComposoting
        {
            get { return foregroundComposoting; }
            set { 
                foregroundComposoting = value;

                OnPropertyChanged("ForegroundComposoting");
            }
        }

        private int backgroundCompositingIndex;

        public int BackgroundCompositingIndex
        {
            get { return backgroundCompositingIndex; }
            set
            {
                backgroundCompositingIndex = value;
                OnPropertyChanged("BackgroundCompositingIndex");
            }
        }

        private bool isScatterBokehEnabled;

        public bool IsScatterBokehEnabled
        {
            get { return isScatterBokehEnabled; }
            set
            {
                isScatterBokehEnabled = value;
                OnPropertyChanged("IsScatterBokehEnabled");
            }
        }

        private float maxSpriteRatio;

        public float MaxSpriteRatio
        {
            get { return maxSpriteRatio; }
            set { 
                maxSpriteRatio = value;
                OnPropertyChanged("MaxSpriteRatio");
            }
        }

        private int recombineQualityIndex;

        public int RecombineQualityIndex
        {
            get { return recombineQualityIndex; }
            set
            {
                dofQualityIndex = value;
                OnPropertyChanged("RecombineQualityIndex");
            }
        }

        private bool isFastDOFEnabled;

        public bool IsFastDOFEnabled
        {
            get { return isFastDOFEnabled; }
            set
            {
                isFastDOFEnabled = value;
                OnPropertyChanged("IsFastDOFEnabled");
            }
        }

        private float foregroundBlurLimit;

        public float ForegroundBlurLimit
        {
            get { return foregroundBlurLimit; }
            set { 
                foregroundBlurLimit = value;
                OnPropertyChanged("ForegroundBlurLimit");
            }
        }

        private float backgroundBlurLimit;

        public float BackgroundBlurLimit
        {
            get { return backgroundBlurLimit; }
            set
            {
                backgroundBlurLimit = value;
                OnPropertyChanged("BackgroundBlurLimit");
            }
        }

        public override void PopulateSettingsModel()
        {
            this.Settings = new DOFQualitySettings()
            {
                r_DepthOfFieldQuality = DOFQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 3
                },
                r_DOF_Gather_AccumulatorQuality = DOFQualityIndex switch
                {
                    0 => 0,
                    1 => 0,
                    2 => 0,
                    3 => 1,
                    _ => 1
                },
                r_DOF_Gather_PostfilterMethod = DOFFilteringIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 1
                },
                r_DOF_Gather_EnableBokehSettings = IsBokehEnabled ? 1 : 0,
                r_DOF_Gather_RingCount = DOFGatherRingIndex switch
                {
                    0 => 3,
                    1 => 4,
                    2 => 5,
                    _ => 4
                },
                r_DOF_Scatter_ForegroundCompositing = ForegroundComposoting ? 1 : 0,
                r_DOF_Scatter_BackgroundCompositing = BackgroundCompositingIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                r_DOF_Scatter_EnableBokehSettings = IsScatterBokehEnabled ? 1 : 0,
                r_DOF_Scatter_MaxSpriteRatio = MaxSpriteRatio,
                r_DOF_Recombine_Quality = RecombineQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 1
                },
                r_DOF_Recombine_EnableBokehSettings = IsScatterBokehEnabled ? 1 : 0,
                r_DOF_TemporalAAQuality = IsFastDOFEnabled ? 0 : 1, //inverted is correct
                r_DOF_Kernel_MaxForegroundRadius = ForegroundBlurLimit,
                r_DOF_Kernel_MaxBackgroundRadius = BackgroundBlurLimit
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public DOFQualityViewModel() : base("Depth Of Field: ")
        {
            DOFQualityIndex = 3;
            DOFFilteringIndex = 1;
            IsBokehEnabled = false;
            DOFGatherRingIndex = 1;
            ForegroundComposoting = false;
            BackgroundCompositingIndex = 2;
            IsScatterBokehEnabled = false;
            MaxSpriteRatio = 0.1f;
            RecombineQualityIndex = 1;
            IsFastDOFEnabled = false;
            ForegroundBlurLimit = 0.025f;
            BackgroundBlurLimit = 0.025f;
        }
    }
}
