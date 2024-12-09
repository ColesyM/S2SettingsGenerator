using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct ShadowQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.LightFunctionQuality")]
        public int r_LightFunctionQuality = 1;
        [IniPropertyAttribute("r.ShadowQuality")]
        public int r_ShadowQuality = 5;
        [IniPropertyAttribute("r.Shadow.CSM.MaxCascades")]
        public int r_Shadow_CSM_MaxCascades = 10;
        [IniPropertyAttribute("r.Shadow.MaxCSMResolution")]
        public int r_Shadow_MaxCSMResolution = 2048;
        [IniPropertyAttribute("r.Shadow.RadiusThreshold")]
        public float r_Shadow_RadiusThreshold = 0.01f;
        [IniPropertyAttribute("r.Shadow.DistanceScale")]
        public float r_Shadow_DistanceScale = 1.0f;
        [IniPropertyAttribute("r.Shadow.CSM.TransitionScale")]
        public float r_Shadow_CSM_TransitionScale = 1.0f;
        [IniPropertyAttribute("r.Shadow.PreShadowResolutionFactor")]
        public float r_Shadow_PreShadowResolutionFactor = 1.0f;
        [IniPropertyAttribute("r.DistanceFieldShadowing")]
        public int r_DistanceFieldShadowing = 1;
        [IniPropertyAttribute("r.DFShadowQuality")]
        public float r_DFShadowQuality = 1;
        [IniPropertyAttribute("r.Shadow.Virtual.MaxPhysicalPages")]
        public int r_Shadow_Virtual_MaxPhysicalPages = 4096;
        [IniPropertyAttribute("r.Shadow.Virtual.Clipmap.FirstLevel")]
        public int r_Shadow_Virtual_Clipmap_FirstLevel = 6;
        [IniPropertyAttribute("r.Shadow.Virtual.ResolutionLodBiasDirectional")]
        public float r_Shadow_Virtual_ResolutionLodBiasDirectional = -0.5f;
        [IniPropertyAttribute("r.Shadow.Virtual.ViewBias.Directional")]
        public int r_Shadow_Virtual_ViewBias_Directional = 0;
        [IniPropertyAttribute("r.Shadow.Virtual.OptimalSlopeBiasMultiplier.Directional")]
        public int r_Shadow_Virtual_OptimalSlopeBiasMultiplier_Directional = 0;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.TexelDitherScaleDirectional")]
        public int r_Shadow_Virtual_SMRT_TexelDitherScaleDirectional = 2;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.RayCountDirectional")]
        public int r_Shadow_Virtual_SMRT_RayCountDirectional = 4;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.SamplesPerRayDirectional")]
        public int r_Shadow_Virtual_SMRT_SamplesPerRayDirectional = 2;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.RayLengthScaleDirectional")]
        public float r_Shadow_Virtual_SMRT_RayLengthScaleDirectional = 1.0f;
        [IniPropertyAttribute("r.Shadow.Virtual.ResolutionLodBiasLocal")]
        public float r_Shadow_Virtual_ResolutionLodBiasLocal = 0f;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.RayCountLocal")]
        public int r_Shadow_Virtual_SMRT_RayCountLocal = 2;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.SamplesPerRayLocal")]
        public int r_Shadow_Virtual_SMRT_SamplesPerRayLocal = 2;
        [IniPropertyAttribute("r.Shadow.Virtual.SMRT.MaxRayAngleFromLight")]
        public float r_Shadow_Virtual_SMRT_MaxRayAngleFromLight = 0.0025f; //vk: Default: 0_03_With current settings default value gives too much noise_ 0_0025 seems good and still have soft shadows_
        [IniPropertyAttribute("r.ContactShadows")]
        public int r_ContactShadows = 1;
        [IniPropertyAttribute("r.ContactShadows.EnableForLocalLights")]
        public int r_ContactShadows_EnableForLocalLights = 1;
        [IniPropertyAttribute("r.SkeletalMesh.ShadowProxy.Use")]
        public int r_SkeletalMesh_ShadowProxy_Use = 0;
        [IniPropertyAttribute("r.Shadow.Virtual.Cache.StaticSeparate")]
        public int r_Shadow_Virtual_Cache_StaticSeparate = 1;

        public ShadowQualitySettings()
        {  
        }
    }
}
