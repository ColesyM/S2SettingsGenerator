using System.ComponentModel;
using System.Diagnostics;
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
using S2SettingsGenerator.ViewModels;

namespace S2SettingsGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string RENDER_SETTINGS_HEADER = "[/Script/Engine.RendererSettings]";


        private MainWindowViewModel viewModel;

        public MainWindowViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this.viewModel = new MainWindowViewModel();
            this.ViewModel.PresetSectionChanged += ViewModel_PresetSectionChanged; 
        }

        private void ViewModel_PresetSectionChanged(object? sender, PresetChangedEventArgs e)
        {
            switch (e.SectionName)
            {
                case "Texture":
                    ApplyTextures(e.Preset);
                    break;
                case "Hair":
                    ApplyHair(e.Preset);
                    break;
                case "ObjectDetail":
                    ApplyObjectDetail(e.Preset);
                    break;
                case "Effects":
                    ApplyEffects(e.Preset);
                    break;
                case "Materials":
                    ApplyMaterials(e.Preset);
                    break;
                case "PostProcessing":
                    ApplyPostProcessing(e.Preset);
                    break;
                case "Dof":
                    ApplyDOF(e.Preset);
                    break;
                case "AA":
                    ApplyAA(e.Preset);
                    break;
                case "MotionBlur":
                    ApplyMotionBlur(e.Preset);
                    break;
                case "Shading":
                    ApplyShading(e.Preset);
                    break;
                case "GlobalIllumination":
                    ApplyGI(e.Preset);
                    break;
                case "Reflections":
                    ApplyReflections(e.Preset);
                    break;
                case "Shadows":
                    ApplyShadows(e.Preset);
                    break;
                case "Clouds":
                    ApplyClouds(e.Preset);
                    break;
                case "Fog":
                    ApplyFog(e.Preset);
                    break;
                case "Sky":
                    ApplySky(e.Preset);
                    break;
                case "Foliage":
                    ApplyFoliage(e.Preset);
                    break;
                case "ViewDistance":
                    ApplyViewDistance(e.Preset);
                    break;
                default:
                    break;
            }
        }

        private void TextureSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Debug.WriteLine("Texture MIP " + e.NewValue);
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            btnGenerate.IsEnabled = false;

            this.viewModel.TextureQualitySettings.PopulateSettingsModel();
            this.viewModel.HairQualitySettings.PopulateSettingsModel();
            this.viewModel.ObjectDetailQualitySettings.PopulateSettingsModel();
            this.viewModel.EffectsQualitySettings.PopulateSettingsModel();
            this.viewModel.MaterialsQualitySettings.PopulateSettingsModel();
            this.viewModel.PostProcessingQualitySettings.PopulateSettingsModel();
            this.viewModel.DOFQualitySettings.PopulateSettingsModel();
            this.viewModel.AAQualitySettings.PopulateSettingsModel();
            this.viewModel.MotionBlurQualitySettings.PopulateSettingsModel();
            this.viewModel.ShadingQualitySettings.PopulateSettingsModel();
            this.viewModel.GlobalIlluminationQualitySettings.PopulateSettingsModel();
            this.viewModel.ReflectionsQualitySettings.PopulateSettingsModel();
            this.viewModel.ShadowsQualitySettings.PopulateSettingsModel();
            this.viewModel.CloudsQualitySettings.PopulateSettingsModel();
            this.viewModel.FogQualitySettings.PopulateSettingsModel();
            this.viewModel.SkyQualitySettings.PopulateSettingsModel();
            this.viewModel.FoliageQualitySettings.PopulateSettingsModel();
            this.viewModel.ViewDistanceQualitySettings.PopulateSettingsModel();


            StringBuilder sb = new StringBuilder();
            sb.AppendLine(RENDER_SETTINGS_HEADER);
            sb.AppendLine();

            this.viewModel.TextureQualitySettings.AddSettingsStrings(sb);
            this.viewModel.HairQualitySettings.AddSettingsStrings(sb);
            this.viewModel.ObjectDetailQualitySettings.AddSettingsStrings(sb);
            this.viewModel.EffectsQualitySettings.AddSettingsStrings(sb);
            this.viewModel.MaterialsQualitySettings.AddSettingsStrings(sb);
            this.viewModel.PostProcessingQualitySettings.AddSettingsStrings(sb);
            this.viewModel.DOFQualitySettings.AddSettingsStrings(sb);
            this.viewModel.AAQualitySettings.AddSettingsStrings(sb);
            this.viewModel.MotionBlurQualitySettings.AddSettingsStrings(sb);
            this.viewModel.ShadingQualitySettings.AddSettingsStrings(sb);
            this.viewModel.GlobalIlluminationQualitySettings.AddSettingsStrings(sb);
            this.viewModel.ReflectionsQualitySettings.AddSettingsStrings(sb);
            this.viewModel.ShadowsQualitySettings.AddSettingsStrings(sb);
            this.viewModel.CloudsQualitySettings.AddSettingsStrings(sb);
            this.viewModel.FogQualitySettings.AddSettingsStrings(sb);
            this.viewModel.SkyQualitySettings.AddSettingsStrings(sb);
            this.viewModel.FoliageQualitySettings.AddSettingsStrings(sb);
            this.viewModel.ViewDistanceQualitySettings.AddSettingsStrings(sb);

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

        private void ApplyTextures(Presets preset, bool apply = false)
        {
            if (this.viewModel.TextureQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.TextureQualitySettings.Preset = preset;
                }

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
                        sldrTextures.Value = 1.0;
                        cmbAnisotropic.SelectedIndex = 1;
                        chkAmortizeCPUToGPUCopy.IsChecked = false;
                        cmbStreamLimitPerFrame.SelectedIndex = 0;
                        cmbMipPreference.SelectedIndex = 1;
                        cmbStreamingPool.SelectedIndex = 2;
                        cmbTextureCopySpeed.SelectedIndex = 2;
                        cmbTextureGenerationSpeed.SelectedIndex = 1;
                        break;
                    case Presets.HIGH:
                        sldrTextures.Value = 0.0;
                        cmbAnisotropic.SelectedIndex = 2;
                        chkAmortizeCPUToGPUCopy.IsChecked = false;
                        cmbStreamLimitPerFrame.SelectedIndex = 0;
                        cmbMipPreference.SelectedIndex = 1;
                        cmbStreamingPool.SelectedIndex = 3;
                        cmbTextureCopySpeed.SelectedIndex = 2;
                        cmbTextureGenerationSpeed.SelectedIndex = 2;
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
                        sldrTextures.Value = 0;
                        cmbAnisotropic.SelectedIndex = 4;
                        chkAmortizeCPUToGPUCopy.IsChecked = false;
                        cmbStreamLimitPerFrame.SelectedIndex = 0;
                        cmbMipPreference.SelectedIndex = 2;
                        cmbStreamingPool.SelectedIndex = 4;
                        cmbTextureCopySpeed.SelectedIndex = 3;
                        cmbTextureGenerationSpeed.SelectedIndex = 3;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }

        private void ApplyHair(Presets preset, bool apply = false)
        {
            if (this.viewModel.HairQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.HairQualitySettings.Preset = preset;
                }

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
                        chkHairAO.IsChecked = false;
                        sldrHairAOSamples.Value = 0;
                        sldrHairStrandVisibility.Value = 2;
                        chkHairLightingAndShadows.IsChecked = false;
                        sldrHairQuality.Value = 1;
                        break;
                    case Presets.HIGH:
                        chkHairAO.IsChecked = false;
                        sldrHairAOSamples.Value = 0;
                        sldrHairStrandVisibility.Value = 4;
                        chkHairLightingAndShadows.IsChecked = true;
                        sldrHairQuality.Value = 2;
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
                        chkHairAO.IsChecked = true;
                        sldrHairAOSamples.Value = 5;
                        sldrHairStrandVisibility.Value = 5;
                        chkHairLightingAndShadows.IsChecked = true;
                        sldrHairQuality.Value = 3;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }

        private void ApplyObjectDetail(Presets preset, bool apply = false)
        {
            if (this.viewModel.ObjectDetailQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.ObjectDetailQualitySettings.Preset = preset;
                }

                switch (preset)
                {
                    case Presets.POTATO:
                        sldrPreferredObjectDetail.Value = 0.8434;
                        sldrRequiredObjectDetail.Value = -0.2736;
                        cmbNanitePixelsPerEdge.SelectedIndex = 0;
                        cmbOverallDetail.SelectedIndex = 0;
                        cmbMaxAttaches.SelectedIndex = 0;
                        break;
                    case Presets.VERY_LOW:
                        sldrPreferredObjectDetail.Value = 0.6434;
                        sldrRequiredObjectDetail.Value = -0.3736;
                        cmbNanitePixelsPerEdge.SelectedIndex = 1;
                        cmbOverallDetail.SelectedIndex = 0;
                        cmbMaxAttaches.SelectedIndex = 0;
                        break;
                    case Presets.LOW:
                        sldrPreferredObjectDetail.Value = 0.5849;
                        sldrRequiredObjectDetail.Value = -0.4151;
                        cmbNanitePixelsPerEdge.SelectedIndex = 3;
                        cmbOverallDetail.SelectedIndex = 0;
                        cmbMaxAttaches.SelectedIndex = 1;
                        break;
                    case Presets.MEDIUM:
                        sldrPreferredObjectDetail.Value = 0.415;
                        sldrRequiredObjectDetail.Value = -0.585;
                        cmbNanitePixelsPerEdge.SelectedIndex = 3;
                        cmbOverallDetail.SelectedIndex = 1;
                        cmbMaxAttaches.SelectedIndex = 2;
                        break;
                    case Presets.HIGH:
                        sldrPreferredObjectDetail.Value = 0.2;
                        sldrRequiredObjectDetail.Value = -0.8;
                        cmbNanitePixelsPerEdge.SelectedIndex = 3;
                        cmbOverallDetail.SelectedIndex = 2;
                        cmbMaxAttaches.SelectedIndex = 3;
                        break;
                    case Presets.EPIC:
                        sldrPreferredObjectDetail.Value = 0;
                        sldrRequiredObjectDetail.Value = -2;
                        cmbNanitePixelsPerEdge.SelectedIndex = 3;
                        cmbOverallDetail.SelectedIndex = 2;
                        cmbMaxAttaches.SelectedIndex = 3;
                        break;
                    case Presets.ULTRA:
                        sldrPreferredObjectDetail.Value = 0;
                        sldrRequiredObjectDetail.Value = -2;
                        cmbNanitePixelsPerEdge.SelectedIndex = 3;
                        cmbOverallDetail.SelectedIndex = 3;
                        cmbMaxAttaches.SelectedIndex = 3;
                        break;
                    case Presets.INSANE:
                        sldrPreferredObjectDetail.Value = 0;
                        sldrRequiredObjectDetail.Value = -2;
                        cmbNanitePixelsPerEdge.SelectedIndex = 3;
                        cmbOverallDetail.SelectedIndex = 3;
                        cmbMaxAttaches.SelectedIndex = 3;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }

        private void ApplyEffects(Presets preset, bool apply = false)
        {
            if (this.viewModel.EffectsQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.EffectsQualitySettings.Preset = preset;
                }

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
                        cmbRefractionQuality.SelectedIndex = 1;
                        sldrEmitterSpawnRate.Value = 0.25;
                        cmbParticleLighting.SelectedIndex = 0;
                        cmbParticleQuality.SelectedIndex = 1;
                        sldrParticleSimulation.Value = 2;
                        chkParticleRefractionAA.IsChecked = true;
                        break;
                    case Presets.HIGH:
                        cmbRefractionQuality.SelectedIndex = 2;
                        sldrEmitterSpawnRate.Value = 0.5;
                        cmbParticleLighting.SelectedIndex = 1;
                        cmbParticleQuality.SelectedIndex = 2;
                        sldrParticleSimulation.Value = 10;
                        chkParticleRefractionAA.IsChecked = true;
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
                        cmbRefractionQuality.SelectedIndex = 3;
                        sldrEmitterSpawnRate.Value = 1.0;
                        cmbParticleLighting.SelectedIndex = 2;
                        cmbParticleQuality.SelectedIndex = 3;
                        sldrParticleSimulation.Value = 20;
                        chkParticleRefractionAA.IsChecked = true;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyMaterials(Presets preset, bool apply = false)
        {
            if (this.viewModel.MaterialsQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.MaterialsQualitySettings.Preset = preset;
                }

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
                        cmbMaterialQuality.SelectedIndex = 0;
                        chkMaterialAniso.IsChecked = false;
                        break;
                    case Presets.HIGH:
                        cmbMaterialQuality.SelectedIndex = 1;
                        chkMaterialAniso.IsChecked = true;
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
                        cmbMaterialQuality.SelectedIndex = 3;
                        chkMaterialAniso.IsChecked = true;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyPostProcessing(Presets preset, bool apply = false)
        {
            if (this.viewModel.PostProcessingQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.PostProcessingQualitySettings.Preset = preset;
                }

                switch (preset)
                {
                    case Presets.POTATO:
                        sldrPPRenderTargetPool.Value = 200;
                        cmbLensFlareQuality.SelectedIndex = 0;
                        chkFringeQual.IsChecked = false;
                        chkEyeAdapatation.IsChecked = true;
                        sldrEyeAdaptationLensAtt.Value = 0.78;
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
                        sldrEyeAdaptationLensAtt.Value = 0.78;
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
                        sldrEyeAdaptationLensAtt.Value = 0.78;
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
                        sldrPPRenderTargetPool.Value = 350;
                        cmbLensFlareQuality.SelectedIndex = 0;
                        chkFringeQual.IsChecked = false;
                        chkEyeAdapatation.IsChecked = true;
                        sldrEyeAdaptationLensAtt.Value = 0.78;
                        cmbBloomQuality.SelectedIndex = 4;
                        cmbBlurOptmization.SelectedIndex = 2;
                        cmbUpscaleQuality.SelectedIndex = 2;
                        chkGrainQuant.IsChecked = false;
                        chkLightShafts.IsChecked = true;
                        cmbLightShaftQuality.SelectedIndex = 1;
                        cmbPPFilteringQuality.SelectedIndex = 1;
                        cmbToneMapper.SelectedIndex = 2;
                        break;
                    case Presets.HIGH:
                        sldrPPRenderTargetPool.Value = 400;
                        cmbLensFlareQuality.SelectedIndex = 2;
                        chkFringeQual.IsChecked = true;
                        chkEyeAdapatation.IsChecked = true;
                        sldrEyeAdaptationLensAtt.Value = 0.78;
                        cmbBloomQuality.SelectedIndex = 5;
                        cmbBlurOptmization.SelectedIndex = 3;
                        cmbUpscaleQuality.SelectedIndex = 2;
                        chkGrainQuant.IsChecked = true;
                        chkLightShafts.IsChecked = true;
                        cmbLightShaftQuality.SelectedIndex = 2;
                        cmbPPFilteringQuality.SelectedIndex = 2;
                        cmbToneMapper.SelectedIndex = 3;
                        break;
                    case Presets.EPIC:
                        sldrPPRenderTargetPool.Value = 400;
                        cmbLensFlareQuality.SelectedIndex = 2;
                        chkFringeQual.IsChecked = true;
                        chkEyeAdapatation.IsChecked = true;
                        sldrEyeAdaptationLensAtt.Value = 0.78;
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
                        sldrEyeAdaptationLensAtt.Value = 0.78;
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
                        cmbLensFlareQuality.SelectedIndex = 2;
                        chkFringeQual.IsChecked = true;
                        chkEyeAdapatation.IsChecked = true;
                        sldrEyeAdaptationLensAtt.Value = 0.78;
                        cmbBloomQuality.SelectedIndex = 5;
                        cmbBlurOptmization.SelectedIndex = 3;
                        cmbUpscaleQuality.SelectedIndex = 5;
                        chkGrainQuant.IsChecked = true;
                        chkLightShafts.IsChecked = true;
                        cmbLightShaftQuality.SelectedIndex = 3;
                        cmbPPFilteringQuality.SelectedIndex = 2;
                        cmbToneMapper.SelectedIndex = 3;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyDOF(Presets preset, bool apply = false)
        {
            if (this.viewModel.DOFQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.DOFQualitySettings.Preset = preset;
                }

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
                        cmbDOFQuality.SelectedIndex = 1;
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
                    case Presets.HIGH:
                        cmbDOFQuality.SelectedIndex = 2;
                        cmbDOFFiltering.SelectedIndex = 2;
                        chkDOFBokeh.IsChecked = false;
                        cmbGatherRings.SelectedIndex = 1;
                        chkForegroundComposoting.IsChecked = true;
                        cmbBackgroundComposoting.SelectedIndex = 1;
                        chkScatterBokeh.IsChecked = false;
                        slderMaxSpriteRatio.Value = 0.04;
                        cmbRecombineQuality.SelectedIndex = 0;
                        chkFastDOFAA.IsChecked = true;
                        sldrDOFForegroundBlurLimit.Value = 0.012;
                        sldrDOBackgroundBlurLimit.Value = 0.012;
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
                        cmbDOFQuality.SelectedIndex = 3;
                        cmbDOFFiltering.SelectedIndex = 1;
                        chkDOFBokeh.IsChecked = true;
                        cmbGatherRings.SelectedIndex = 2;
                        chkForegroundComposoting.IsChecked = true;
                        cmbBackgroundComposoting.SelectedIndex = 2;
                        chkScatterBokeh.IsChecked = true;
                        slderMaxSpriteRatio.Value = 0.025;
                        cmbRecombineQuality.SelectedIndex = 2;
                        chkFastDOFAA.IsChecked = false;
                        sldrDOFForegroundBlurLimit.Value = 0.1;
                        sldrDOBackgroundBlurLimit.Value = 0.1;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyAA(Presets preset, bool apply = false)
        {
            if (this.viewModel.AAQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.AAQualitySettings.Preset = preset;
                }

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
                        cmbFXAA.SelectedIndex = 1;
                        cmbTemporalAA.SelectedIndex = 1;
                        cmbTSRAA.SelectedIndex = 0;
                        break;
                    case Presets.HIGH:
                        cmbFXAA.SelectedIndex = 3;
                        cmbTemporalAA.SelectedIndex = 1;
                        cmbTSRAA.SelectedIndex = 0;
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
                        cmbFXAA.SelectedIndex = 5;
                        cmbTemporalAA.SelectedIndex = 3;
                        cmbTSRAA.SelectedIndex = 2;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyMotionBlur(Presets preset, bool apply = false)
        {
            if (this.viewModel.MotionBlurQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.MotionBlurQualitySettings.Preset = preset;
                }

                switch (preset)
                {
                    case Presets.POTATO:
                        cmbMotionBlurQuality.SelectedIndex = 0;
                        chkFasterMotionBlur.IsChecked = true;
                        break;
                    case Presets.VERY_LOW:
                        cmbMotionBlurQuality.SelectedIndex = 1;
                        chkFasterMotionBlur.IsChecked = true;
                        break;
                    case Presets.LOW:
                        cmbMotionBlurQuality.SelectedIndex = 3;
                        chkFasterMotionBlur.IsChecked = true;
                        break;
                    case Presets.MEDIUM:
                        cmbMotionBlurQuality.SelectedIndex = 3;
                        chkFasterMotionBlur.IsChecked = true;
                        break;
                    case Presets.HIGH:
                        cmbMotionBlurQuality.SelectedIndex = 3;
                        chkFasterMotionBlur.IsChecked = false;
                        break;
                    case Presets.EPIC:
                        cmbMotionBlurQuality.SelectedIndex = 4;
                        chkFasterMotionBlur.IsChecked = false;
                        break;
                    case Presets.ULTRA:
                        cmbMotionBlurQuality.SelectedIndex = 4;
                        chkFasterMotionBlur.IsChecked = false;
                        break;
                    case Presets.INSANE:
                        cmbMotionBlurQuality.SelectedIndex = 4;
                        chkFasterMotionBlur.IsChecked = false;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyShading(Presets preset, bool apply = false)
        {
            if (this.viewModel.ShadingQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.ShadingQualitySettings.Preset = preset;
                }

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
                        cmbSceneFormat.SelectedIndex = 0;
                        chkTranslucentLighting.IsChecked = true;
                        cmbTranslucentLightingDim.SelectedIndex = 1;
                        chkBlurTranslucent.IsChecked = false;
                        chkSubsurfaceScattering.IsChecked = true;
                        chkSSSubsurfaceScattering.IsChecked = true;
                        cmbSSSSamples.SelectedIndex = 0;
                        chkHQSSS.IsChecked = false;
                        chkLQSSS.IsChecked = true;
                        cmbAOFactor.SelectedIndex = 0;
                        chkAlwaysRequestMaxAOQ.IsChecked = false;
                        sldrAOQuality.Value = 100;
                        cmbAOQuality.SelectedIndex = 1;
                        sldrAORadius.Value = 1;
                        chkTranslucentShadowFilter.IsChecked = true;
                        break;
                    case Presets.HIGH:
                        cmbSceneFormat.SelectedIndex = 0;
                        chkTranslucentLighting.IsChecked = true;
                        cmbTranslucentLightingDim.SelectedIndex = 1;
                        chkBlurTranslucent.IsChecked = true;
                        chkSubsurfaceScattering.IsChecked = true;
                        chkSSSubsurfaceScattering.IsChecked = true;
                        cmbSSSSamples.SelectedIndex = 0;
                        chkHQSSS.IsChecked = true;
                        chkLQSSS.IsChecked = true;
                        cmbAOFactor.SelectedIndex = 1;
                        chkAlwaysRequestMaxAOQ.IsChecked = false;
                        sldrAOQuality.Value = 100;
                        cmbAOQuality.SelectedIndex = 2;
                        sldrAORadius.Value = 1;
                        chkTranslucentShadowFilter.IsChecked = true;
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
                        cmbSceneFormat.SelectedIndex = 1;
                        chkTranslucentLighting.IsChecked = true;
                        cmbTranslucentLightingDim.SelectedIndex = 2;
                        chkBlurTranslucent.IsChecked = true;
                        chkSubsurfaceScattering.IsChecked = true;
                        chkSSSubsurfaceScattering.IsChecked = true;
                        cmbSSSSamples.SelectedIndex = 2;
                        chkHQSSS.IsChecked = true;
                        chkLQSSS.IsChecked = false;
                        cmbAOFactor.SelectedIndex = 0;
                        chkAlwaysRequestMaxAOQ.IsChecked = true;
                        sldrAOQuality.Value = 100;
                        cmbAOQuality.SelectedIndex = 4;
                        sldrAORadius.Value = 1;
                        chkTranslucentShadowFilter.IsChecked = true;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyGI(Presets preset, bool apply = false)
        {
            if (this.viewModel.GlobalIlluminationQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.GlobalIlluminationQualitySettings.Preset = preset;
                }

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
                        sldrLumenFarFieldDistance.Value = 10000;
                        chkTigherProbes.IsChecked = false;
                        break;
                    case Presets.MEDIUM:
                        chkIndirectDiffuse.IsChecked = true;
                        chkDetailedMeshTracing.IsChecked = false;
                        sldrDetailedMeshTracingDist.Value = 0;
                        chkRadiosity.IsChecked = true;
                        chkOffscreenTraceMeshes.IsChecked = false;

                        sldrLumenMeshCardSize.Value = 150;
                        cmbLumenAtlasSize.SelectedIndex = 2;

                        cmbProbeDownsample.SelectedIndex = 2;
                        cmbLumenTraceOctaRes.SelectedIndex = 1;
                        chkStochasticInterpolation.IsChecked = true;
                        chkTwoSidedFoliageBackfaceDiffuse.IsChecked = true;
                        cmbProbeRes.SelectedIndex = 0;
                        cmbProbeTraceBudget.SelectedIndex = 2;
                        cmbProbeAtlasResolution.SelectedIndex = 2;
                        cmbProbeCacheFrameKeep.SelectedIndex = 1;
                        chkLumenTranslucencyVolume.IsChecked = true;
                        chkLumenTranslucencyTrace.IsChecked = true;
                        sldrLumenFarFieldDistance.Value = 15000;
                        chkTigherProbes.IsChecked = false;
                        break;
                    case Presets.HIGH:
                        chkIndirectDiffuse.IsChecked = true;
                        chkDetailedMeshTracing.IsChecked = false;
                        sldrDetailedMeshTracingDist.Value = 0;
                        chkRadiosity.IsChecked = true;
                        chkOffscreenTraceMeshes.IsChecked = false;

                        sldrLumenMeshCardSize.Value = 100;
                        cmbLumenAtlasSize.SelectedIndex = 2;

                        cmbProbeDownsample.SelectedIndex = 2;
                        cmbLumenTraceOctaRes.SelectedIndex = 1;
                        chkStochasticInterpolation.IsChecked = true;
                        chkTwoSidedFoliageBackfaceDiffuse.IsChecked = true;
                        cmbProbeRes.SelectedIndex = 1;
                        cmbProbeTraceBudget.SelectedIndex = 3;
                        cmbProbeAtlasResolution.SelectedIndex = 2;
                        cmbProbeCacheFrameKeep.SelectedIndex = 1;
                        chkLumenTranslucencyVolume.IsChecked = true;
                        chkLumenTranslucencyTrace.IsChecked = true;
                        sldrLumenFarFieldDistance.Value = 20000;
                        chkTigherProbes.IsChecked = false;
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
                        chkIndirectDiffuse.IsChecked = true;
                        chkDetailedMeshTracing.IsChecked = true;
                        sldrDetailedMeshTracingDist.Value = 60;
                        chkRadiosity.IsChecked = true;
                        chkOffscreenTraceMeshes.IsChecked = true;

                        sldrLumenMeshCardSize.Value = 25;
                        cmbLumenAtlasSize.SelectedIndex = 4;

                        cmbProbeDownsample.SelectedIndex = 4;
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
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyReflections(Presets preset, bool apply = false)
        {
            if (this.viewModel.ReflectionsQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.ReflectionsQualitySettings.Preset = preset;
                }

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
                        cmbReflectionDownSample.SelectedIndex = 2;
                        sldrMaxRoughness.Value = 0.2;
                        cmbReflectionFilterSampleCount.SelectedIndex = 2;
                        chkReflectionSkipEmissiveOpaque.IsChecked = false;
                        chkReflectionSkipEmissiveFront.IsChecked = false;
                        chkReflectionLumenTransparency.IsChecked = false;
                        chkReflectionSceneColor.IsChecked = false;
                        break;
                    case Presets.MEDIUM:
                        cmbSSR.SelectedIndex = 3;
                        chkHalfResScene.IsChecked = false;
                        chkLumenReflections.IsChecked = true;
                        chkTraceMeshReflections.IsChecked = false;
                        cmbReflectionDownSample.SelectedIndex = 3;
                        sldrMaxRoughness.Value = 0.25;
                        cmbReflectionFilterSampleCount.SelectedIndex = 2;
                        chkReflectionSkipEmissiveOpaque.IsChecked = false;
                        chkReflectionSkipEmissiveFront.IsChecked = false;
                        chkReflectionLumenTransparency.IsChecked = false;
                        chkReflectionSceneColor.IsChecked = true;
                        break;
                    case Presets.HIGH:
                        cmbSSR.SelectedIndex = 3;
                        chkHalfResScene.IsChecked = false;
                        chkLumenReflections.IsChecked = true;
                        chkTraceMeshReflections.IsChecked = false;
                        cmbReflectionDownSample.SelectedIndex = 3;
                        sldrMaxRoughness.Value = 0.27;
                        cmbReflectionFilterSampleCount.SelectedIndex = 3;
                        chkReflectionSkipEmissiveOpaque.IsChecked = true;
                        chkReflectionSkipEmissiveFront.IsChecked = false;
                        chkReflectionLumenTransparency.IsChecked = false;
                        chkReflectionSceneColor.IsChecked = true;
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
                        cmbSSR.SelectedIndex = 4;
                        chkHalfResScene.IsChecked = false;
                        chkLumenReflections.IsChecked = true;
                        chkTraceMeshReflections.IsChecked = true;
                        cmbReflectionDownSample.SelectedIndex = 4;
                        sldrMaxRoughness.Value = 0.5;
                        cmbReflectionFilterSampleCount.SelectedIndex = 3;
                        chkReflectionSkipEmissiveOpaque.IsChecked = true;
                        chkReflectionSkipEmissiveFront.IsChecked = true;
                        chkReflectionLumenTransparency.IsChecked = true;
                        chkReflectionSceneColor.IsChecked = true;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyShadows(Presets preset, bool apply = false)
        {
            if (this.viewModel.ShadowsQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.ShadowsQualitySettings.Preset = preset;
                }

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
                        cmbShadowQuality.SelectedIndex = 3;
                        sldrShadowCascades.Value = 2;
                        cmbShadowResolution.SelectedIndex = 3;
                        sldrShadowRadiusThresh.Value = 0.05;
                        sldrShadowDist.Value = 0.9;
                        cmbShadowTransitionScale.SelectedIndex = 0;
                        sldrPreshadowRes.Value = 0.5;
                        chkDistanceFieldShadowing.IsChecked = false;
                        sldrDistanceFieldShadowQuality.Value = 0;
                        cmbShadowPageSize.SelectedIndex = 1;
                        sldrFirstClipmapLevel.Value = 6;
                        cmbDirectionalLightQualityPreference.SelectedIndex = 1;
                        sldrViewBiasDirectional.Value = 2;
                        cmbShadowRaytraceQuality.SelectedIndex = 2;
                        chkContactShadows.IsChecked = true;
                        chkContactShadowsLocal.IsChecked = false;
                        chkShadowSkeletelProxy.IsChecked = true;
                        chkShadowStaticSeperate.IsChecked = true;
                        break;
                    case Presets.HIGH:
                        cmbShadowQuality.SelectedIndex = 5;
                        sldrShadowCascades.Value = 4;
                        cmbShadowResolution.SelectedIndex = 4;
                        sldrShadowRadiusThresh.Value = 0.04;
                        sldrShadowDist.Value = 0.95;
                        sldrPreshadowRes.Value = 0.5;
                        chkDistanceFieldShadowing.IsChecked = false;
                        sldrDistanceFieldShadowQuality.Value = 0;
                        cmbShadowPageSize.SelectedIndex = 2;
                        sldrFirstClipmapLevel.Value = 6;
                        cmbDirectionalLightQualityPreference.SelectedIndex = 2;
                        sldrViewBiasDirectional.Value = 1;
                        cmbShadowRaytraceQuality.SelectedIndex = 3;
                        chkContactShadows.IsChecked = true;
                        chkContactShadowsLocal.IsChecked = true;
                        chkShadowSkeletelProxy.IsChecked = true;
                        chkShadowStaticSeperate.IsChecked = true;
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
                        cmbDirectionalLightQualityPreference.SelectedIndex = 3;
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
                        cmbShadowQuality.SelectedIndex = 5;
                        sldrShadowCascades.Value = 15;
                        cmbShadowResolution.SelectedIndex = 4;
                        sldrShadowRadiusThresh.Value = 0.01;
                        sldrShadowDist.Value = 1.0;
                        cmbShadowTransitionScale.SelectedIndex = 2;
                        sldrPreshadowRes.Value = 1.0;
                        chkDistanceFieldShadowing.IsChecked = true;
                        sldrDistanceFieldShadowQuality.Value = 1.0;
                        cmbShadowPageSize.SelectedIndex = 3;
                        sldrFirstClipmapLevel.Value = 6;
                        cmbDirectionalLightQualityPreference.SelectedIndex = 4;
                        sldrViewBiasDirectional.Value = 0;
                        cmbShadowRaytraceQuality.SelectedIndex = 4;
                        chkContactShadows.IsChecked = true;
                        chkContactShadowsLocal.IsChecked = true;
                        chkShadowSkeletelProxy.IsChecked = false;
                        chkShadowStaticSeperate.IsChecked = true;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyClouds(Presets preset, bool apply = false)
        {
        if (this.viewModel.CloudsQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.CloudsQualitySettings.Preset = preset;
                }

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
                        chkCloudAO.IsChecked = false;
                        cmbCloudAORes.SelectedIndex = 2;
                        sldrCloudViewRayCount.Value = 196;
                        sldrCloudReflectionRayCount.Value = 30;
                        sldrCloudShadowRayCount.Value = 4;
                        break;
                    case Presets.HIGH:
                        chkCloudAO.IsChecked = false;
                        cmbCloudAORes.SelectedIndex = 2;
                        sldrCloudViewRayCount.Value = 196;
                        sldrCloudReflectionRayCount.Value = 40;
                        sldrCloudShadowRayCount.Value = 4;
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
                        chkCloudAO.IsChecked = true;
                        cmbCloudAORes.SelectedIndex = 3;
                        sldrCloudViewRayCount.Value = 400;
                        sldrCloudReflectionRayCount.Value = 100;
                        sldrCloudShadowRayCount.Value = 6;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyFog(Presets preset, bool apply = false)
        {
            if (this.viewModel.FogQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.FogQualitySettings.Preset = preset;
                }

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
                        chkVolumetricFog.IsChecked = true;
                        cmbFogRes.SelectedIndex = 1;
                        sldrFogSampleCount.Value = 4;
                        break;
                    case Presets.HIGH:
                        chkVolumetricFog.IsChecked = true;
                        cmbFogRes.SelectedIndex = 2;
                        sldrFogSampleCount.Value = 4;
                        break;
                    case Presets.EPIC:
                        chkVolumetricFog.IsChecked = true;
                        cmbFogRes.SelectedIndex = 3;
                        sldrFogSampleCount.Value = 4;
                        break;
                    case Presets.ULTRA:
                        chkVolumetricFog.IsChecked = true;
                        cmbFogRes.SelectedIndex = 4;
                        sldrFogSampleCount.Value = 8;
                        break;
                    case Presets.INSANE:
                        chkVolumetricFog.IsChecked = true;
                        cmbFogRes.SelectedIndex = 4;
                        sldrFogSampleCount.Value = 12;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplySky(Presets preset, bool apply = false)
        {
            if (this.viewModel.SkyQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.SkyQualitySettings.Preset = preset;
                }

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
                        sldrSkySampleMax.Value = 1;
                        cmbSkyDepthLevel.SelectedIndex = 3;
                        sldrSkyColorSamples.Value = 32;
                        sldrSkyAtmosphereSamples.Value = 32;
                        chkHigherFormatLUT.IsChecked = true;
                        sldrSkyTransmittanceSamples.Value = 10;
                        sldrSkyScatteringSamples.Value = 15;
                        chkSkyReflection.IsChecked = true;
                        cmbSkyReflectionRes.SelectedIndex = 1;
                        break;
                    case Presets.HIGH:
                        sldrSkySampleMax.Value = 2;
                        cmbSkyDepthLevel.SelectedIndex = 3;
                        sldrSkyColorSamples.Value = 64;
                        sldrSkyAtmosphereSamples.Value = 64;
                        chkHigherFormatLUT.IsChecked = true;
                        sldrSkyTransmittanceSamples.Value = 10;
                        sldrSkyScatteringSamples.Value = 15;
                        chkSkyReflection.IsChecked = true;
                        cmbSkyReflectionRes.SelectedIndex = 2;
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
                        cmbSkyDepthLevel.SelectedIndex = 5;
                        sldrSkyColorSamples.Value = 256;
                        sldrSkyAtmosphereSamples.Value = 256;
                        chkHigherFormatLUT.IsChecked = true;
                        sldrSkyTransmittanceSamples.Value = 20;
                        sldrSkyScatteringSamples.Value = 30;
                        chkSkyReflection.IsChecked = true;
                        cmbSkyReflectionRes.SelectedIndex = 3;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyFoliage(Presets preset, bool apply = false)
        {
            if (this.viewModel.FoliageQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.FoliageQualitySettings.Preset = preset;
                }

                switch (preset)
                {
                    case Presets.POTATO:
                        cmbFoliagePopin.SelectedIndex = 0;
                        sldrFoliageLOD.Value = 0.52;
                        sldrFoliageGrassDist.Value = 0.4;
                        sldrFoliageTreeDist.Value = 0.4;
                        sldrFoliageGrassDensity.Value = 0.35;
                        chkLimitFoliageGeometry.IsChecked = true;
                        break;
                    case Presets.VERY_LOW:
                        cmbFoliagePopin.SelectedIndex = 0;
                        sldrFoliageLOD.Value = 0.72;
                        sldrFoliageGrassDist.Value = 0.54;
                        sldrFoliageTreeDist.Value = 0.54;
                        sldrFoliageGrassDensity.Value = 0.45;
                        chkLimitFoliageGeometry.IsChecked = true;
                        break;
                    case Presets.LOW:
                        cmbFoliagePopin.SelectedIndex = 0;
                        sldrFoliageLOD.Value = 0.8;
                        sldrFoliageGrassDist.Value = 0.6;
                        sldrFoliageTreeDist.Value = 0.6;
                        sldrFoliageGrassDensity.Value = 0.5;
                        chkLimitFoliageGeometry.IsChecked = false;
                        break;
                    case Presets.MEDIUM:
                        cmbFoliagePopin.SelectedIndex = 1;
                        sldrFoliageLOD.Value = 0.9;
                        sldrFoliageGrassDist.Value = 0.8;
                        sldrFoliageTreeDist.Value = 0.7;
                        sldrFoliageGrassDensity.Value = 0.6;
                        chkLimitFoliageGeometry.IsChecked = false;
                        break;
                    case Presets.HIGH:
                        cmbFoliagePopin.SelectedIndex = 2;
                        sldrFoliageLOD.Value = 1.0;
                        sldrFoliageGrassDist.Value = 1.0;
                        sldrFoliageTreeDist.Value = 0.9;
                        sldrFoliageGrassDensity.Value = 0.8;
                        chkLimitFoliageGeometry.IsChecked = false;
                        break;
                    case Presets.EPIC:
                        cmbFoliagePopin.SelectedIndex = 2;
                        sldrFoliageLOD.Value = 1;
                        sldrFoliageGrassDist.Value = 1;
                        sldrFoliageTreeDist.Value = 1;
                        sldrFoliageGrassDensity.Value = 1;
                        chkLimitFoliageGeometry.IsChecked = false;
                        break;
                    case Presets.ULTRA:
                        cmbFoliagePopin.SelectedIndex = 3;
                        sldrFoliageLOD.Value = 1;
                        sldrFoliageGrassDist.Value = 1;
                        sldrFoliageTreeDist.Value = 1;
                        sldrFoliageGrassDensity.Value = 1;
                        chkLimitFoliageGeometry.IsChecked = false;
                        break;
                    case Presets.INSANE:
                        cmbFoliagePopin.SelectedIndex = 3;
                        sldrFoliageLOD.Value = 1;
                        sldrFoliageGrassDist.Value = 1;
                        sldrFoliageTreeDist.Value = 1;
                        sldrFoliageGrassDensity.Value = 1;
                        chkLimitFoliageGeometry.IsChecked = false;
                        break;
                    case Presets.CUSTOM:
                        break;
                    default:
                        break;
                }
            }
        }
        private void ApplyViewDistance(Presets preset, bool apply = false)
        {
            if (this.viewModel.ViewDistanceQualitySettings.PresetLocked == false)
            {
                if (apply)
                {
                    this.ViewModel.ViewDistanceQualitySettings.Preset = preset;
                }

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
                        sldrViewDistance.Value = 1;
                        sldrLightViewDistance.Value = 0.75;
                        break;
                    case Presets.HIGH:
                        sldrViewDistance.Value = 1;
                        sldrLightViewDistance.Value = 1;
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
            }
        }
        private void ApplyPreset()
        {
            var preset = this.ViewModel.CurrentPreset;

            ApplyTextures(preset, true);
            ApplyHair(preset, true);
            ApplyObjectDetail(preset, true);
            ApplyEffects(preset, true);
            ApplyMaterials(preset, true);
            ApplyPostProcessing(preset, true);
            ApplyDOF(preset, true);
            ApplyAA(preset, true);
            ApplyMotionBlur(preset, true);
            ApplyShading(preset, true);
            ApplyGI(preset, true);
            ApplyReflections(preset, true);
            ApplyShadows(preset, true);
            ApplyClouds(preset, true);
            ApplyFog(preset, true);
            ApplySky(preset, true);
            ApplyFoliage(preset, true);
            ApplyViewDistance(preset, true);

        }

        private void rdioPotatoPreset_Checked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.POTATO;
            ApplyPreset();
        }

        private void rdioVeryLowPreset_Checked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.VERY_LOW;
            ApplyPreset();
        }

        private void rdioLowPreset_Checked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.LOW;
            ApplyPreset();
        }

        private void rdioEpicPreset_Checked(object sender, RoutedEventArgs e)
        {
            if(sldrTextures == null)
            {
                // not ready yet
                return;
            }


            this.ViewModel.CurrentPreset = Presets.EPIC;
            ApplyPreset();

        }

        private void rdioUltraPreset_Checked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.ULTRA;
            ApplyPreset();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.EPIC;
            ApplyPreset();
        }

        private void rdioInsanePreset_Checked(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.INSANE;
            ApplyPreset();
        }

        private void btnMediumPreset_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.MEDIUM;
            ApplyPreset();
        }

        private void btnHighPreset_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.CurrentPreset = Presets.HIGH;
            ApplyPreset();
        }
    }
}