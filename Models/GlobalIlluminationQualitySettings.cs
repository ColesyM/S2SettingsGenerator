using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct GlobalIlluminationQualitySettings : ISettingsModel
    {
        public int r_DynamicGlobalIlluminationMethod_Override = 1;
        public int r_Lumen_DiffuseIndirect_Allow = 1;
        public int r_Lumen_TraceMeshSDFs_Allow=1;
        public int r_Lumen_TraceMeshSDFs_TraceDistance = 90;

        public int r_LumenScene_Radiosity = 1;

        public int r_LumenScene_DirectLighting_OffscreenShadowing_TraceMeshSDFs = 0;

        public int r_LumenScene_SurfaceCache_MeshCardsMinSize=50;
        public int r_LumenScene_SurfaceCache_AtlasSize=2048;
        public int r_LumenScene_SurfaceCache_CardCaptureRefreshFraction = 0;

        public int r_Lumen_ScreenProbeGather_DownsampleFactor=32;
        public int r_Lumen_ScreenProbeGather_TracingOctahedronResolution=8;
        public int r_Lumen_ScreenProbeGather_ScreenSpaceBentNormal=0;
        public int r_Lumen_ScreenProbeGather_StochasticInterpolation=0;
        public int r_Lumen_ScreenProbeGather_FullResolutionJitterWidth=2;
        public int r_Lumen_ScreenProbeGather_TwoSidedFoliageBackfaceDiffuse = 1;
        public int r_Lumen_ScreenProbeGather_RadianceCache_GridResolution=48;
        public int r_Lumen_ScreenProbeGather_RadianceCache_ProbeResolution=32;
        public int r_Lumen_ScreenProbeGather_RadianceCache_NumProbesToTraceBudget=100;
        public int r_Lumen_ScreenProbeGather_RadianceCache_ProbeAtlasResolutionInProbes = 256;

        public int r_Lumen_RadianceCache_NumFramesToKeepCachedProbes = 15;
  
        public int r_LumenScene_GlobalSDF_Resolution = 252;

        public int r_Lumen_TranslucencyVolume_Enable=1;
        public int r_Lumen_TranslucencyVolume_TraceFromVolume=1;
        public int r_Lumen_TranslucencyVolume_TracingOctahedronResolution=3;
        public int r_Lumen_TranslucencyVolume_GridPixelSize = 64;

        public int r_LumenScene_SurfaceCache_FarField_Distance = 40000;
        public int r_LumenScene_SurfaceCache_CardMinResolution=4;

        public int r_LumenScene_Radiosity_ProbeSpacing = 4;

        public GlobalIlluminationQualitySettings()
        {

        }
        public void appendLines(StringBuilder sb)
        {

            sb.AppendLine($"r.DynamicGlobalIlluminationMethod.Override={r_DynamicGlobalIlluminationMethod_Override}");
            sb.AppendLine($"r.Lumen.DiffuseIndirect.Allow={r_Lumen_DiffuseIndirect_Allow}");
            sb.AppendLine($"r.Lumen.TraceMeshSDFs.Allow={r_Lumen_TraceMeshSDFs_Allow}");
            sb.AppendLine($"r.Lumen.TraceMeshSDFs.TraceDistance={r_Lumen_TraceMeshSDFs_TraceDistance}");
            sb.AppendLine($"r.LumenScene.Radiosity={r_LumenScene_Radiosity}");
            sb.AppendLine($"r.LumenScene.DirectLighting.OffscreenShadowing.TraceMeshSDFs={r_LumenScene_DirectLighting_OffscreenShadowing_TraceMeshSDFs}");
            sb.AppendLine($"r.LumenScene.SurfaceCache.MeshCardsMinSize={r_LumenScene_SurfaceCache_MeshCardsMinSize}");
            sb.AppendLine($"r.LumenScene.SurfaceCache.AtlasSiz={r_LumenScene_SurfaceCache_AtlasSize}");
            sb.AppendLine($"r.Lumen.SurfaceCache.CardCaptureRefreshFractio={r_LumenScene_SurfaceCache_CardCaptureRefreshFraction}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.DownsampleFactor={r_Lumen_ScreenProbeGather_DownsampleFactor}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.TracingOctahedronResolution={r_Lumen_ScreenProbeGather_TracingOctahedronResolution}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.ScreenSpaceBentNormal={r_Lumen_ScreenProbeGather_ScreenSpaceBentNormal}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.StochasticInterpolation={r_Lumen_ScreenProbeGather_StochasticInterpolation}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.FullResolutionJitterWidt={r_Lumen_ScreenProbeGather_FullResolutionJitterWidth}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.TwoSidedFoliageBackfaceDiffuse={r_Lumen_ScreenProbeGather_TwoSidedFoliageBackfaceDiffuse}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.RadianceCache.GridResolutio={r_Lumen_ScreenProbeGather_RadianceCache_GridResolution}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.RadianceCache.ProbeResolutio={r_Lumen_ScreenProbeGather_RadianceCache_ProbeResolution}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.RadianceCache.NumProbesToTraceBudget={r_Lumen_ScreenProbeGather_RadianceCache_NumProbesToTraceBudget}");
            sb.AppendLine($"r.Lumen.ScreenProbeGather.RadianceCache.ProbeAtlasResolutionInProbes={r_Lumen_ScreenProbeGather_RadianceCache_ProbeAtlasResolutionInProbes}");
            sb.AppendLine($"r.Lumen.RadianceCache.NumFramesToKeepCachedProbes={r_Lumen_RadianceCache_NumFramesToKeepCachedProbes}");
            sb.AppendLine($"r.LumenScene.GlobalSDF.Resolution={r_LumenScene_GlobalSDF_Resolution}");
            sb.AppendLine($"r.Lumen.TranslucencyVolumeEnable={r_Lumen_TranslucencyVolume_Enable}");
            sb.AppendLine($"r.Lumen.TranslucencyVolume.TraceFromVolume={r_Lumen_TranslucencyVolume_TraceFromVolume}");
            sb.AppendLine($"r.Lumen.TranslucencyVolume.TracingOctahedronResolution={r_Lumen_TranslucencyVolume_TracingOctahedronResolution}");
            sb.AppendLine($"r.Lumen.TranslucencyVolume.GridPixelSize={r_Lumen_TranslucencyVolume_GridPixelSize}");
            sb.AppendLine($"r.LumenScene.SurfaceCache.FarField.Distance={r_LumenScene_SurfaceCache_FarField_Distance}");
            sb.AppendLine($"r.LumenScene.SurfaceCache.CardMinResolution={r_LumenScene_SurfaceCache_CardMinResolution}");
            sb.AppendLine($"r.LumenScene.Radiosity.ProbeSpacing={r_LumenScene_Radiosity_ProbeSpacing}");

    }

    }
}
