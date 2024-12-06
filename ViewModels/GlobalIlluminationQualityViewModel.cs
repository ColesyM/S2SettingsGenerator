using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class GlobalIlluminationQualityViewModel : QualityViewModel<GlobalIlluminationQualitySettings>
    {
        private bool indirectDiffuse;

        public bool IndirectDiffuse
        {
            get { return indirectDiffuse; }
            set
            {
                indirectDiffuse = value;
                this.OnPropertyChanged("IndirectDiffuse");
            }
        }

        private bool detailedMeshTracing;

        public bool DetailedMeshTracing
        {
            get { return detailedMeshTracing; }
            set
            {
                detailedMeshTracing = value;
                this.OnPropertyChanged("DetailedMeshTracing");
            }
        }

        private int detailedMeshTracingDist;

        public int DetailedMeshTracingDist
        {
            get { return detailedMeshTracingDist; }
            set { 
                detailedMeshTracingDist = value;
                this.OnPropertyChanged("DetailedMeshTracingDist");
            }
        }

        private bool radiosity;

        public bool Radiosity
        {
            get { return radiosity; }
            set { 
                radiosity = value;
                this.OnPropertyChanged("Radiosity");
            }
        }

        private bool offscreenTraceMeshes;

        public bool OffscreenTraceMeshes
        {
            get { return offscreenTraceMeshes; }
            set { 
                offscreenTraceMeshes = value;
                this.OnPropertyChanged("OffscreenTraceMeshes");
            }
        }

        private int lumenMeshCardSize;

        public int LumenMeshCardSize
        {
            get { return lumenMeshCardSize; }
            set { 
                lumenMeshCardSize = value;
                this.OnPropertyChanged("LumenMeshCardSize");
            }
        }

        private int lumenAtlasSizeIndex;

        public int LumenAtlasSizeIndex
        {
            get { return lumenAtlasSizeIndex; }
            set { 
                lumenAtlasSizeIndex = value;
                this.OnPropertyChanged("LumenAtlasSizeIndex");
            }
        }

        private int probeDownsampleIndex;

        public int ProbeDownsampleIndex
        {
            get { return probeDownsampleIndex; }
            set { 
                probeDownsampleIndex = value;
                this.OnPropertyChanged("ProbeDownsampleIndex");
            }
        }

        private int traceOctaResIndex;

        public int TraceOctaResIndex
        {
            get { return traceOctaResIndex; }
            set
            {
                traceOctaResIndex = value;
                this.OnPropertyChanged("TraceOctaResIndex");
            }
        }

        private bool stochasticInterpolation;

        public bool StochasticInterpolation
        {
            get { return stochasticInterpolation; }
            set { 
                stochasticInterpolation = value;
                this.OnPropertyChanged("StochasticInterpolation");
            }
        }

        private bool twoSidedFoliageBackfaceDiffuse;

        public bool TwoSidedFoliageBackfaceDiffuse
        {
            get { return twoSidedFoliageBackfaceDiffuse; }
            set { 
                twoSidedFoliageBackfaceDiffuse = value;
                this.OnPropertyChanged("TwoSidedFoliageBackfaceDiffuse");
            }
        }

        private int probeResIndex;

        public int ProbeResIndex
        {
            get { return probeResIndex; }
            set { 
                probeResIndex = value;
                this.OnPropertyChanged("ProbeResIndex");
            }
        }

        private int probeTraceBudgetIndex;

        public int ProbeTraceBudgetIndex
        {
            get { return probeTraceBudgetIndex; }
            set { 
                probeTraceBudgetIndex = value;
                this.OnPropertyChanged("ProbeTraceBudgetIndex");
            }
        }

        private int probeAtlasResIndex;

        public int ProbeAtlasResIndex
        {
            get { return probeAtlasResIndex; }
            set { 
                probeAtlasResIndex = value;
                this.OnPropertyChanged("ProbeAtlasResIndex");
            }
        }

        private int probeCacheFrameKeepIndex;

        public int ProbeCacheFrameKeepIndex
        {
            get { return probeCacheFrameKeepIndex; }
            set { 
                probeCacheFrameKeepIndex = value;
                this.OnPropertyChanged("ProbeCacheFrameKeepIndex");
            }
        }

        private bool lumenTranslucencyVolume;

        public bool LumenTranslucencyVolume
        {
            get { return lumenTranslucencyVolume; }
            set { 
                lumenTranslucencyVolume = value;
                this.OnPropertyChanged("LumenTranslucencyVolume");
            }
        }

        private bool lumenTranslucencyTrace;

        public bool LumenTranslucencyTrace
        {
            get { return lumenTranslucencyTrace; }
            set
            {
                lumenTranslucencyTrace = value;
                this.OnPropertyChanged("LumenTranslucencyTrace");
            }
        }

        private int lumenFarfieldDist;

        public int LumenFarfieldDist
        {
            get { return lumenFarfieldDist; }
            set
            {
                lumenFarfieldDist = value;
                this.OnPropertyChanged("LumenFarfieldDist");
            }
        }

        private bool tighterProbes;

        public bool TighterProbes
        {
            get { return tighterProbes; }
            set
            {
                tighterProbes = value;
                this.OnPropertyChanged("TighterProbes");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new GlobalIlluminationQualitySettings()
            {
                r_DynamicGlobalIlluminationMethod_Override = 1,
                r_Lumen_DiffuseIndirect_Allow = indirectDiffuse ? 1 : 0,
                r_Lumen_TraceMeshSDFs_Allow = detailedMeshTracing ? 1 : 0,
                r_Lumen_TraceMeshSDFs_TraceDistance = detailedMeshTracingDist,

                r_LumenScene_Radiosity = radiosity ? 1 : 0,

                r_LumenScene_DirectLighting_OffscreenShadowing_TraceMeshSDFs = offscreenTraceMeshes ? 1 : 0,

                r_LumenScene_SurfaceCache_MeshCardsMinSize = lumenMeshCardSize,
                r_LumenScene_SurfaceCache_AtlasSize = lumenAtlasSizeIndex switch
                {
                    0 => 256,
                    1 => 512,
                    2 => 1024,
                    3 => 2048,
                    4 => 4096,
                    _ => 2048
                },
                r_LumenScene_SurfaceCache_CardCaptureRefreshFraction = 0,

                r_Lumen_ScreenProbeGather_DownsampleFactor = probeDownsampleIndex switch
                {
                    0 => 96,
                    1 => 48,
                    2 => 32,
                    3 => 16,
                    4 => 8,
                    _ => 32
                },
                r_Lumen_ScreenProbeGather_TracingOctahedronResolution = traceOctaResIndex switch
                {
                    0 => 4,
                    1 => 8,
                    2 => 16,
                    _ => 8
                },
                r_Lumen_ScreenProbeGather_ScreenSpaceBentNormal = 0,
                r_Lumen_ScreenProbeGather_StochasticInterpolation = stochasticInterpolation ? 1 : 0,
                r_Lumen_ScreenProbeGather_FullResolutionJitterWidth = 2,
                r_Lumen_ScreenProbeGather_TwoSidedFoliageBackfaceDiffuse = twoSidedFoliageBackfaceDiffuse ? 1 : 0,
                r_Lumen_ScreenProbeGather_RadianceCache_GridResolution = 48,
                r_Lumen_ScreenProbeGather_RadianceCache_ProbeResolution = probeResIndex switch
                {
                    0 => 16,
                    1 => 32,
                    2 => 64,
                    _ => 32
                },
                r_Lumen_ScreenProbeGather_RadianceCache_NumProbesToTraceBudget = probeTraceBudgetIndex switch
                {
                    0 => 10,
                    1 => 25,
                    2 => 50,
                    3 => 75,
                    4 => 100,
                    5 => 200,
                    _ => 100,
                },
                r_Lumen_ScreenProbeGather_RadianceCache_ProbeAtlasResolutionInProbes = probeAtlasResIndex switch
                {
                    0 => 64,
                    1 => 128,
                    2 => 256,
                    3 => 512,
                    _ => 256
                },

                r_Lumen_RadianceCache_NumFramesToKeepCachedProbes = probeCacheFrameKeepIndex switch
                {
                    0 => 4,
                    1 => 15,
                    2 => 30,
                    _ => 15
                },

                r_LumenScene_GlobalSDF_Resolution = 252, // all the same

                r_Lumen_TranslucencyVolume_Enable = lumenTranslucencyVolume ? 1 : 0,
                r_Lumen_TranslucencyVolume_TraceFromVolume = lumenTranslucencyTrace ? 1 : 0,
                r_Lumen_TranslucencyVolume_TracingOctahedronResolution = 2,
                r_Lumen_TranslucencyVolume_GridPixelSize = 64,

                r_LumenScene_SurfaceCache_FarField_Distance = lumenFarfieldDist,
                r_LumenScene_SurfaceCache_CardMinResolution = 4,

                r_LumenScene_Radiosity_ProbeSpacing = tighterProbes ? 4 : 8
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public GlobalIlluminationQualityViewModel() : base("Global Illumination: ")
        {
        }
    }
}
