using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace S2SettingsGenerator
{
    internal struct ShadowQualitySettings
    {
        public int r_LightFunctionQuality = 1;

        public int r_ShadowQuality = 5;

        public int r_Shadow_CSM_MaxCascades = 10;
        public int r_Shadow_MaxCSMResolution = 2048;

        public float r_Shadow_RadiusThreshold = 0.01f;
        public float r_Shadow_DistanceScale = 1.0f;
        public float r_Shadow_CSM_TransitionScale = 1.0f;
        public float r_Shadow_PreShadowResolutionFactor = 1.0f;

        public int r_DistanceFieldShadowing = 1;
        public float r_DFShadowQuality = 1;

        public int r_Shadow_Virtual_MaxPhysicalPages = 4096;

        public int r_Shadow_Virtual_Clipmap_FirstLevel = 6;
        public float r_Shadow_Virtual_ResolutionLodBiasDirectional = -0.5f;
        public int r_Shadow_Virtual_ViewBias_Directional = 0;
        public int r_Shadow_Virtual_OptimalSlopeBiasMultiplier_Directional = 0;
        public int r_Shadow_Virtual_SMRT_TexelDitherScaleDirectional = 2;
        public int r_Shadow_Virtual_SMRT_RayCountDirectional = 4;
        public int r_Shadow_Virtual_SMRT_SamplesPerRayDirectional = 2;
        public float r_Shadow_Virtual_SMRT_RayLengthScaleDirectional = 1.0f;

        public float r_Shadow_Virtual_ResolutionLodBiasLocal = 0f;
        public int r_Shadow_Virtual_SMRT_RayCountLocal = 2;
        public int r_Shadow_Virtual_SMRT_SamplesPerRayLocal = 2;
        public float r_Shadow_Virtual_SMRT_MaxRayAngleFromLight = 0.0025f; //vk: Default: 0_03_With current settings default value gives too much noise_ 0_0025 seems good and still have soft shadows_

        public int r_ContactShadows = 1;
        public int r_ContactShadows_EnableForLocalLights = 1;

        public int r_SkeletalMesh_ShadowProxy_Use = 0;

        public int r_Shadow_Virtual_Cache_StaticSeparate = 1;

        public ShadowQualitySettings()
        {
           
        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.LightFunctionQuality={r_LightFunctionQuality}");
            sb.AppendLine($"r.ShadowQuality.={r_ShadowQuality}");
            sb.AppendLine($"r.Shadow.CSM.MaxCascades={r_Shadow_CSM_MaxCascades}");
            sb.AppendLine($"r.Shadow.MaxCSMResolution={r_Shadow_MaxCSMResolution}");
            sb.AppendLine($"r.Shadow.RadiusThreshold={r_Shadow_RadiusThreshold}");
            sb.AppendLine($"r.Shadow.DistanceScale={r_Shadow_DistanceScale}");
            sb.AppendLine($"r.Shadow.CSM.TransitionScale={r_Shadow_CSM_TransitionScale}");
            sb.AppendLine($"r.Shadow.PreShadowResolutionFactor={r_Shadow_PreShadowResolutionFactor}");
            sb.AppendLine($"r.Shadow.DistanceFieldShadowing={r_DistanceFieldShadowing}");
            sb.AppendLine($"r.Shadow.DFShadowQuality={r_DFShadowQuality}");
            sb.AppendLine($"r.Shadow.Virtual.MaxPhysicalPages={r_Shadow_Virtual_MaxPhysicalPages}");
            sb.AppendLine($"r.Shadow.Virtual.Clipmap.FirstLevel={r_Shadow_Virtual_Clipmap_FirstLevel}");
            sb.AppendLine($"r.Shadow.Virtual.ResolutionLodBiasDirectional={r_Shadow_Virtual_ResolutionLodBiasDirectional}");
            sb.AppendLine($"r.Shadow.Virtual.ViewBias_Directional.={r_Shadow_Virtual_ViewBias_Directional}");
            sb.AppendLine($"r.Shadow.Virtual.OptimalSlopeBiasMultiplier.Directional={r_Shadow_Virtual_OptimalSlopeBiasMultiplier_Directional}");
            sb.AppendLine($"r.Shadow.Virtual.SMRTTexelDitherScaleDirectional.={r_Shadow_Virtual_SMRT_TexelDitherScaleDirectional}");
            sb.AppendLine($"r.Shadow.Virtual.SMRT.RayCountDirectional={r_Shadow_Virtual_SMRT_RayCountDirectional}");
            sb.AppendLine($"r.Shadow.Virtual.SMRT.SamplesPerRayDirectional={r_Shadow_Virtual_SMRT_SamplesPerRayDirectional}");
            sb.AppendLine($"r.Shadow.Virtual.SMRT.RayLengthScaleDirectional={r_Shadow_Virtual_SMRT_RayLengthScaleDirectional}");
            sb.AppendLine($"r.Shadow.Virtual.ResolutionLodBiasLocal={r_Shadow_Virtual_ResolutionLodBiasLocal}");
            sb.AppendLine($"r.Shadow.Virtual.SMRT.RayCountLocal={r_Shadow_Virtual_SMRT_RayCountLocal}");
            sb.AppendLine($"r.Shadow.Virtual.SMRT.SamplesPerRayLocal={r_Shadow_Virtual_SMRT_SamplesPerRayLocal}");
            sb.AppendLine($"r.Shadow.Virtual.SMRT.MaxRayAngleFromLight={r_Shadow_Virtual_SMRT_MaxRayAngleFromLight}");
            sb.AppendLine($"r.ContactShadows={r_ContactShadows}");
            sb.AppendLine($"r.ContactShadows.EnableForLocalLights={r_ContactShadows_EnableForLocalLights}");
            sb.AppendLine($"r.SkeletalMesh.ShadowProxy.Use={r_SkeletalMesh_ShadowProxy_Use}");
            sb.AppendLine($"r.Shadow.Virtual.Cache.StaticSeparat={r_Shadow_Virtual_Cache_StaticSeparate}");
        }
    }
}
