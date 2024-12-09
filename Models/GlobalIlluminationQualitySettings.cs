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
        [IniPropertyAttribute("r.DynamicGlobalIlluminationMethod.Override")]
        public int r_DynamicGlobalIlluminationMethod_Override = 1;
        [IniPropertyAttribute("r.Lumen.DiffuseIndirect.Allow")]
        public int r_Lumen_DiffuseIndirect_Allow = 1;
        [IniPropertyAttribute("r.Lumen.TraceMeshSDFs.Allow")]
        public int r_Lumen_TraceMeshSDFs_Allow=1;
        [IniPropertyAttribute("r.Lumen.TraceMeshSDFs.TraceDistance")]
        public int r_Lumen_TraceMeshSDFs_TraceDistance = 90;
        [IniPropertyAttribute("r.LumenScene.Radiosity")]
        public int r_LumenScene_Radiosity = 1;
        [IniPropertyAttribute("r.LumenScene.DirectLighting.OffscreenShadowing.TraceMeshSDFs")]
        public int r_LumenScene_DirectLighting_OffscreenShadowing_TraceMeshSDFs = 0;
        [IniPropertyAttribute("r.LumenScene.SurfaceCache.MeshCardsMinSize")]
        public int r_LumenScene_SurfaceCache_MeshCardsMinSize=50;
        [IniPropertyAttribute("r.LumenScene.SurfaceCache.AtlasSize")]
        public int r_LumenScene_SurfaceCache_AtlasSize=2048;
        [IniPropertyAttribute("r.LumenScene.SurfaceCache.CardCaptureRefreshFraction")]
        public int r_LumenScene_SurfaceCache_CardCaptureRefreshFraction = 0;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.DownsampleFactor")]
        public int r_Lumen_ScreenProbeGather_DownsampleFactor=32;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.TracingOctahedronResolution")]
        public int r_Lumen_ScreenProbeGather_TracingOctahedronResolution=8;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.ScreenSpaceBentNormal")]
        public int r_Lumen_ScreenProbeGather_ScreenSpaceBentNormal=0;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.StochasticInterpolation")]
        public int r_Lumen_ScreenProbeGather_StochasticInterpolation=0;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.FullResolutionJitterWidth")]
        public int r_Lumen_ScreenProbeGather_FullResolutionJitterWidth=2;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.TwoSidedFoliageBackfaceDiffuse")]
        public int r_Lumen_ScreenProbeGather_TwoSidedFoliageBackfaceDiffuse = 1;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.RadianceCache.GridResolution")]
        public int r_Lumen_ScreenProbeGather_RadianceCache_GridResolution=48;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.RadianceCache.ProbeResolution")]
        public int r_Lumen_ScreenProbeGather_RadianceCache_ProbeResolution=32;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.RadianceCache.NumProbesToTraceBudget")]
        public int r_Lumen_ScreenProbeGather_RadianceCache_NumProbesToTraceBudget=100;
        [IniPropertyAttribute("r.Lumen.ScreenProbeGather.RadianceCache.ProbeAtlasResolutionInProbes")]
        public int r_Lumen_ScreenProbeGather_RadianceCache_ProbeAtlasResolutionInProbes = 256;
        [IniPropertyAttribute("r.Lumen.RadianceCache.NumFramesToKeepCachedProbes")]
        public int r_Lumen_RadianceCache_NumFramesToKeepCachedProbes = 15;
        [IniPropertyAttribute("r.LumenScene.GlobalSDF.Resolution")]
        public int r_LumenScene_GlobalSDF_Resolution = 252;
        [IniPropertyAttribute("r.Lumen.TranslucencyVolume.Enable")]
        public int r_Lumen_TranslucencyVolume_Enable=1;
        [IniPropertyAttribute("r.Lumen.TranslucencyVolume.TraceFromVolume")]
        public int r_Lumen_TranslucencyVolume_TraceFromVolume=1;
        [IniPropertyAttribute("r.Lumen.TranslucencyVolume.TracingOctahedronResolution")]
        public int r_Lumen_TranslucencyVolume_TracingOctahedronResolution=3;
        [IniPropertyAttribute("r.Lumen.TranslucencyVolume.GridPixelSize")]
        public int r_Lumen_TranslucencyVolume_GridPixelSize = 64;
        [IniPropertyAttribute("r.LumenScene.SurfaceCache.FarField.Distance")]
        public int r_LumenScene_SurfaceCache_FarField_Distance = 40000;
        [IniPropertyAttribute("r.LumenScene.SurfaceCache.CardMinResolution")]
        public int r_LumenScene_SurfaceCache_CardMinResolution=4;
        [IniPropertyAttribute("r.LumenScene.Radiosity.ProbeSpacing")]
        public int r_LumenScene_Radiosity_ProbeSpacing = 4;

        public GlobalIlluminationQualitySettings()
        {
        }
    }
}
