using System.Diagnostics;
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
            textures.appendLines(sb);
            sb.AppendLine();
            sb.AppendLine(";--Foliage--");
            FoliageQualitySettings foliage = new FoliageQualitySettings()
            {
                foliage_MinimumScreenSize = cmbFoliagePopin.SelectedIndex switch
                {
                    0 => 0.00002f,
                    1 => 0.00001f,
                    2 => 0.000005f,
                    3 => 0.000001f,
                    _ => 0.000005f
                },
                foliage_LODDistanceScale = (float)sldrFoliageLOD.Value,
                fg_CullDistanceScale_Grass = (float)sldrFoliageGrassDist.Value,
                fg_CullDistanceScale_Trees = (float)sldrFoliageTreeDist.Value,
                fg_DensityScale_Grass = (float)sldrFoliageGrassDensity.Value
            };
            textures.appendLines(sb);
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
            textures.appendLines(sb);
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
                r_Lumen_TranslucencyVolume_TracingOctahedronResolution = 3,
                r_Lumen_TranslucencyVolume_GridPixelSize = 64,

                r_LumenScene_SurfaceCache_FarField_Distance = (int)sldrLumenFarFieldDistance.Value,
                r_LumenScene_SurfaceCache_CardMinResolution = 4,

                r_LumenScene_Radiosity_ProbeSpacing = (bool)chkTigherProbes.IsChecked ? 4 : 8
            };
            textures.appendLines(sb);

            string iniLines = sb.ToString();
            Debug.Write(iniLines);
        }
    }
}