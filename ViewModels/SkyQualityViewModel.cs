using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class SkyQualityViewModel : QualityViewModel<SkyQualitySettings>
    {
        private int maxSamples;

        public int MaxSamples
        {
            get { return maxSamples; }
            set
            {
                maxSamples = value;
                this.OnPropertyChanged("MaxSamples");
            }
        }

        private int depthLevelIndex;

        public int DepthLevelIndex
        {
            get { return depthLevelIndex; }
            set
            {
                depthLevelIndex = value;
                this.OnPropertyChanged("DepthLevelIndex");
            }
        }

        private float colorSamples;

        public float ColorSamples
        {
            get { return colorSamples; }
            set
            {
                colorSamples = value;
                this.OnPropertyChanged("ColorSamples");
            }
        }

        private float atmosphereSamples;

        public float AtmosphereSamples
        {
            get { return atmosphereSamples; }
            set
            {
                atmosphereSamples = value;
                this.OnPropertyChanged("AtmosphereSamples");
            }
        }

        private float transmittanceSamples;

        public float TransmittanceSamples
        {
            get { return transmittanceSamples; }
            set
            {
                transmittanceSamples = value;
                this.OnPropertyChanged("TransmittanceSamples");
            }
        }

        private float scatteringSamples;

        public float ScatteringSamples
        {
            get { return scatteringSamples; }
            set
            {
                scatteringSamples = value;
                this.OnPropertyChanged("ScatteringSamples");
            }
        }

        private bool higherFormatLUT;

        public bool HigherFormatLUT
        {
            get { return higherFormatLUT; }
            set { 
                higherFormatLUT = value;
                this.OnPropertyChanged("HigherFormatLUT");
            }
        }

        private bool skyReflection;

        public bool SkyReflection
        {
            get { return skyReflection; }
            set
            {
                skyReflection = value;
                this.OnPropertyChanged("SkyReflection");
            }
        }

        private int skyReflectionResIndex;

        public int SkyReflectionResIndex
        {
            get { return skyReflectionResIndex; }
            set
            {
                skyReflectionResIndex = value;
                this.OnPropertyChanged("SkyReflectionResIndex");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new SkyQualitySettings()
            {
                r_SkyAtmosphere_AerialPerspectiveLUT_FastApplyOnOpaque = 1,
                r_SkyAtmosphere_AerialPerspectiveLUT_SampleCountMaxPerSlice = maxSamples,
                r_SkyAtmosphere_AerialPerspectiveLUT_DepthResolution = depthLevelIndex switch
                {
                    0 => 2f,
                    1 => 4f,
                    2 => 8f,
                    3 => 16f,
                    4 => 16f,
                    5 => 32f,
                    _ => 16f
                },
                r_SkyAtmosphere_FastSkyLUT = 1,
                r_SkyAtmosphere_FastSkyLUT_SampleCountMin = 4.0f,
                r_SkyAtmosphere_FastSkyLUT_SampleCountMax = colorSamples,
                r_SkyAtmosphere_SampleCountMin = 4.0f,
                r_SkyAtmosphere_SampleCountMax = atmosphereSamples,
                r_SkyAtmosphere_TransmittanceLUT_UseSmallFormat = higherFormatLUT ? 0 : 1, //inverse is correct
                r_SkyAtmosphere_TransmittanceLUT_SampleCount = transmittanceSamples,
                r_SkyAtmosphere_MultiScatteringLUT_SampleCount = scatteringSamples,
                r_SkyLight_RealTimeReflectionCapture = skyReflection ? 1 : 0,
                r_SkyLight_RealTimeReflectionCapture_TimeSlice_SkyCloudCubeFacePerFrame = skyReflectionResIndex switch
                {
                    0 => 2,
                    1 => 3,
                    2 => 6,
                    3 => 8,
                    _ => 6
                },
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public SkyQualityViewModel() : base("Sky: ")
        {
        }
    }
}
