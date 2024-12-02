﻿using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S2SettingsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string RENDER_SETTINGS_HEADER = "[/Script/Engine.RendererSettings]";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextureSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Debug.WriteLine("Texture MIP " + e.NewValue);
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            btnGenerate.IsEnabled = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(RENDER_SETTINGS_HEADER);
            sb.AppendLine();
            sb.AppendLine(";--Textures--");
            TextureQualitySettings textures = new TextureQualitySettings()
            {
                r_Streaming_MipBias = 0,
                r_MipMapLODBias = (float)sldrTextures.Value,

                r_MaxAnisotropy = cmbAnisotropic.SelectedIndex switch
                {
                    0 => 1,
                    1 => 2,
                    2 => 4,
                    3 => 8,
                    4 => 16,
                    _ => 8
                },
                r_VT_MaxAnisotropy = cmbAnisotropic.SelectedIndex switch
                {
                    0 => 1,
                    1 => 2,
                    2 => 4,
                    3 => 8,
                    4 => 16,
                    _ => 8
                },

                r_Streaming_UseFixedPoolSize = 1,
                r_Streaming_AmortizeCPUToGPUCopy = (bool)chkAmortizeCPUToGPUCopy.IsChecked ? 1 : 0,
                r_Streaming_MaxNumTexturesToStreamPerFrame = cmbStreamLimitPerFrame.SelectedIndex switch
                {
                    0 => 0,
                    1 => 10,
                    2 => 5,
                    3 => 3,
                    4 => 1,
                    _ => 0,
                },
                r_Streaming_Boost = cmbMipPreference.SelectedIndex switch
                {
                    0 => -2,
                    1 => 1,
                    2 => 2,
                    _ => 1,
                },
                r_Streaming_DropMips = 0,
                r_Streaming_MaxEffectiveScreenSize = 0,
                r_Streaming_LimitPoolSizeToVRAM = 1,

                r_Streaming_PoolSize = cmbStreamingPool.SelectedIndex switch
                {
                    0 => 256,
                    1 => 512,
                    2 => 1024,
                    3 => 2048,
                    4 => 3072,
                    _ => 3072
                },
                r_VT_PoolSizeScale_Group0 = 2,
                r_VT_PoolSizeScale_Group1 = 0.2f,
                r_VT_PoolSizeScale_Group2 = 0.05f,

                r_VT_MaxUploadsPerFrame = cmbTextureCopySpeed.SelectedIndex switch
                {
                    0 => 16,
                    1 => 32,
                    2 => 64,
                    3 => 128,
                    _ => 128
                },
                r_VT_MaxTilesProducedPerFrame = cmbTextureGenerationSpeed.SelectedIndex switch
                {
                    0 => 16,
                    1 => 32,
                    2 => 64,
                    3 => 128,
                    _ => 128
                }
            };
            textures.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Hair--");
            HairQualitySettings hair = new HairQualitySettings()
            {
                r_HairStrands_SkyAO = (bool)chkHairAO.IsChecked ? 1 : 0,
                r_HairStrands_SkyAO_SampleCount = (int)sldrHairAOSamples.Value,
                r_HairStrands_Visibility_MSAA_SamplePerPixel = (int)sldrHairStrandVisibility.Value,
                r_HairStrands_Interpolation_UseSingleGuide = 0,
                r_HairStrands_Voxelization = (bool)chkHairLightingAndShadows.IsChecked ? 0 : 1,
                mg_HairQuality = (int)sldrHairQuality.Value
            };
            hair.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Objects--");
            ObjectDetailQualitySettings objectDetail = new ObjectDetailQualitySettings()
            {
                r_Nanite_ViewMeshLODBias_Offset = (float)sldrPreferredObjectDetail.Value,
                r_Nanite_ViewMeshLODBias_Min = (float)sldrRequiredObjectDetail.Value,
                r_SkeletalMeshLODBias = 0,
                r_DetailMode = cmbOverallDetail.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                mg_CharacterQuality = cmbOverallDetail.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 3
                },
                mg_MaxActorWithSimulation = cmbOverallDetail.SelectedIndex switch
                {
                    0 => 10,
                    1 => 10,
                    2 => 15,
                    3 => 15,
                    _ => 15
                },
                mg_MaxAttaches = cmbMaxAttaches.SelectedIndex switch
                {
                    0 => 5,
                    1 => 10,
                    2 => 20,
                    3 => -1,
                    _ => -1
                }
            };
            objectDetail.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Effects--");
            EffectsQualitySettings effects = new EffectsQualitySettings()
            {
                r_RefractionQuality = cmbRefractionQuality.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                r_EmitterSpawnRateScale = (float)sldrEmitterSpawnRate.Value,
                r_ParticleLightQuality = cmbParticleLighting.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                fx_Niagara_QualityLevel = cmbParticleQuality.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 3,
                },
                fx_Niagara_MaxAdvanceTicks = (int)sldrParticleSimulation.Value,
                r_Refraction_Blur_TemporalAA = (bool)chkParticleRefractionAA.IsChecked ? 1 : 0
            };
            effects.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Materials--");
            MaterialQualitySettings materials = new MaterialQualitySettings()
            {
                  r_MaterialQualityLevel = cmbMaterialQuality.SelectedIndex switch
                  {
                      0 => 0,
                      1 => 1,
                      2 => 2,
                      3 => 3,
                      _ => 3
                  },
                  r_AnisotropicMaterials = (bool)chkMaterialAniso.IsChecked ? 1 : 0
            };
            materials.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--PostProcessing--");
            PostProcessQualitySettings postProcessing = new PostProcessQualitySettings()
            {
                r_RenderTargetPoolMin = (int)sldrPPRenderTargetPool.Value,
                r_LensFlareQuality = cmbLensFlareQuality.SelectedIndex switch {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                r_SceneColorFringeQuality = (bool)chkFringeQual.IsChecked ? 1 : 0,
                r_EyeAdaptationQuality = (bool)chkEyeAdapatation.IsChecked ? 2 : 0,
                r_BloomQuality = cmbBloomQuality.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    5 => 5,
                    _ => 5
                },
                r_FastBlurThreshold = cmbBlurOptmization.SelectedIndex switch
                {
                    0 => 0,
                    1 => 3,
                    2 => 7,
                    3 => 100,
                    _ => 100
                },
                r_Upscale_Quality = cmbUpscaleQuality.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    5 => 5,
                    _ => 3
                },
                r_Tonemapper_GrainQuantization = (bool)chkGrainQuant.IsChecked ? 1 : 0,
                r_LightShaftQuality = (bool)chkLightShafts.IsChecked ? 1 : 0,
                r_LightShaftDownSampleFactor = cmbLightShaftQuality.SelectedIndex switch
                {
                    0 => 8,
                    1 => 4,
                    2 => 2,
                    3 => 1,
                    _ => 2,
                },
                r_Filter_SizeScale = cmbPPFilteringQuality.SelectedIndex switch
                {
                    0 => 0.6f,
                    1 => 0.8f,
                    2 => 1f,
                    _ => 1f
                },
                r_Tonemapper_Quality = cmbToneMapper.SelectedIndex switch
                {
                    0 => 0,
                    1 => 2,
                    2 => 4,
                    3 => 5,
                    _ => 5
                }
            };
            postProcessing.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--DOF--");
            DOFQualitySettings dof = new DOFQualitySettings()
            {
               r_DepthOfFieldQuality = cmbDOFQuality.SelectedIndex switch
               {
                   0 => 0,
                   1 => 1,
                   2 => 2,
                   3 => 3,
                   _ => 3
               },
                r_DOF_Gather_AccumulatorQuality = cmbDOFQuality.SelectedIndex switch
                {
                    0 => 0,
                    1 => 0,
                    2 => 0,
                    3 => 1,
                    _ => 1
                },
               r_DOF_Gather_PostfilterMethod = cmbDOFFiltering.SelectedIndex switch
               {
                   0 => 0,
                   1 => 1,
                   2 => 2,
                   _ => 1
               },
               r_DOF_Gather_EnableBokehSettings = (bool)chkDOFBokeh.IsChecked ? 1 : 0,
               r_DOF_Gather_RingCount = cmbGatherRings.SelectedIndex switch
               {
                   0 => 3,
                   1 => 4,
                   2 => 5,
                   _ => 4
               },
               r_DOF_Scatter_ForegroundCompositing = (bool)chkForegroundComposoting.IsChecked ? 1 : 0,
               r_DOF_Scatter_BackgroundCompositing = cmbBackgroundComposoting.SelectedIndex switch
               {
                   0 => 0,
                   1 => 1,
                   2 => 2,
                   _ => 2
               },
               r_DOF_Scatter_EnableBokehSettings = (bool)chkScatterBokeh.IsChecked ? 1 : 0,
               r_DOF_Scatter_MaxSpriteRatio = (float)slderMaxSpriteRatio.Value,
               r_DOF_Recombine_Quality = cmbRecombineQuality.SelectedIndex switch
               {
                   0 => 0,
                   1 => 1,
                   2 => 2,
                   _ => 1
               },
               r_DOF_Recombine_EnableBokehSettings = (bool)chkScatterBokeh.IsChecked ? 1 : 0,
               r_DOF_TemporalAAQuality = (bool)chkFastDOFAA.IsChecked ? 0 : 1, //inverted is correct
               r_DOF_Kernel_MaxForegroundRadius = (float)sldrDOFForegroundBlurLimit.Value,
               r_DOF_Kernel_MaxBackgroundRadius = (float)sldrDOBackgroundBlurLimit.Value
            };
            dof.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--AA--");
            AntiAliasingQualitySettings aa = new AntiAliasingQualitySettings()
            {
                r_FXAA_Quality = cmbFXAA.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    5 => 5,
                    _ => 4
                },
                r_TemporalAA_Quality = cmbTemporalAA.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                r_TSR_RejectionAntiAliasingQuality = cmbTSRAA.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 1
                },
                r_TSR_History_GrandReprojection = 0
            };
            aa.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Shading--");
            ShadingQualitySettings shading = new ShadingQualitySettings()
            {
                r_SceneColorFormat = cmbSceneFormat.SelectedIndex switch
                {
                    0 => 3,
                    1 => 4,
                    _ => 4
                },
                r_TranslucentLightingVolume = (bool)chkTranslucentLighting.IsChecked ? 1 : 0,
                r_TranslucencyLightingVolumeDim = cmbTranslucentLightingDim.SelectedIndex switch
                {
                    0 => 32,
                    1 => 64,
                    2 => 128,
                    _ => 64
                },
                r_TranslucencyVolumeBlur = (bool)chkBlurTranslucent.IsChecked ? 1 : 0,
                r_SubsurfaceScatteringPass = (bool)chkSubsurfaceScattering.IsChecked ? 1 : 0,
                r_SSS_Scale = (bool)chkSSSubsurfaceScattering.IsChecked ? 1.0f : 0f,
                r_SSS_SampleSet = cmbSSSSamples.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                r_SSS_Quality = (bool)chkHQSSS.IsChecked ? -1 : 0,
                r_SSS_HalfRes = (bool)chkLQSSS.IsChecked ? 1 : 0,
                r_AmbientOcclusionMipLevelFactor = cmbAOFactor.SelectedIndex switch
                {
                    0 => 0,
                    1 => 0.5f,
                    2 => 1,
                    _ => 10,
                },
                r_AmbientOcclusionMaxQuality = (bool)chkAlwaysRequestMaxAOQ.IsChecked ? 100 : (int)sldrAOQuality.Value,
                r_AmbientOcclusionLevels = cmbAOQuality.SelectedIndex switch
                {
                    0 => -1,
                    1 => 0,
                    2 => 1,
                    3 => 2,
                    4 => 3,
                    _ => -1
                },
                r_AmbientOcclusionRadiusScale = (float)sldrAORadius.Value,
                r_TranslucencyLightingVolume_UseShadowFiltering = (bool)chkTranslucentShadowFilter.IsChecked ? 1 : 0
            };
            shading.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Shadows--");
            ShadowQualitySettings shadows = new ShadowQualitySettings()
            {
               r_LightFunctionQuality = 1,

               r_ShadowQuality = cmbShadowQuality.SelectedIndex switch
               {
                   0 => 0,
                   1 => 1,
                   2 => 2,
                   3 => 3,
                   4 => 4,
                   5 => 5,
                   _ => 5
               },

               r_Shadow_CSM_MaxCascades = (int)sldrShadowCascades.Value,
               r_Shadow_MaxCSMResolution = cmbShadowResolution.SelectedIndex switch
               {
                   0 => 128,
                   1 => 256,
                   2 => 512,
                   3 => 1024,
                   4 => 2048,
                   5 => 4096,
                   _ => 2048,
               },

               r_Shadow_RadiusThreshold = (float)sldrShadowRadiusThresh.Value,
               r_Shadow_DistanceScale = (float)sldrShadowDist.Value,
               r_Shadow_CSM_TransitionScale = cmbShadowTransitionScale.SelectedIndex switch
               {
                   0 => 0f,
                   1 => 1f,
                   2 => 2f,
                   _ => 1f
               },
               r_Shadow_PreShadowResolutionFactor = (float)sldrPreshadowRes.Value,

               r_DistanceFieldShadowing = (bool)chkDistanceFieldShadowing.IsChecked ? 1 : 0,
               r_DFShadowQuality = (float)sldrDistanceFieldShadowQuality.Value,

               r_Shadow_Virtual_MaxPhysicalPages = cmbShadowPageSize.SelectedIndex switch
               {
                   0 => 512,
                   1 => 1024,
                   2 => 2048,
                   3 => 4096,
                   _ => 4096
               },
               r_Shadow_Virtual_Clipmap_FirstLevel = (int)sldrFirstClipmapLevel.Value,
               r_Shadow_Virtual_ResolutionLodBiasDirectional = cmbDirectionalLightQualityPreference.SelectedIndex switch
               {
                   0 => 1.0f,
                   1 => 0f,
                   2 => -0.5f,
                   3 => -1f,
                   4 => -2f,
                   _ => -0.5f
               },
               r_Shadow_Virtual_ViewBias_Directional = (int)sldrViewBiasDirectional.Value,
               r_Shadow_Virtual_OptimalSlopeBiasMultiplier_Directional = 0,
               r_Shadow_Virtual_SMRT_TexelDitherScaleDirectional = cmbShadowRaytraceQuality.SelectedIndex switch
               {
                   0 => 1,
                   1 => 1,
                   2 => 2,
                   3 => 2,
                   4 => 2,
                   _ => 2,
               },
                r_Shadow_Virtual_SMRT_RayCountDirectional = cmbShadowRaytraceQuality.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    _ => 4,
                },
                r_Shadow_Virtual_SMRT_SamplesPerRayDirectional = cmbShadowRaytraceQuality.SelectedIndex switch
                {
                    0 => 1,
                    1 => 1,
                    2 => 1,
                    3 => 1,
                    4 => 2,
                    _ => 2,
                },
                r_Shadow_Virtual_SMRT_RayLengthScaleDirectional = cmbShadowRaytraceQuality.SelectedIndex switch
                {
                    0 => 0.25f,
                    1 => 0.5f,
                    2 => 0.5f,
                    3 => 1f,
                    4 => 1f,
                    _ => 1f,
                },

                r_Shadow_Virtual_ResolutionLodBiasLocal = (float)sldrShadowMeshDetail.Value,
               r_Shadow_Virtual_SMRT_RayCountLocal = cmbShadowRaytraceQuality.SelectedIndex switch
               {
                   0 => 1,
                   1 => 1,
                   2 => 2,
                   3 => 2,
                   4 => 2,
                   _ => 2,
               },
                r_Shadow_Virtual_SMRT_SamplesPerRayLocal = cmbShadowRaytraceQuality.SelectedIndex switch
                {
                    0 => 1,
                    1 => 1,
                    2 => 1,
                    3 => 2,
                    4 => 4,
                    _ => 4,
                },
                r_Shadow_Virtual_SMRT_MaxRayAngleFromLight = cmbShadowRaytraceQuality.SelectedIndex switch
                {
                    0 => 0.00025f,
                    1 => 0.0005f,
                    2 => 0.001f,
                    3 => 0.0025f,
                    4 => 0.0025f,
                    _ => 0.0025f,
                },
               r_ContactShadows = (bool)chkContactShadows.IsChecked ? 1 : 0,
               r_ContactShadows_EnableForLocalLights = (bool)chkContactShadowsLocal.IsChecked ? 1 : 0,

                r_SkeletalMesh_ShadowProxy_Use = (bool)chkShadowSkeletelProxy.IsChecked ? 1 : 0,

                r_Shadow_Virtual_Cache_StaticSeparate = (bool)chkShadowStaticSeperate.IsChecked ? 1 : 0,

            };
            shadows.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Clouds--");
            VolumetricCloudsQualitySettings clouds = new VolumetricCloudsQualitySettings()
            {
                r_VolumetricCloud_SkyAO = (bool)chkCloudAO.IsChecked ? 1 : 0,
                r_VolumetricCloud_SkyAO_MaxResolution = cmbCloudAORes.SelectedIndex switch
                {
                    0 => 32,
                    1 => 64,
                    2 => 128,
                    3 => 256,
                    _ => 128
                },
                r_VolumetricCloud_ViewRaySampleMaxCount = (int)sldrCloudViewRayCount.Value,
                r_VolumetricCloud_DistanceToSampleMaxCount = 80,
                r_VolumetricCloud_ReflectionRaySampleMaxCount = (int)sldrCloudReflectionRayCount.Value,
                r_VolumetricCloud_Shadow_ViewRaySampleMaxCount = (int)sldrCloudShadowRayCount.Value
            };
            clouds.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Fog--");
            VolumetricFogQualitySettings fog = new VolumetricFogQualitySettings()
            {
                r_VolumetricFog = (bool)chkVolumetricFog.IsChecked ? 1 : 0,
                r_VolumetricFog_GridPixelSize = cmbFogRes.SelectedIndex switch
                {
                    0 => 64,
                    1 => 32,
                    2 => 16,
                    3 => 8,
                    4 => 4,
                    _ => 8,
                },
                r_VolumetricFog_GridSizeZ = cmbFogRes.SelectedIndex switch
                {
                    0 => 32,
                    1 => 64,
                    2 => 64,
                    3 => 128,
                    4 => 256,
                    _ => 128,
                },
                r_VolumetricFog_HistoryMissSupersampleCount = (int)sldrFogSampleCount.Value,
                r_VolumetricFog_ShadowWorldBias = cmbFogRes.SelectedIndex switch
                {
                    0 => 110,
                    1 => 110,
                    2 => 110,
                    3 => 75,
                    4 => 50,
                    _ => 75,
                },
                r_VolumetricFog_ShadowViewBias = cmbFogRes.SelectedIndex switch
                {
                    0 => 0.75f,
                    1 => 0.75f,
                    2 => 0.75f,
                    3 => 0.35f,
                    4 => 0.25f,
                    _ => 0.35f,
                },
            };
            fog.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Sky--");
            SkyQualitySettings sky = new SkyQualitySettings()
            {
                r_SkyAtmosphere_AerialPerspectiveLUT_FastApplyOnOpaque = 1,
                r_SkyAtmosphere_AerialPerspectiveLUT_SampleCountMaxPerSlice = (int)sldrSkySampleMax.Value,
                r_SkyAtmosphere_AerialPerspectiveLUT_DepthResolution = cmbSkyDepthLevel.SelectedIndex switch
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
                r_SkyAtmosphere_FastSkyLUT_SampleCountMax = (float)sldrSkyColorSamples.Value,
                r_SkyAtmosphere_SampleCountMin = 4.0f,
                r_SkyAtmosphere_SampleCountMax = (float)sldrSkyAtmosphereSamples.Value,
                r_SkyAtmosphere_TransmittanceLUT_UseSmallFormat = (bool)chkHigherFormatLUT.IsChecked ? 0 : 1, //inverse is correct
                r_SkyAtmosphere_TransmittanceLUT_SampleCount = (float)sldrSkyTransmittanceSamples.Value,
                r_SkyAtmosphere_MultiScatteringLUT_SampleCount = (float)sldrSkyScatteringSamples.Value,
                r_SkyLight_RealTimeReflectionCapture = (bool)chkSkyReflection.IsChecked ? 1 : 0,
                r_SkyLight_RealTimeReflectionCapture_TimeSlice_SkyCloudCubeFacePerFrame = cmbSkyReflectionRes.SelectedIndex switch
                {
                    0 => 2,
                    1 => 3,
                    2 => 6,
                    3 => 8,
                    _ => 6
                },
            };
            sky.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Foliage--");
            FoliageQualitySettings foliage = new FoliageQualitySettings()
            {
                foliage_MinimumScreenSize = cmbFoliagePopin.SelectedIndex switch
                {
                    0 => 0.005f,
                    1 => 0.0005f,
                    2 => 0.000005f,
                    3 => 0.0000025f,
                    _ => 0.000005f
                },
                foliage_LODDistanceScale = (float)sldrFoliageLOD.Value,
                fg_CullDistanceScale_Grass = (float)sldrFoliageGrassDist.Value,
                fg_CullDistanceScale_Trees = (float)sldrFoliageTreeDist.Value,
                fg_DensityScale_Grass = (float)sldrFoliageGrassDensity.Value
            };
            foliage.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--ViewDistance--");
            ViewDistanceQualitySettings viewDistance = new ViewDistanceQualitySettings()
            {
                r_SkeletalMeshLODBias = 0,
                r_ViewDistanceScale = (float)sldrViewDistance.Value,
                gsc_ForceCompositionStreamingDistance = -1,
                wp_Runtime_HLOD = 1,
                r_LightMaxDrawDistanceScale = (float)sldrLightViewDistance.Value
            };
            viewDistance.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--GlobalIllumination--");
            GlobalIlluminationQualitySettings globalIllumination = new GlobalIlluminationQualitySettings()
            {
                r_DynamicGlobalIlluminationMethod_Override = 1,
                r_Lumen_DiffuseIndirect_Allow = (bool)chkIndirectDiffuse.IsChecked ? 1 : 0,
                r_Lumen_TraceMeshSDFs_Allow = (bool)chkDetailedMeshTracing.IsChecked ? 1 : 0,
                r_Lumen_TraceMeshSDFs_TraceDistance = (int)sldrDetailedMeshTracingDist.Value,

                r_LumenScene_Radiosity = (bool)chkRadiosity.IsChecked ? 1 : 0,

                r_LumenScene_DirectLighting_OffscreenShadowing_TraceMeshSDFs = (bool)chkOffscreenTraceMeshes.IsChecked ? 1 : 0,

                r_LumenScene_SurfaceCache_MeshCardsMinSize = (int)sldrLumenMeshCardSize.Value,
                r_LumenScene_SurfaceCache_AtlasSize = cmbLumenAtlasSize.SelectedIndex switch
                {
                    0 => 256,
                    1 => 512,
                    2 => 1024,
                    3 => 2048,
                    4 => 4096,
                    _ => 2048
                },
                r_LumenScene_SurfaceCache_CardCaptureRefreshFraction = 0,

                r_Lumen_ScreenProbeGather_DownsampleFactor = cmbProbeDownsample.SelectedIndex switch
                {
                    0 => 96,
                    1 => 48,
                    2 => 32,
                    3 => 16,
                    4 => 8,
                    _ => 32
                },
                r_Lumen_ScreenProbeGather_TracingOctahedronResolution = cmbLumenTraceOctaRes.SelectedIndex switch
                {
                    0 => 4,
                    1 => 8,
                    2 => 16,
                    _ => 8
                },
                r_Lumen_ScreenProbeGather_ScreenSpaceBentNormal = 0,
                r_Lumen_ScreenProbeGather_StochasticInterpolation = (bool)chkStochasticInterpolation.IsChecked ? 1 : 0,
                r_Lumen_ScreenProbeGather_FullResolutionJitterWidth = 2,
                r_Lumen_ScreenProbeGather_TwoSidedFoliageBackfaceDiffuse = (bool)chkTwoSidedFoliageBackfaceDiffuse.IsChecked ? 1 : 0,
                r_Lumen_ScreenProbeGather_RadianceCache_GridResolution = 48,
                r_Lumen_ScreenProbeGather_RadianceCache_ProbeResolution = cmbProbeRes.SelectedIndex switch
                {
                   0 => 16,
                   1 => 32,
                   2 => 64,
                    _ => 32
                },
                r_Lumen_ScreenProbeGather_RadianceCache_NumProbesToTraceBudget = cmbProbeTraceBudget.SelectedIndex switch
                {
                    0 => 10,
                    1 => 25,
                    2 => 50,
                    3 => 75,
                    4 => 100,
                    5 => 200,
                    _ => 100,
                },
                r_Lumen_ScreenProbeGather_RadianceCache_ProbeAtlasResolutionInProbes = cmbProbeAtlasResolution.SelectedIndex switch
                {
                    0 => 64,
                    1 => 128,
                    2 => 256,
                    3 => 512,
                    _ => 256
                },

                r_Lumen_RadianceCache_NumFramesToKeepCachedProbes = cmbProbeCacheFrameKeep.SelectedIndex switch
                {
                    0 => 4,
                    1 => 15,
                    2 => 30,
                    _ => 15
                },

                r_LumenScene_GlobalSDF_Resolution = 252, // all the same

                r_Lumen_TranslucencyVolume_Enable = (bool)chkLumenTranslucencyVolume.IsChecked ? 1 : 0,
                r_Lumen_TranslucencyVolume_TraceFromVolume = (bool)chkLumenTranslucencyTrace.IsChecked ? 1 : 0,
                r_Lumen_TranslucencyVolume_TracingOctahedronResolution = 2,
                r_Lumen_TranslucencyVolume_GridPixelSize = 64,

                r_LumenScene_SurfaceCache_FarField_Distance = (int)sldrLumenFarFieldDistance.Value,
                r_LumenScene_SurfaceCache_CardMinResolution = 4,

                r_LumenScene_Radiosity_ProbeSpacing = (bool)chkTigherProbes.IsChecked ? 4 : 8
            };
            globalIllumination.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--GlobalIllumination--");
            ReflectionQualitySettings reflection = new ReflectionQualitySettings()
            {
                r_ReflectionMethod_Override = 1,
                r_SSR_Quality = cmbSSR.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    4 => 4,
                    _ => 3
                },
                r_SSR_HalfResSceneColor = (bool)chkHalfResScene.IsChecked ? 1 : 0,
                r_Lumen_Reflections_Allow = (bool)chkLumenReflections.IsChecked ? 1 : 0,
                r_Lumen_Reflections_TraceMeshSDFs = (bool)chkTraceMeshReflections.IsChecked ? 1 : 0,
                r_Lumen_Reflections_DownsampleFactor = cmbReflectionDownSample.SelectedIndex switch
                {
                    0 => 0,
                    1 => 8,
                    2 => 4,
                    3 => 2,
                    4 => 1,
                    _ => 3
                },
                r_Lumen_Reflections_MaxRoughnessToTrace = (float)sldrMaxRoughness.Value,
                r_Lumen_Reflections_BilateralFilter_SpatialKernelRadius = 0.001f,
                r_Lumen_Reflections_BilateralFilter_NumSamples = cmbReflectionFilterSampleCount.SelectedIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                r_Lumen_Reflections_SkipEmissive_Opaque = (bool)chkReflectionSkipEmissiveOpaque.IsChecked ? 1 : 0,
                r_Lumen_Reflections_SkipEmissive_SLW = 1,
                r_Lumen_Reflections_SkipEmissive_FrontLayer = (bool)chkReflectionSkipEmissiveFront.IsChecked ? 1 : 0,
                r_Lumen_TranslucencyReflections_FrontLayer_Allow = (bool)chkReflectionLumenTransparency.IsChecked ? 1 : 0,
                r_Lumen_TranslucencyReflections_FrontLayer_Enable = (bool)chkReflectionLumenTransparency.IsChecked ? 1 : 0,
                r_Lumen_Reflections_SampleSceneColorAtHit = (bool)chkReflectionSceneColor.IsChecked ? 1 : 0
            };
            reflection.appendLines(sb);

            string iniLines = sb.ToString();
            Debug.Write(iniLines);

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Engine"; // Default file name
            dlg.DefaultExt = ".ini"; // Default file extension
            dlg.Filter = "Configuration settings (.ini)|*.ini"; // Filter files by extension

            var gamePath = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Stalker2"), "Saved"), "Config");
            var steamPath = System.IO.Path.Combine(gamePath, "Windows");
            var gamePassPath = System.IO.Path.Combine(gamePath, "WinGDK");

            var useSteam = Directory.Exists(steamPath);
            var useGamePass = Directory.Exists(gamePassPath);
            dlg.DefaultDirectory = (useGamePass ? gamePassPath : (useSteam ? steamPath : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                File.WriteAllText(dlg.FileName, iniLines);
            }

            btnGenerate.IsEnabled = true;
        }

        private void ApplyPreset(Presets preset)
        {
            //Textures
            switch (preset)
            {
                case Presets.POTATO:
                    sldrTextures.Value = 2.0;
                    cmbAnisotropic.SelectedIndex = 0;
                    chkAmortizeCPUToGPUCopy.IsChecked = true;
                    cmbStreamLimitPerFrame.SelectedIndex = 4;
                    cmbMipPreference.SelectedIndex = 0;
                    cmbStreamingPool.SelectedIndex = 0;
                    cmbTextureCopySpeed.SelectedIndex = 0;
                    cmbTextureGenerationSpeed.SelectedIndex = 0;
                    break;
                case Presets.VERY_LOW:
                    sldrTextures.Value = 1.75;
                    cmbAnisotropic.SelectedIndex = 0;
                    chkAmortizeCPUToGPUCopy.IsChecked = true;
                    cmbStreamLimitPerFrame.SelectedIndex = 3;
                    cmbMipPreference.SelectedIndex = 1;
                    cmbStreamingPool.SelectedIndex = 0;
                    cmbTextureCopySpeed.SelectedIndex = 0;
                    cmbTextureGenerationSpeed.SelectedIndex = 0;
                    break;
                case Presets.LOW:
                    sldrTextures.Value = 1.5;
                    cmbAnisotropic.SelectedIndex = 0;
                    chkAmortizeCPUToGPUCopy.IsChecked = true;
                    cmbStreamLimitPerFrame.SelectedIndex = 2;
                    cmbMipPreference.SelectedIndex = 1;
                    cmbStreamingPool.SelectedIndex = 1;
                    cmbTextureCopySpeed.SelectedIndex = 1;
                    cmbTextureGenerationSpeed.SelectedIndex = 1;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    sldrTextures.Value = 0;
                    cmbAnisotropic.SelectedIndex = 3;
                    chkAmortizeCPUToGPUCopy.IsChecked = false;
                    cmbStreamLimitPerFrame.SelectedIndex = 0;
                    cmbMipPreference.SelectedIndex = 1;
                    cmbStreamingPool.SelectedIndex = 4;
                    cmbTextureCopySpeed.SelectedIndex = 3;
                    cmbTextureGenerationSpeed.SelectedIndex = 3;
                    break;
                case Presets.ULTRA:
                    sldrTextures.Value = 0;
                    cmbAnisotropic.SelectedIndex = 3;
                    chkAmortizeCPUToGPUCopy.IsChecked = false;
                    cmbStreamLimitPerFrame.SelectedIndex = 0;
                    cmbMipPreference.SelectedIndex = 2;
                    cmbStreamingPool.SelectedIndex = 4;
                    cmbTextureCopySpeed.SelectedIndex = 3;
                    cmbTextureGenerationSpeed.SelectedIndex = 3;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //Hair
            switch (preset)
            {
                case Presets.POTATO:
                    chkHairAO.IsChecked = false;
                    sldrHairAOSamples.Value = 0;
                    sldrHairStrandVisibility.Value = 1;
                    chkHairLightingAndShadows.IsChecked = false;
                    sldrHairQuality.Value = 0;
                    break;
                case Presets.VERY_LOW:
                    chkHairAO.IsChecked = false;
                    sldrHairAOSamples.Value = 0;
                    sldrHairStrandVisibility.Value = 1;
                    chkHairLightingAndShadows.IsChecked = false;
                    sldrHairQuality.Value = 0;
                    break;
                case Presets.LOW:
                    chkHairAO.IsChecked = false;
                    sldrHairAOSamples.Value = 0;
                    sldrHairStrandVisibility.Value = 1;
                    chkHairLightingAndShadows.IsChecked = false;
                    sldrHairQuality.Value = 0;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    chkHairAO.IsChecked = true;
                    sldrHairAOSamples.Value = 4;
                    sldrHairStrandVisibility.Value = 4;
                    chkHairLightingAndShadows.IsChecked = true;
                    sldrHairQuality.Value = 3;
                    break;
                case Presets.ULTRA:
                    chkHairAO.IsChecked = true;
                    sldrHairAOSamples.Value = 5;
                    sldrHairStrandVisibility.Value = 5;
                    chkHairLightingAndShadows.IsChecked = true;
                    sldrHairQuality.Value = 3;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //object detail
            switch (preset)
            {
                case Presets.POTATO:
                    sldrPreferredObjectDetail.Value = 0.8434;
                    sldrRequiredObjectDetail.Value = -0.2736; ;
                    cmbOverallDetail.SelectedIndex = 0;
                    cmbMaxAttaches.SelectedIndex = 0;
                    break;
                case Presets.VERY_LOW:
                    sldrPreferredObjectDetail.Value = 0.6434;
                    sldrRequiredObjectDetail.Value = -0.3736; ;
                    cmbOverallDetail.SelectedIndex = 0;
                    cmbMaxAttaches.SelectedIndex = 0;
                    break;
                case Presets.LOW:
                    sldrPreferredObjectDetail.Value = 0.5849;
                    sldrRequiredObjectDetail.Value = -0.4151; ;
                    cmbOverallDetail.SelectedIndex = 0;
                    cmbMaxAttaches.SelectedIndex = 1;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    sldrPreferredObjectDetail.Value = 0;
                    sldrRequiredObjectDetail.Value = -2;
                    cmbOverallDetail.SelectedIndex = 2;
                    cmbMaxAttaches.SelectedIndex = 3;
                    break;
                case Presets.ULTRA:
                    sldrPreferredObjectDetail.Value = 0;
                    sldrRequiredObjectDetail.Value = -2;
                    cmbOverallDetail.SelectedIndex = 3;
                    cmbMaxAttaches.SelectedIndex = 3;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //effects
            switch (preset)
            {
                case Presets.POTATO:
                    cmbRefractionQuality.SelectedIndex = 0;
                    sldrEmitterSpawnRate.Value = 0.1125;
                    cmbParticleLighting.SelectedIndex = 0;
                    cmbParticleQuality.SelectedIndex = 0;
                    sldrParticleSimulation.Value = 0;
                    chkParticleRefractionAA.IsChecked = false;
                    break;
                case Presets.VERY_LOW:
                    cmbRefractionQuality.SelectedIndex = 0;
                    sldrEmitterSpawnRate.Value = 0.1125;
                    cmbParticleLighting.SelectedIndex = 0;
                    cmbParticleQuality.SelectedIndex = 0;
                    sldrParticleSimulation.Value = 1;
                    chkParticleRefractionAA.IsChecked = false;
                    break;
                case Presets.LOW:
                    cmbRefractionQuality.SelectedIndex = 1;
                    sldrEmitterSpawnRate.Value = 0.125;
                    cmbParticleLighting.SelectedIndex = 0;
                    cmbParticleQuality.SelectedIndex = 0;
                    sldrParticleSimulation.Value = 2;
                    chkParticleRefractionAA.IsChecked = true;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbRefractionQuality.SelectedIndex = 2;
                    sldrEmitterSpawnRate.Value = 1.0;
                    cmbParticleLighting.SelectedIndex = 2;
                    cmbParticleQuality.SelectedIndex = 3;
                    sldrParticleSimulation.Value = 20;
                    chkParticleRefractionAA.IsChecked = true;
                    break;
                case Presets.ULTRA:
                    cmbRefractionQuality.SelectedIndex = 3;
                    sldrEmitterSpawnRate.Value = 1.0;
                    cmbParticleLighting.SelectedIndex = 2;
                    cmbParticleQuality.SelectedIndex = 3;
                    sldrParticleSimulation.Value = 20;
                    chkParticleRefractionAA.IsChecked = true;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //materials
            switch (preset)
            {
                case Presets.POTATO:
                    cmbMaterialQuality.SelectedIndex = 0;
                    chkMaterialAniso.IsChecked = false;
                    break;
                case Presets.VERY_LOW:
                    cmbMaterialQuality.SelectedIndex = 0;
                    chkMaterialAniso.IsChecked = false;
                    break;
                case Presets.LOW:
                    cmbMaterialQuality.SelectedIndex = 0;
                    chkMaterialAniso.IsChecked = false;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbMaterialQuality.SelectedIndex = 3;
                    chkMaterialAniso.IsChecked = true;
                    break;
                case Presets.ULTRA:
                    cmbMaterialQuality.SelectedIndex = 3;
                    chkMaterialAniso.IsChecked = true;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //post processing
            switch (preset)
            {
                case Presets.POTATO:
                    sldrPPRenderTargetPool.Value = 200;
                    cmbLensFlareQuality.SelectedIndex = 0;
                    chkFringeQual.IsChecked = false;
                    chkEyeAdapatation.IsChecked = true;
                    cmbBloomQuality.SelectedIndex = 0;
                    cmbBlurOptmization.SelectedIndex = 0;
                    cmbUpscaleQuality.SelectedIndex = 0;
                    chkGrainQuant.IsChecked = false;
                    chkLightShafts.IsChecked = false;
                    cmbLightShaftQuality.SelectedIndex = 0;
                    cmbPPFilteringQuality.SelectedIndex = 0;
                    cmbToneMapper.SelectedIndex = 0;
                    break;
                case Presets.VERY_LOW:
                    sldrPPRenderTargetPool.Value = 270;
                    cmbLensFlareQuality.SelectedIndex = 0;
                    chkFringeQual.IsChecked = false;
                    chkEyeAdapatation.IsChecked = true;
                    cmbBloomQuality.SelectedIndex = 1;
                    cmbBlurOptmization.SelectedIndex = 0;
                    cmbUpscaleQuality.SelectedIndex = 1;
                    chkGrainQuant.IsChecked = false;
                    chkLightShafts.IsChecked = false;
                    cmbLightShaftQuality.SelectedIndex = 0;
                    cmbPPFilteringQuality.SelectedIndex = 0;
                    cmbToneMapper.SelectedIndex = 0;
                    break;
                case Presets.LOW:
                    sldrPPRenderTargetPool.Value = 300;
                    cmbLensFlareQuality.SelectedIndex = 0;
                    chkFringeQual.IsChecked = false;
                    chkEyeAdapatation.IsChecked = true;
                    cmbBloomQuality.SelectedIndex = 4;
                    cmbBlurOptmization.SelectedIndex = 0;
                    cmbUpscaleQuality.SelectedIndex = 1;
                    chkGrainQuant.IsChecked = false;
                    chkLightShafts.IsChecked = true;
                    cmbLightShaftQuality.SelectedIndex = 1;
                    cmbPPFilteringQuality.SelectedIndex = 0;
                    cmbToneMapper.SelectedIndex = 0;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    sldrPPRenderTargetPool.Value = 400;
                    cmbLensFlareQuality.SelectedIndex = 2;
                    chkFringeQual.IsChecked = true;
                    chkEyeAdapatation.IsChecked = true;
                    cmbBloomQuality.SelectedIndex = 5;
                    cmbBlurOptmization.SelectedIndex = 3;
                    cmbUpscaleQuality.SelectedIndex = 3;
                    chkGrainQuant.IsChecked = true;
                    chkLightShafts.IsChecked = true;
                    cmbLightShaftQuality.SelectedIndex = 2;
                    cmbPPFilteringQuality.SelectedIndex = 2;
                    cmbToneMapper.SelectedIndex = 3;
                    break;
                case Presets.ULTRA:
                    sldrPPRenderTargetPool.Value = 500;
                    cmbLensFlareQuality.SelectedIndex = 2;
                    chkFringeQual.IsChecked = true;
                    chkEyeAdapatation.IsChecked = true;
                    cmbBloomQuality.SelectedIndex = 5;
                    cmbBlurOptmization.SelectedIndex = 3;
                    cmbUpscaleQuality.SelectedIndex = 4;
                    chkGrainQuant.IsChecked = true;
                    chkLightShafts.IsChecked = true;
                    cmbLightShaftQuality.SelectedIndex = 3;
                    cmbPPFilteringQuality.SelectedIndex = 2;
                    cmbToneMapper.SelectedIndex = 3;
                    break;
                case Presets.INSANE:
                    sldrPPRenderTargetPool.Value = 600;
                    cmbUpscaleQuality.SelectedIndex = 5;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //dof
            switch (preset)
            {
                case Presets.POTATO:
                    cmbDOFQuality.SelectedIndex = 0;
                    cmbDOFFiltering.SelectedIndex = 0;
                    chkDOFBokeh.IsChecked = false;
                    cmbGatherRings.SelectedIndex = 0;
                    chkForegroundComposoting.IsChecked = false;
                    cmbBackgroundComposoting.SelectedIndex = 0;
                    chkScatterBokeh.IsChecked = false;
                    slderMaxSpriteRatio.Value = 0.036;
                    cmbRecombineQuality.SelectedIndex = 0;
                    chkFastDOFAA.IsChecked = true;
                    sldrDOFForegroundBlurLimit.Value = 0.0;
                    sldrDOBackgroundBlurLimit.Value = 0.0;
                    break;
                case Presets.VERY_LOW:
                    cmbDOFQuality.SelectedIndex = 0;
                    cmbDOFFiltering.SelectedIndex = 1;
                    chkDOFBokeh.IsChecked = false;
                    cmbGatherRings.SelectedIndex = 0;
                    chkForegroundComposoting.IsChecked = false;
                    cmbBackgroundComposoting.SelectedIndex = 0;
                    chkScatterBokeh.IsChecked = false;
                    slderMaxSpriteRatio.Value = 0.036;
                    cmbRecombineQuality.SelectedIndex = 0;
                    chkFastDOFAA.IsChecked = true;
                    sldrDOFForegroundBlurLimit.Value = 0.0054;
                    sldrDOBackgroundBlurLimit.Value = 0.0054;
                    break;
                case Presets.LOW:
                    cmbDOFQuality.SelectedIndex = 0;
                    cmbDOFFiltering.SelectedIndex = 2;
                    chkDOFBokeh.IsChecked = false;
                    cmbGatherRings.SelectedIndex = 0;
                    chkForegroundComposoting.IsChecked = false;
                    cmbBackgroundComposoting.SelectedIndex = 0;
                    chkScatterBokeh.IsChecked = false;
                    slderMaxSpriteRatio.Value = 0.04;
                    cmbRecombineQuality.SelectedIndex = 0;
                    chkFastDOFAA.IsChecked = true;
                    sldrDOFForegroundBlurLimit.Value = 0.006;
                    sldrDOBackgroundBlurLimit.Value = 0.006;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbDOFQuality.SelectedIndex = 3;
                    cmbDOFFiltering.SelectedIndex = 1;
                    chkDOFBokeh.IsChecked = false;
                    cmbGatherRings.SelectedIndex = 1;
                    chkForegroundComposoting.IsChecked = false;
                    cmbBackgroundComposoting.SelectedIndex = 2;
                    chkScatterBokeh.IsChecked = false;
                    slderMaxSpriteRatio.Value = 0.1;
                    cmbRecombineQuality.SelectedIndex = 1;
                    chkFastDOFAA.IsChecked = false;
                    sldrDOFForegroundBlurLimit.Value = 0.025;
                    sldrDOBackgroundBlurLimit.Value = 0.025;
                    break;
                case Presets.ULTRA:
                    cmbDOFQuality.SelectedIndex = 3;
                    cmbDOFFiltering.SelectedIndex = 1;
                    chkDOFBokeh.IsChecked = true;
                    cmbGatherRings.SelectedIndex = 2;
                    chkForegroundComposoting.IsChecked = true;
                    cmbBackgroundComposoting.SelectedIndex = 1;
                    chkScatterBokeh.IsChecked = true;
                    slderMaxSpriteRatio.Value = 0.05;
                    cmbRecombineQuality.SelectedIndex = 2;
                    chkFastDOFAA.IsChecked = false;
                    sldrDOFForegroundBlurLimit.Value = 0.05;
                    sldrDOBackgroundBlurLimit.Value = 0.05;
                    break;
                case Presets.INSANE:
                    cmbBackgroundComposoting.SelectedIndex = 2;
                    slderMaxSpriteRatio.Value = 0.025;
                    sldrDOFForegroundBlurLimit.Value = 0.1;
                    sldrDOBackgroundBlurLimit.Value = 0.1;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //aa
            switch (preset)
            {
                case Presets.POTATO:
                    cmbFXAA.SelectedIndex = 0;
                    cmbTemporalAA.SelectedIndex = 0;
                    cmbTSRAA.SelectedIndex = 0;
                    break;
                case Presets.VERY_LOW:
                    cmbFXAA.SelectedIndex = 0;
                    cmbTemporalAA.SelectedIndex = 0;
                    cmbTSRAA.SelectedIndex = 0;
                    break;
                case Presets.LOW:
                    cmbFXAA.SelectedIndex = 0;
                    cmbTemporalAA.SelectedIndex = 0;
                    cmbTSRAA.SelectedIndex = 0;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbFXAA.SelectedIndex = 4;
                    cmbTemporalAA.SelectedIndex = 2;
                    cmbTSRAA.SelectedIndex = 1;
                    break;
                case Presets.ULTRA:
                    cmbFXAA.SelectedIndex = 5;
                    cmbTemporalAA.SelectedIndex = 3;
                    cmbTSRAA.SelectedIndex = 2;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //shading
            switch (preset)
            {
                case Presets.POTATO:
                    cmbSceneFormat.SelectedIndex = 0;
                    chkTranslucentLighting.IsChecked = true;
                    cmbTranslucentLightingDim.SelectedIndex = 0;
                    chkBlurTranslucent.IsChecked = false;
                    chkSubsurfaceScattering.IsChecked = false;
                    chkSSSubsurfaceScattering.IsChecked = false;
                    cmbSSSSamples.SelectedIndex = 0;
                    chkHQSSS.IsChecked = false;
                    chkLQSSS.IsChecked = true;
                    cmbAOFactor.SelectedIndex = 0;
                    chkAlwaysRequestMaxAOQ.IsChecked = false;
                    sldrAOQuality.Value = 60;
                    cmbAOQuality.SelectedIndex = 0;
                    sldrAORadius.Value = 0.75;
                    chkTranslucentShadowFilter.IsChecked = false;
                    break;
                case Presets.VERY_LOW:
                    cmbSceneFormat.SelectedIndex = 0;
                    chkTranslucentLighting.IsChecked = true;
                    cmbTranslucentLightingDim.SelectedIndex = 1;
                    chkBlurTranslucent.IsChecked = false;
                    chkSubsurfaceScattering.IsChecked = false;
                    chkSSSubsurfaceScattering.IsChecked = false;
                    cmbSSSSamples.SelectedIndex = 0;
                    chkHQSSS.IsChecked = false;
                    chkLQSSS.IsChecked = true;
                    cmbAOFactor.SelectedIndex = 0;
                    chkAlwaysRequestMaxAOQ.IsChecked = false;
                    sldrAOQuality.Value = 81;
                    cmbAOQuality.SelectedIndex = 1;
                    sldrAORadius.Value = 1;
                    chkTranslucentShadowFilter.IsChecked = false;
                    break;
                case Presets.LOW:
                    cmbSceneFormat.SelectedIndex = 0;
                    chkTranslucentLighting.IsChecked = true;
                    cmbTranslucentLightingDim.SelectedIndex = 1;
                    chkBlurTranslucent.IsChecked = false;
                    chkSubsurfaceScattering.IsChecked = false;
                    chkSSSubsurfaceScattering.IsChecked = false;
                    cmbSSSSamples.SelectedIndex = 0;
                    chkHQSSS.IsChecked = false;
                    chkLQSSS.IsChecked = true;
                    cmbAOFactor.SelectedIndex = 0;
                    chkAlwaysRequestMaxAOQ.IsChecked = false;
                    sldrAOQuality.Value = 90;
                    cmbAOQuality.SelectedIndex = 1;
                    sldrAORadius.Value = 1;
                    chkTranslucentShadowFilter.IsChecked = false;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbSceneFormat.SelectedIndex = 1;
                    chkTranslucentLighting.IsChecked = true;
                    cmbTranslucentLightingDim.SelectedIndex = 1;
                    chkBlurTranslucent.IsChecked = true;
                    chkSubsurfaceScattering.IsChecked = true;
                    chkSSSubsurfaceScattering.IsChecked = true;
                    cmbSSSSamples.SelectedIndex = 0;
                    chkHQSSS.IsChecked = true;
                    chkLQSSS.IsChecked = false;
                    cmbAOFactor.SelectedIndex = 2;
                    chkAlwaysRequestMaxAOQ.IsChecked = false;
                    sldrAOQuality.Value = 100;
                    cmbAOQuality.SelectedIndex = 0;
                    sldrAORadius.Value = 1;
                    chkTranslucentShadowFilter.IsChecked = true;
                    break;
                case Presets.ULTRA:
                    cmbSceneFormat.SelectedIndex = 1;
                    chkTranslucentLighting.IsChecked = true;
                    cmbTranslucentLightingDim.SelectedIndex = 2;
                    chkBlurTranslucent.IsChecked = true;
                    chkSubsurfaceScattering.IsChecked = true;
                    chkSSSubsurfaceScattering.IsChecked = true;
                    cmbSSSSamples.SelectedIndex = 1;
                    chkHQSSS.IsChecked = true;
                    chkLQSSS.IsChecked = false;
                    cmbAOFactor.SelectedIndex = 0;
                    chkAlwaysRequestMaxAOQ.IsChecked = false;
                    sldrAOQuality.Value = 100;
                    cmbAOQuality.SelectedIndex = 3;
                    sldrAORadius.Value = 1;
                    chkTranslucentShadowFilter.IsChecked = true;
                    break;
                case Presets.INSANE:
                    cmbSSSSamples.SelectedIndex = 2;
                    chkAlwaysRequestMaxAOQ.IsChecked = true;
                    cmbAOQuality.SelectedIndex = 4;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //shadows
            switch (preset)
            {
                case Presets.POTATO:
                    cmbShadowQuality.SelectedIndex = 1;
                    sldrShadowCascades.Value = 2;
                    cmbShadowResolution.SelectedIndex = 1;
                    sldrShadowRadiusThresh.Value = 0.08;
                    sldrShadowDist.Value = 0.665;
                    cmbShadowTransitionScale.SelectedIndex = 0;
                    sldrPreshadowRes.Value = 0.35;
                    chkDistanceFieldShadowing.IsChecked = false;
                    sldrDistanceFieldShadowQuality.Value = 0;
                    cmbShadowPageSize.SelectedIndex = 1;
                    sldrFirstClipmapLevel.Value = 6;
                    cmbDirectionalLightQualityPreference.SelectedIndex = 0;
                    sldrViewBiasDirectional.Value = 5;
                    cmbShadowRaytraceQuality.SelectedIndex = 1;
                    chkContactShadows.IsChecked = false;
                    chkContactShadowsLocal.IsChecked = false;
                    chkShadowSkeletelProxy.IsChecked = true;
                    chkShadowStaticSeperate.IsChecked = true;
                    break;
                case Presets.VERY_LOW:
                    cmbShadowQuality.SelectedIndex = 2;
                    sldrShadowCascades.Value = 2;
                    cmbShadowResolution.SelectedIndex = 2;
                    sldrShadowRadiusThresh.Value = 0.07;
                    sldrShadowDist.Value = 0.765;
                    cmbShadowTransitionScale.SelectedIndex = 0;
                    sldrPreshadowRes.Value = 0.45;
                    chkDistanceFieldShadowing.IsChecked = false;
                    sldrDistanceFieldShadowQuality.Value = 0;
                    cmbShadowPageSize.SelectedIndex = 1;
                    sldrFirstClipmapLevel.Value = 6;
                    cmbDirectionalLightQualityPreference.SelectedIndex = 0;
                    sldrViewBiasDirectional.Value = 5;
                    cmbShadowRaytraceQuality.SelectedIndex = 1;
                    chkContactShadows.IsChecked = true;
                    chkContactShadowsLocal.IsChecked = false;
                    chkShadowSkeletelProxy.IsChecked = true;
                    chkShadowStaticSeperate.IsChecked = true;
                    break;
                case Presets.LOW:
                    cmbShadowQuality.SelectedIndex = 3;
                    sldrShadowCascades.Value = 2;
                    cmbShadowResolution.SelectedIndex = 3;
                    sldrShadowRadiusThresh.Value = 0.06;
                    sldrShadowDist.Value = 0.85;
                    cmbShadowTransitionScale.SelectedIndex = 0;
                    sldrPreshadowRes.Value = 0.5;
                    chkDistanceFieldShadowing.IsChecked = false;
                    sldrDistanceFieldShadowQuality.Value = 0;
                    cmbShadowPageSize.SelectedIndex = 1;
                    sldrFirstClipmapLevel.Value = 6;
                    cmbDirectionalLightQualityPreference.SelectedIndex = 0;
                    sldrViewBiasDirectional.Value = 5;
                    cmbShadowRaytraceQuality.SelectedIndex = 1;
                    chkContactShadows.IsChecked = true;
                    chkContactShadowsLocal.IsChecked = false;
                    chkShadowSkeletelProxy.IsChecked = true;
                    chkShadowStaticSeperate.IsChecked = true;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbShadowQuality.SelectedIndex = 5;
                    sldrShadowCascades.Value = 10;
                    cmbShadowResolution.SelectedIndex = 4;
                    sldrShadowRadiusThresh.Value = 0.01;
                    sldrShadowDist.Value = 1.0;
                    cmbShadowTransitionScale.SelectedIndex = 1;
                    sldrPreshadowRes.Value = 1.0;
                    chkDistanceFieldShadowing.IsChecked = true;
                    sldrDistanceFieldShadowQuality.Value = 1.0;
                    cmbShadowPageSize.SelectedIndex = 3;
                    sldrFirstClipmapLevel.Value = 6;
                    cmbDirectionalLightQualityPreference.SelectedIndex = 2;
                    sldrViewBiasDirectional.Value = 0;
                    cmbShadowRaytraceQuality.SelectedIndex = 4;
                    chkContactShadows.IsChecked = true;
                    chkContactShadowsLocal.IsChecked = true;
                    chkShadowSkeletelProxy.IsChecked = false;
                    chkShadowStaticSeperate.IsChecked = true;
                    break;
                case Presets.ULTRA:
                    cmbShadowQuality.SelectedIndex = 5;
                    sldrShadowCascades.Value = 12;
                    cmbShadowResolution.SelectedIndex = 4;
                    sldrShadowRadiusThresh.Value = 0.01;
                    sldrShadowDist.Value = 1.0;
                    cmbShadowTransitionScale.SelectedIndex = 2;
                    sldrPreshadowRes.Value = 1.0;
                    chkDistanceFieldShadowing.IsChecked = true;
                    sldrDistanceFieldShadowQuality.Value = 1.0;
                    cmbShadowPageSize.SelectedIndex = 3;
                    sldrFirstClipmapLevel.Value = 6;
                    cmbDirectionalLightQualityPreference.SelectedIndex = 3;
                    sldrViewBiasDirectional.Value = 0;
                    cmbShadowRaytraceQuality.SelectedIndex = 4;
                    chkContactShadows.IsChecked = true;
                    chkContactShadowsLocal.IsChecked = true;
                    chkShadowSkeletelProxy.IsChecked = false;
                    chkShadowStaticSeperate.IsChecked = true;
                    break;
                case Presets.INSANE:
                    sldrShadowCascades.Value = 15;
                    cmbDirectionalLightQualityPreference.SelectedIndex = 4;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //clouds
            switch (preset)
            {
                case Presets.POTATO:
                    chkCloudAO.IsChecked = false;
                    cmbCloudAORes.SelectedIndex = 0;
                    sldrCloudViewRayCount.Value = 126;
                    sldrCloudReflectionRayCount.Value = 14;
                    sldrCloudShadowRayCount.Value = 2;
                    break;
                case Presets.VERY_LOW:
                    chkCloudAO.IsChecked = false;
                    cmbCloudAORes.SelectedIndex = 1;
                    sldrCloudViewRayCount.Value = 176;
                    sldrCloudReflectionRayCount.Value = 18;
                    sldrCloudShadowRayCount.Value = 3;
                    break;
                case Presets.LOW:
                    chkCloudAO.IsChecked = false;
                    cmbCloudAORes.SelectedIndex = 2;
                    sldrCloudViewRayCount.Value = 196;
                    sldrCloudReflectionRayCount.Value = 20;
                    sldrCloudShadowRayCount.Value = 4;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    chkCloudAO.IsChecked = true;
                    cmbCloudAORes.SelectedIndex = 2;
                    sldrCloudViewRayCount.Value = 196;
                    sldrCloudReflectionRayCount.Value = 60;
                    sldrCloudShadowRayCount.Value = 4;
                    break;
                case Presets.ULTRA:
                    chkCloudAO.IsChecked = true;
                    cmbCloudAORes.SelectedIndex = 3;
                    sldrCloudViewRayCount.Value = 300;
                    sldrCloudReflectionRayCount.Value = 80;
                    sldrCloudShadowRayCount.Value = 5;
                    break;
                case Presets.INSANE:
                    sldrCloudViewRayCount.Value = 400;
                    sldrCloudReflectionRayCount.Value = 100;
                    sldrCloudShadowRayCount.Value = 6;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //fog
            switch (preset)
            {
                case Presets.POTATO:
                    chkVolumetricFog.IsChecked = true;
                    cmbFogRes.SelectedIndex = 0;
                    sldrFogSampleCount.Value = 2;
                    break;
                case Presets.VERY_LOW:
                    chkVolumetricFog.IsChecked = true;
                    cmbFogRes.SelectedIndex = 0;
                    sldrFogSampleCount.Value = 3;
                    break;
                case Presets.LOW:
                    chkVolumetricFog.IsChecked = true;
                    cmbFogRes.SelectedIndex = 0;
                    sldrFogSampleCount.Value = 4;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    chkVolumetricFog.IsChecked = true;
                    cmbFogRes.SelectedIndex = 3;
                    sldrFogSampleCount.Value = 4;
                    break;
                case Presets.ULTRA:
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //sky
            switch (preset)
            {
                case Presets.POTATO:
                    sldrSkySampleMax.Value = 1;
                    cmbSkyDepthLevel.SelectedIndex = 0;
                    sldrSkyColorSamples.Value = 10;
                    sldrSkyAtmosphereSamples.Value = 10;
                    chkHigherFormatLUT.IsChecked = false;
                    sldrSkyTransmittanceSamples.Value = 6;
                    sldrSkyScatteringSamples.Value = 7;
                    chkSkyReflection.IsChecked = true;
                    cmbSkyReflectionRes.SelectedIndex = 0;
                    break;
                case Presets.VERY_LOW:
                    sldrSkySampleMax.Value = 1;
                    cmbSkyDepthLevel.SelectedIndex = 1;
                    sldrSkyColorSamples.Value = 14;
                    sldrSkyAtmosphereSamples.Value = 14;
                    chkHigherFormatLUT.IsChecked = false;
                    sldrSkyTransmittanceSamples.Value = 9;
                    sldrSkyScatteringSamples.Value = 13;
                    chkSkyReflection.IsChecked = true;
                    cmbSkyReflectionRes.SelectedIndex = 0;
                    break;
                case Presets.LOW:
                    sldrSkySampleMax.Value = 1;
                    cmbSkyDepthLevel.SelectedIndex = 2;
                    sldrSkyColorSamples.Value = 16;
                    sldrSkyAtmosphereSamples.Value = 16;
                    chkHigherFormatLUT.IsChecked = false;
                    sldrSkyTransmittanceSamples.Value = 10;
                    sldrSkyScatteringSamples.Value = 15;
                    chkSkyReflection.IsChecked = true;
                    cmbSkyReflectionRes.SelectedIndex = 0;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    sldrSkySampleMax.Value = 8;
                    cmbSkyDepthLevel.SelectedIndex = 4;
                    sldrSkyColorSamples.Value = 128;
                    sldrSkyAtmosphereSamples.Value = 128;
                    chkHigherFormatLUT.IsChecked = false;
                    sldrSkyTransmittanceSamples.Value = 10;
                    sldrSkyScatteringSamples.Value = 15;
                    chkSkyReflection.IsChecked = true;
                    cmbSkyReflectionRes.SelectedIndex = 2;
                    break;
                case Presets.ULTRA:
                    sldrSkySampleMax.Value = 12;
                    cmbSkyDepthLevel.SelectedIndex = 5;
                    sldrSkyColorSamples.Value = 192;
                    sldrSkyAtmosphereSamples.Value = 192;
                    chkHigherFormatLUT.IsChecked = true;
                    sldrSkyTransmittanceSamples.Value = 15;
                    sldrSkyScatteringSamples.Value = 20;
                    chkSkyReflection.IsChecked = true;
                    cmbSkyReflectionRes.SelectedIndex = 3;
                    break;
                case Presets.INSANE:
                    sldrSkySampleMax.Value = 16;
                    sldrSkyColorSamples.Value = 256;
                    sldrSkyAtmosphereSamples.Value = 256;
                    sldrSkyTransmittanceSamples.Value = 20;
                    sldrSkyScatteringSamples.Value = 30;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //foliage
            switch (preset)
            {
                case Presets.POTATO:
                    cmbFoliagePopin.SelectedIndex = 0;
                    sldrFoliageLOD.Value = 0.52;
                    sldrFoliageGrassDist.Value = 0.4;
                    sldrFoliageTreeDist.Value = 0.4;
                    sldrFoliageGrassDensity.Value = 0.35;
                    break;
                case Presets.VERY_LOW:
                    cmbFoliagePopin.SelectedIndex = 0;
                    sldrFoliageLOD.Value = 0.72;
                    sldrFoliageGrassDist.Value = 0.54;
                    sldrFoliageTreeDist.Value = 0.54;
                    sldrFoliageGrassDensity.Value = 0.45;
                    break;
                case Presets.LOW:
                    cmbFoliagePopin.SelectedIndex = 0;
                    sldrFoliageLOD.Value = 0.8;
                    sldrFoliageGrassDist.Value = 0.6;
                    sldrFoliageTreeDist.Value = 0.6;
                    sldrFoliageGrassDensity.Value = 0.5;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbFoliagePopin.SelectedIndex = 2;
                    sldrFoliageLOD.Value = 1;
                    sldrFoliageGrassDist.Value = 1;
                    sldrFoliageTreeDist.Value = 1;
                    sldrFoliageGrassDensity.Value = 1;
                    break;
                case Presets.ULTRA:
                    cmbFoliagePopin.SelectedIndex = 3;
                    sldrFoliageLOD.Value = 1;
                    sldrFoliageGrassDist.Value = 1;
                    sldrFoliageTreeDist.Value = 1;
                    sldrFoliageGrassDensity.Value = 1;
                    break;
                case Presets.INSANE:
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //view distance
            switch (preset)
            {
                case Presets.POTATO:
                    sldrViewDistance.Value = 0.75;
                    sldrLightViewDistance.Value = 0.35;
                    break;
                case Presets.VERY_LOW:
                    sldrViewDistance.Value = 0.9;
                    sldrLightViewDistance.Value = 0.45;
                    break;
                case Presets.LOW:
                    sldrViewDistance.Value = 1;
                    sldrLightViewDistance.Value = 0.5;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    sldrViewDistance.Value = 1;
                    sldrLightViewDistance.Value = 1;
                    break;
                case Presets.ULTRA:
                    sldrViewDistance.Value = 1.1;
                    sldrLightViewDistance.Value = 1.1;
                    break;
                case Presets.INSANE:
                    sldrViewDistance.Value = 1.5;
                    sldrLightViewDistance.Value = 1.5;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //global illum
            switch (preset)
            {
                case Presets.POTATO:
                    chkIndirectDiffuse.IsChecked = true;
                    chkDetailedMeshTracing.IsChecked = false;
                    sldrDetailedMeshTracingDist.Value = 0;
                    chkRadiosity.IsChecked = true;
                    chkOffscreenTraceMeshes.IsChecked = false;

                    sldrLumenMeshCardSize.Value = 185;
                    cmbLumenAtlasSize.SelectedIndex = 0;

                    cmbProbeDownsample.SelectedIndex = 0;
                    cmbLumenTraceOctaRes.SelectedIndex = 0;
                    chkStochasticInterpolation.IsChecked = true;
                    chkTwoSidedFoliageBackfaceDiffuse.IsChecked = false;
                    cmbProbeRes.SelectedIndex = 0;
                    cmbProbeTraceBudget.SelectedIndex = 0;
                    cmbProbeAtlasResolution.SelectedIndex = 0;
                    cmbProbeCacheFrameKeep.SelectedIndex = 0;
                    chkLumenTranslucencyVolume.IsChecked = true;
                    chkLumenTranslucencyTrace.IsChecked = true;
                    sldrLumenFarFieldDistance.Value = 10000;
                    chkTigherProbes.IsChecked = false;
                    break;
                case Presets.VERY_LOW:
                    chkIndirectDiffuse.IsChecked = true;
                    chkDetailedMeshTracing.IsChecked = false;
                    sldrDetailedMeshTracingDist.Value = 0;
                    chkRadiosity.IsChecked = true;
                    chkOffscreenTraceMeshes.IsChecked = false;

                    sldrLumenMeshCardSize.Value = 165;
                    cmbLumenAtlasSize.SelectedIndex = 1;

                    cmbProbeDownsample.SelectedIndex = 1;
                    cmbLumenTraceOctaRes.SelectedIndex = 1;
                    chkStochasticInterpolation.IsChecked = true;
                    chkTwoSidedFoliageBackfaceDiffuse.IsChecked = true;
                    cmbProbeRes.SelectedIndex = 0;
                    cmbProbeTraceBudget.SelectedIndex = 0;
                    cmbProbeAtlasResolution.SelectedIndex = 0;
                    cmbProbeCacheFrameKeep.SelectedIndex = 0;
                    chkLumenTranslucencyVolume.IsChecked = true;
                    chkLumenTranslucencyTrace.IsChecked = true;
                    sldrLumenFarFieldDistance.Value = 18000;
                    chkTigherProbes.IsChecked = false;
                    break;
                case Presets.LOW:
                    chkIndirectDiffuse.IsChecked = true;
                    chkDetailedMeshTracing.IsChecked = false;
                    sldrDetailedMeshTracingDist.Value = 0;
                    chkRadiosity.IsChecked = true;
                    chkOffscreenTraceMeshes.IsChecked = false;

                    sldrLumenMeshCardSize.Value = 150;
                    cmbLumenAtlasSize.SelectedIndex = 2;

                    cmbProbeDownsample.SelectedIndex = 1;
                    cmbLumenTraceOctaRes.SelectedIndex = 1;
                    chkStochasticInterpolation.IsChecked = true;
                    chkTwoSidedFoliageBackfaceDiffuse.IsChecked = true;
                    cmbProbeRes.SelectedIndex = 0;
                    cmbProbeTraceBudget.SelectedIndex = 1;
                    cmbProbeAtlasResolution.SelectedIndex = 1;
                    cmbProbeCacheFrameKeep.SelectedIndex = 0;
                    chkLumenTranslucencyVolume.IsChecked = true;
                    chkLumenTranslucencyTrace.IsChecked = true;
                    sldrLumenFarFieldDistance.Value = 20000;
                    chkTigherProbes.IsChecked = false;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    chkIndirectDiffuse.IsChecked = true;
                    chkDetailedMeshTracing.IsChecked = true;
                    sldrDetailedMeshTracingDist.Value = 20;
                    chkRadiosity.IsChecked = true;
                    chkOffscreenTraceMeshes.IsChecked = true;

                    sldrLumenMeshCardSize.Value = 50;
                    cmbLumenAtlasSize.SelectedIndex = 3;

                    cmbProbeDownsample.SelectedIndex = 2;
                    cmbLumenTraceOctaRes.SelectedIndex = 1;
                    chkStochasticInterpolation.IsChecked = true;
                    chkTwoSidedFoliageBackfaceDiffuse.IsChecked = true;
                    cmbProbeRes.SelectedIndex = 1;
                    cmbProbeTraceBudget.SelectedIndex = 4;
                    cmbProbeAtlasResolution.SelectedIndex = 2;
                    cmbProbeCacheFrameKeep.SelectedIndex = 1;
                    chkLumenTranslucencyVolume.IsChecked = true;
                    chkLumenTranslucencyTrace.IsChecked = true;
                    sldrLumenFarFieldDistance.Value = 40000;
                    chkTigherProbes.IsChecked = true;
                    break;
                case Presets.ULTRA:
                    chkIndirectDiffuse.IsChecked = true;
                    chkDetailedMeshTracing.IsChecked = true;
                    sldrDetailedMeshTracingDist.Value = 25;
                    chkRadiosity.IsChecked = true;
                    chkOffscreenTraceMeshes.IsChecked = true;

                    sldrLumenMeshCardSize.Value = 45;
                    cmbLumenAtlasSize.SelectedIndex = 4;

                    cmbProbeDownsample.SelectedIndex = 3;
                    cmbLumenTraceOctaRes.SelectedIndex = 1;
                    chkStochasticInterpolation.IsChecked = true;
                    chkTwoSidedFoliageBackfaceDiffuse.IsChecked = true;
                    cmbProbeRes.SelectedIndex = 1;
                    cmbProbeTraceBudget.SelectedIndex = 5;
                    cmbProbeAtlasResolution.SelectedIndex = 2;
                    cmbProbeCacheFrameKeep.SelectedIndex = 1;
                    chkLumenTranslucencyVolume.IsChecked = true;
                    chkLumenTranslucencyTrace.IsChecked = true;
                    sldrLumenFarFieldDistance.Value = 50000;
                    chkTigherProbes.IsChecked = true;
                    break;
                case Presets.INSANE:
                    sldrDetailedMeshTracingDist.Value = 60;
                    sldrLumenMeshCardSize.Value = 25;
                    cmbProbeDownsample.SelectedIndex = 4;
                    sldrLumenFarFieldDistance.Value = 50000;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }

            //reflections
            switch (preset)
            {
                case Presets.POTATO:
                    cmbSSR.SelectedIndex = 1;
                    chkHalfResScene.IsChecked = true;
                    chkLumenReflections.IsChecked = false;
                    chkTraceMeshReflections.IsChecked = false;
                    cmbReflectionDownSample.SelectedIndex = 1;
                    sldrMaxRoughness.Value = 0.05;
                    cmbReflectionFilterSampleCount.SelectedIndex = 0;
                    chkReflectionSkipEmissiveOpaque.IsChecked = false;
                    chkReflectionSkipEmissiveFront.IsChecked = false;
                    chkReflectionLumenTransparency.IsChecked = false;
                    chkReflectionSceneColor.IsChecked = false;
                    break;
                case Presets.VERY_LOW:
                    cmbSSR.SelectedIndex = 2;
                    chkHalfResScene.IsChecked = true;
                    chkLumenReflections.IsChecked = true;
                    chkTraceMeshReflections.IsChecked = false;
                    cmbReflectionDownSample.SelectedIndex = 2;
                    sldrMaxRoughness.Value = 0.1;
                    cmbReflectionFilterSampleCount.SelectedIndex = 1;
                    chkReflectionSkipEmissiveOpaque.IsChecked = false;
                    chkReflectionSkipEmissiveFront.IsChecked = false;
                    chkReflectionLumenTransparency.IsChecked = false;
                    chkReflectionSceneColor.IsChecked = false;
                    break;
                case Presets.LOW:
                    cmbSSR.SelectedIndex = 3;
                    chkHalfResScene.IsChecked = false;
                    chkLumenReflections.IsChecked = true;
                    chkTraceMeshReflections.IsChecked = false;
                    cmbReflectionDownSample.SelectedIndex = 3;
                    sldrMaxRoughness.Value = 0.2;
                    cmbReflectionFilterSampleCount.SelectedIndex = 2;
                    chkReflectionSkipEmissiveOpaque.IsChecked = false;
                    chkReflectionSkipEmissiveFront.IsChecked = false;
                    chkReflectionLumenTransparency.IsChecked = false;
                    chkReflectionSceneColor.IsChecked = false;
                    break;
                case Presets.MEDIUM:
                    break;
                case Presets.HIGH:
                    break;
                case Presets.EPIC:
                    cmbSSR.SelectedIndex = 3;
                    chkHalfResScene.IsChecked = false;
                    chkLumenReflections.IsChecked = true;
                    chkTraceMeshReflections.IsChecked = true;
                    cmbReflectionDownSample.SelectedIndex = 3;
                    sldrMaxRoughness.Value = 0.3;
                    cmbReflectionFilterSampleCount.SelectedIndex = 2;
                    chkReflectionSkipEmissiveOpaque.IsChecked = true;
                    chkReflectionSkipEmissiveFront.IsChecked = true;
                    chkReflectionLumenTransparency.IsChecked = true;
                    chkReflectionSceneColor.IsChecked = true;
                    break;
                case Presets.ULTRA:
                    cmbSSR.SelectedIndex = 4;
                    chkHalfResScene.IsChecked = false;
                    chkLumenReflections.IsChecked = true;
                    chkTraceMeshReflections.IsChecked = true;
                    cmbReflectionDownSample.SelectedIndex = 4;
                    sldrMaxRoughness.Value = 0.4;
                    cmbReflectionFilterSampleCount.SelectedIndex = 3;
                    chkReflectionSkipEmissiveOpaque.IsChecked = true;
                    chkReflectionSkipEmissiveFront.IsChecked = true;
                    chkReflectionLumenTransparency.IsChecked = true;
                    chkReflectionSceneColor.IsChecked = true;
                    break;
                case Presets.INSANE:
                    sldrMaxRoughness.Value = 0.5;
                    break;
                case Presets.CUSTOM:
                    break;
                default:
                    break;
            }
        }

        private void rdioPotatoPreset_Checked(object sender, RoutedEventArgs e)
        {
            ApplyPreset(Presets.POTATO);
        }

        private void rdioVeryLowPreset_Checked(object sender, RoutedEventArgs e)
        {
            ApplyPreset(Presets.VERY_LOW);
        }

        private void rdioLowPreset_Checked(object sender, RoutedEventArgs e)
        {
            ApplyPreset(Presets.LOW);
        }

        private void rdioEpicPreset_Checked(object sender, RoutedEventArgs e)
        {
            if(sldrTextures == null)
            {
                // not ready yet
                return;
            }


            ApplyPreset(Presets.EPIC);

        }

        private void rdioUltraPreset_Checked(object sender, RoutedEventArgs e)
        {
            ApplyPreset(Presets.ULTRA);
        }
    }
}