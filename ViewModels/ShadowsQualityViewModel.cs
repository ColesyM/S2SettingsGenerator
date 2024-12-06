using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class ShadowsQualityViewModel : QualityViewModel<ShadowQualitySettings>
    {
        private int shadowQualityIndex;

        public int ShadowQualityIndex
        {
            get { return shadowQualityIndex; }
            set { 
                shadowQualityIndex = value; 
                this.OnPropertyChanged("ShadowQualityIndex");
            }
        }

        private int shadowCascades;

        public int ShadowCascades
        {
            get { return shadowCascades; }
            set
            {
                shadowCascades = value;
                this.OnPropertyChanged("ShadowCascades");
            }
        }

        private int shadowResIndex;

        public int ShadowResIndex
        {
            get { return shadowResIndex; }
            set
            {
                shadowResIndex = value;
                this.OnPropertyChanged("ShadowResIndex");
            }
        }

        private float shadowRadiousThresh;

        public float ShadowRadiousThresh
        {
            get { return shadowRadiousThresh; }
            set
            {
                shadowRadiousThresh = value;
                this.OnPropertyChanged("ShadowRadiousThresh");
            }
        }

        private float shadowDist;

        public float ShadowDist
        {
            get { return shadowDist; }
            set
            {
                shadowDist = value;
                this.OnPropertyChanged("ShadowDist");
            }
        }

        private int shadowTransitionScaleIndex;

        public int ShadowTransitionScaleIndex
        {
            get { return shadowTransitionScaleIndex; }
            set { 
                shadowTransitionScaleIndex = value;
                this.OnPropertyChanged("ShadowTransitionScaleIndex");
            }
        }

        private float preShadowRes;

        public float PreShadowRes
        {
            get { return preShadowRes; }
            set
            {
                preShadowRes = value;
                this.OnPropertyChanged("PreShadowRes");
            }
        }

        private float distantFieldShadowQuality;

        public float DistantFieldShadowQuality
        {
            get { return distantFieldShadowQuality; }
            set
            {
                distantFieldShadowQuality = value;
                this.OnPropertyChanged("DistantFieldShadowQuality");
            }
        }

        private bool distantFieldShadowing;

        public bool DistantFieldShadowing
        {
            get { return distantFieldShadowing; }
            set
            {
                distantFieldShadowing = value;
                this.OnPropertyChanged("DistantFieldShadowing");
            }
        }

        private int shadowPageSizeIndex;

        public int ShadowPageSizeIndex
        {
            get { return shadowPageSizeIndex; }
            set
            {
                shadowPageSizeIndex = value;
                this.OnPropertyChanged("ShadowPageSizeIndex");
            }
        }

        private int firstClipmapLevel;

        public int FirstClipmapLevel
        {
            get { return firstClipmapLevel; }
            set { 
                firstClipmapLevel = value;
                this.OnPropertyChanged("FirstClipmapLevel");
            }
        }

        private int directionalLightQualityPreferenceIndex;

        public int DirectionalLightQualityPreferenceIndex
        {
            get { return directionalLightQualityPreferenceIndex; }
            set { 
                directionalLightQualityPreferenceIndex = value;
                this.OnPropertyChanged("DirectionalLightQualityPreferenceIndex");
            }
        }

        private int viewBiasDirectional;

        public int ViewBiasDirectional
        {
            get { return viewBiasDirectional; }
            set
            {
                viewBiasDirectional = value;
                this.OnPropertyChanged("ViewBiasDirectional");
            }
        }

        private int shadowRaytraceQualityIndex;

        public int ShadowRaytraceQualityIndex
        {
            get { return shadowRaytraceQualityIndex; }
            set
            {
                shadowRaytraceQualityIndex = value;
                this.OnPropertyChanged("ShadowRaytraceQualityIndex");
            }
        }

        private float shadowMeshDetail;

        public float ShadowMeshDetail
        {
            get { return shadowMeshDetail; }
            set { 
                shadowMeshDetail = value;
                this.OnPropertyChanged("ShadowMeshDetail");
            }
        }

        private bool contactShadows;

        public bool ContactShadows
        {
            get { return contactShadows; }
            set
            {
                contactShadows = value;
                this.OnPropertyChanged("ContactShadows");
            }
        }

        private bool contactShadowsLocalLights;

        public bool ContactShadowsLocalLights
        {
            get { return contactShadowsLocalLights; }
            set
            {
                contactShadowsLocalLights = value;
                this.OnPropertyChanged("ContactShadowsLocalLights");
            }
        }

        private bool shadowSkeletelProxy;

        public bool ShadowSkeletelProxy
        {
            get { return shadowSkeletelProxy; }
            set { 
                shadowSkeletelProxy = value;
                this.OnPropertyChanged("ShadowSkeletelProxy");
            }
        }

        private bool shadowStaticSeperate;

        public bool ShadowStaticSeperate
        {
            get { return shadowStaticSeperate; }
            set
            {
                shadowStaticSeperate = value;
                this.OnPropertyChanged("ShadowStaticSeperate");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new ShadowQualitySettings()
            {
                r_LightFunctionQuality = 1,

                r_ShadowQuality = shadowQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    5 => 5,
                    _ => 5
                },

                r_Shadow_CSM_MaxCascades = shadowCascades,
                r_Shadow_MaxCSMResolution = shadowResIndex switch
                {
                    0 => 128,
                    1 => 256,
                    2 => 512,
                    3 => 1024,
                    4 => 2048,
                    5 => 4096,
                    _ => 2048,
                },

                r_Shadow_RadiusThreshold = shadowRadiousThresh,
                r_Shadow_DistanceScale = shadowDist,
                r_Shadow_CSM_TransitionScale = shadowTransitionScaleIndex switch
                {
                    0 => 0f,
                    1 => 1f,
                    2 => 2f,
                    _ => 1f
                },
                r_Shadow_PreShadowResolutionFactor = preShadowRes,

                r_DistanceFieldShadowing = distantFieldShadowing ? 1 : 0,
                r_DFShadowQuality = distantFieldShadowQuality,

                r_Shadow_Virtual_MaxPhysicalPages = shadowPageSizeIndex switch
                {
                    0 => 512,
                    1 => 1024,
                    2 => 2048,
                    3 => 4096,
                    _ => 4096
                },
                r_Shadow_Virtual_Clipmap_FirstLevel = firstClipmapLevel,
                r_Shadow_Virtual_ResolutionLodBiasDirectional = directionalLightQualityPreferenceIndex switch
                {
                    0 => 1.0f,
                    1 => 0f,
                    2 => -0.5f,
                    3 => -1f,
                    4 => -2f,
                    _ => -0.5f
                },
                r_Shadow_Virtual_ViewBias_Directional = viewBiasDirectional,
                r_Shadow_Virtual_OptimalSlopeBiasMultiplier_Directional = 0,
                r_Shadow_Virtual_SMRT_TexelDitherScaleDirectional = shadowRaytraceQualityIndex switch
                {
                    0 => 1,
                    1 => 1,
                    2 => 2,
                    3 => 2,
                    4 => 2,
                    _ => 2,
                },
                r_Shadow_Virtual_SMRT_RayCountDirectional = shadowRaytraceQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    _ => 4,
                },
                r_Shadow_Virtual_SMRT_SamplesPerRayDirectional = shadowRaytraceQualityIndex switch
                {
                    0 => 1,
                    1 => 1,
                    2 => 1,
                    3 => 1,
                    4 => 2,
                    _ => 2,
                },
                r_Shadow_Virtual_SMRT_RayLengthScaleDirectional = shadowRaytraceQualityIndex switch
                {
                    0 => 0.25f,
                    1 => 0.5f,
                    2 => 0.5f,
                    3 => 1f,
                    4 => 1f,
                    _ => 1f,
                },

                r_Shadow_Virtual_ResolutionLodBiasLocal = shadowMeshDetail,
                r_Shadow_Virtual_SMRT_RayCountLocal = shadowRaytraceQualityIndex switch
                {
                    0 => 1,
                    1 => 1,
                    2 => 2,
                    3 => 2,
                    4 => 2,
                    _ => 2,
                },
                r_Shadow_Virtual_SMRT_SamplesPerRayLocal = shadowRaytraceQualityIndex switch
                {
                    0 => 1,
                    1 => 1,
                    2 => 1,
                    3 => 2,
                    4 => 4,
                    _ => 4,
                },
                r_Shadow_Virtual_SMRT_MaxRayAngleFromLight = shadowRaytraceQualityIndex switch
                {
                    0 => 0.00025f,
                    1 => 0.0005f,
                    2 => 0.001f,
                    3 => 0.0025f,
                    4 => 0.0025f,
                    _ => 0.0025f,
                },
                r_ContactShadows = contactShadows ? 1 : 0,
                r_ContactShadows_EnableForLocalLights = contactShadowsLocalLights ? 1 : 0,

                r_SkeletalMesh_ShadowProxy_Use = shadowSkeletelProxy ? 1 : 0,

                r_Shadow_Virtual_Cache_StaticSeparate = shadowStaticSeperate ? 1 : 0,

            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public ShadowsQualityViewModel() : base("Shadows: ")
        {
        }
    }
}