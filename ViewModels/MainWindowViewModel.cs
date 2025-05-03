using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;
using S2SettingsGenerator.ViewModels;

namespace S2SettingsGenerator
{
    public class PresetChangedEventArgs : EventArgs
    {
        public PresetChangedEventArgs(Presets preset, string? sectionName)
        {
            Preset = preset;
            SectionName = sectionName;
        }

        public virtual Presets Preset { get; }
        public virtual string SectionName { get; }
    }

    public delegate void PresetChangedEventHandler(object? sender, PresetChangedEventArgs e);

    public class MainWindowViewModel : ViewModel
    {
        public event PresetChangedEventHandler PresetSectionChanged;

        internal void OnPresetSectionChanged(Presets preset, string presectionName)
        {
            if (PresetSectionChanged != null)
            {
                PresetSectionChanged(this, new PresetChangedEventArgs(preset, presectionName));
            }
        }

        public MainWindowViewModel()
		{
            this.textureQualitySettings = new TextureQualityViewModel();
            this.hairQualitySettings = new HairQualityViewModel();
            this.objectDetailQualitySettings = new ObjectDetailQualityViewModel();
            this.effectsQualitySettings = new EffectsQualityViewModel();
            this.materialsQualitySettings = new MaterialsQualityViewModel();
            this.postProcessingQualitySettings = new PostProcessingQualityViewModel();
            this.dofQualitySettings = new DOFQualityViewModel();
		    this.aaQualitySettings = new AntiAliasingQualityViewModel();
            this.motionBlurQualitySettings = new MotionBlurQualityViewModel();
            this.shadingQualitySettings = new ShadingQualityViewModel();
            this.globalIlluminationQualitySettings = new GlobalIlluminationQualityViewModel();
            this.reflectionsQualitySettings = new ReflectionsQualityViewModel();
            this.shadowsQualitySettings = new ShadowsQualityViewModel();
            this.cloudsQualitySettings = new CloudsQualityViewModel();
            this.fogQualitySettings = new FogQualityViewModel();
            this.skyQualitySettings = new SkyQualityViewModel();
            this.foliageQualitySettings = new FoliageQualityViewModel();
            this.viewDistanceQualitySettings = new ViewDistanceQualityViewModel();

            this.textureQualitySettings.PropertyChanged += TextureQualitySettings_PropertyChanged;
            this.hairQualitySettings.PropertyChanged += HairQualitySettings_PropertyChanged;
            this.objectDetailQualitySettings.PropertyChanged += ObjectDetailQualitySettings_PropertyChanged;
            this.effectsQualitySettings.PropertyChanged += EffectsQualitySettings_PropertyChanged;
            this.materialsQualitySettings.PropertyChanged += MaterialsQualitySettings_PropertyChanged;
            this.postProcessingQualitySettings.PropertyChanged += PostProcessingQualitySettings_PropertyChanged;
            this.dofQualitySettings.PropertyChanged += DofQualitySettings_PropertyChanged;
            this.aaQualitySettings.PropertyChanged += AaQualitySettings_PropertyChanged;
            this.motionBlurQualitySettings.PropertyChanged += MotionBlurQualitySettings_PropertyChanged;
            this.shadingQualitySettings.PropertyChanged += ShadingQualitySettings_PropertyChanged;
            this.globalIlluminationQualitySettings.PropertyChanged += GlobalIlluminationQualitySettings_PropertyChanged;
            this.reflectionsQualitySettings.PropertyChanged += ReflectionsQualitySettings_PropertyChanged;
            this.shadowsQualitySettings.PropertyChanged += ShadowsQualitySettings_PropertyChanged;
            this.cloudsQualitySettings.PropertyChanged += CloudsQualitySettings_PropertyChanged;
            this.fogQualitySettings.PropertyChanged += FogQualitySettings_PropertyChanged;
            this.foliageQualitySettings.PropertyChanged += FoliageQualitySettings_PropertyChanged;
            this.viewDistanceQualitySettings.PropertyChanged += ViewDistanceQualitySettings_PropertyChanged;
            this.skyQualitySettings.PropertyChanged += SkyQualitySettings_PropertyChanged;
        }

        private void SkyQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.skyQualitySettings.PresetIndex, "Sky");
            }
        }

        private void ViewDistanceQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.viewDistanceQualitySettings.PresetIndex, "ViewDistance");
            }
        }

        private void FoliageQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.foliageQualitySettings.PresetIndex, "Foliage");
            }
        }

        private void FogQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.fogQualitySettings.PresetIndex, "Fog");
            }
        }

        private void CloudsQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.cloudsQualitySettings.PresetIndex, "Clouds");
            }
        }

        private void ShadowsQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.shadowsQualitySettings.PresetIndex, "Shadows");
            }
        }

        private void ReflectionsQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.reflectionsQualitySettings.PresetIndex, "Reflections");
            }
        }

        private void GlobalIlluminationQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.globalIlluminationQualitySettings.PresetIndex, "GlobalIllumination");
            }
        }

        private void ShadingQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.shadingQualitySettings.PresetIndex, "Shading");
            }
        }

        private void MotionBlurQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.motionBlurQualitySettings.PresetIndex, "MotionBlur");
            }
        }

        private void AaQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.aaQualitySettings.PresetIndex, "AA");
            }
        }

        private void DofQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.dofQualitySettings.PresetIndex, "Dof");
            }
        }

        private void PostProcessingQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.postProcessingQualitySettings.PresetIndex, "PostProcessing");
            }
        }

        private void MaterialsQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.materialsQualitySettings.PresetIndex, "Materials");
            }
        }

        private void EffectsQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.effectsQualitySettings.PresetIndex, "Effects");
            }
        }

        private void ObjectDetailQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.objectDetailQualitySettings.PresetIndex, "ObjectDetail");
            }
        }

        private void HairQualitySettings_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.hairQualitySettings.PresetIndex, "Hair");
            }
        }

        private void TextureQualitySettings_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "PresetIndex")
            {
                OnPresetSectionChanged((Presets)this.textureQualitySettings.PresetIndex, "Texture");
            }
        }

        private TextureQualityViewModel textureQualitySettings;
        private HairQualityViewModel hairQualitySettings;
        private ObjectDetailQualityViewModel objectDetailQualitySettings;
        private EffectsQualityViewModel effectsQualitySettings;
        private MaterialsQualityViewModel materialsQualitySettings;
        private PostProcessingQualityViewModel postProcessingQualitySettings;
        private DOFQualityViewModel dofQualitySettings;
        private AntiAliasingQualityViewModel aaQualitySettings;
        private MotionBlurQualityViewModel motionBlurQualitySettings;
        private ShadingQualityViewModel shadingQualitySettings;
        private GlobalIlluminationQualityViewModel globalIlluminationQualitySettings;
        private ReflectionsQualityViewModel reflectionsQualitySettings;
        private ShadowsQualityViewModel shadowsQualitySettings;
        private CloudsQualityViewModel cloudsQualitySettings;
        private FogQualityViewModel fogQualitySettings;
        private SkyQualityViewModel skyQualitySettings;
        private FoliageQualityViewModel foliageQualitySettings;
        private ViewDistanceQualityViewModel viewDistanceQualitySettings;
        private FSRSettings fsrSettings = new FSRSettings();

        public FSRSettings FSRSettings
        {
            get { return fsrSettings; }
            set
            {
                fsrSettings = value;
                OnPropertyChanged("FSRSettings");
            }
        }

        private bool improveFSRQuality;

        public bool ImproveFSRQuality
        {
            get { return improveFSRQuality; }
            set
            {
                improveFSRQuality = value;
                this.OnPropertyChanged("ImproveFSRQuality");
            }
        }

        public TextureQualityViewModel TextureQualitySettings
        {
            get { return textureQualitySettings; }
            set
            {
                textureQualitySettings = value;
                OnPropertyChanged("TextureQualitySettings");
            }
        }
        public HairQualityViewModel HairQualitySettings
        {
            get { return hairQualitySettings; }
            set
            {
                hairQualitySettings = value;
                OnPropertyChanged("HairQualitySettings");
            }
        }
        public ObjectDetailQualityViewModel ObjectDetailQualitySettings
        {
            get { return objectDetailQualitySettings; }
            set
            {
                objectDetailQualitySettings = value;
                OnPropertyChanged("ObjectDetailQualitySettings");
            }
        }
        public EffectsQualityViewModel EffectsQualitySettings
        {
            get { return effectsQualitySettings; }
            set
            {
                effectsQualitySettings = value;
                OnPropertyChanged("EffectsQualitySettings");
            }
        }
        public MaterialsQualityViewModel MaterialsQualitySettings
        {
            get { return materialsQualitySettings; }
            set
            {
                materialsQualitySettings = value;
                OnPropertyChanged("MaterialsQualitySettings");
            }
        }
        public PostProcessingQualityViewModel PostProcessingQualitySettings
        {
            get { return postProcessingQualitySettings; }
            set
            {
                postProcessingQualitySettings = value;
                OnPropertyChanged("PostProcessingQualitySettings");
            }
        }
        public DOFQualityViewModel DOFQualitySettings
        {
            get { return dofQualitySettings; }
            set
            {
                dofQualitySettings = value;
                OnPropertyChanged("DOFQualitySettings");
            }
        }

        public AntiAliasingQualityViewModel AAQualitySettings
        {
			get { return aaQualitySettings; }
			set 
			{ 
				aaQualitySettings = value;
				OnPropertyChanged("AAQualitySettings");
			}
        }

        public MotionBlurQualityViewModel MotionBlurQualitySettings
        {
            get { return motionBlurQualitySettings; }
            set
            {
                motionBlurQualitySettings = value;
                OnPropertyChanged("MotionBlurQualitySettings");
            }
        }
        public ShadingQualityViewModel ShadingQualitySettings
        {
            get { return shadingQualitySettings; }
            set
            {
                shadingQualitySettings = value;
                OnPropertyChanged("ShadingQualitySettings");
            }
        }
        public GlobalIlluminationQualityViewModel GlobalIlluminationQualitySettings
        {
            get { return globalIlluminationQualitySettings; }
            set
            {
                globalIlluminationQualitySettings = value;
                OnPropertyChanged("GlobalIlluminationQualitySettings");
            }
        }
        public ReflectionsQualityViewModel ReflectionsQualitySettings
        {
            get { return reflectionsQualitySettings; }
            set
            {
                reflectionsQualitySettings = value;
                OnPropertyChanged("ReflectionsQualitySettings");
            }
        }
        public ShadowsQualityViewModel ShadowsQualitySettings
        {
            get { return shadowsQualitySettings; }
            set
            {
                shadowsQualitySettings = value;
                OnPropertyChanged("ShadowsQualitySettings");
            }
        }
        public CloudsQualityViewModel CloudsQualitySettings
        {
            get { return cloudsQualitySettings; }
            set
            {
                cloudsQualitySettings = value;
                OnPropertyChanged("CloudsQualitySettings");
            }
        }
        public FogQualityViewModel FogQualitySettings
        {
            get { return fogQualitySettings; }
            set
            {
                fogQualitySettings = value;
                OnPropertyChanged("FogQualitySettings");
            }
        }
        public SkyQualityViewModel SkyQualitySettings
        {
            get { return skyQualitySettings; }
            set
            {
                skyQualitySettings = value;
                OnPropertyChanged("SkyQualitySettings");
            }
        }
        public FoliageQualityViewModel FoliageQualitySettings
        {
            get { return foliageQualitySettings; }
            set
            {
                foliageQualitySettings = value;
                OnPropertyChanged("FoliageQualitySettings");
            }
        }
        public ViewDistanceQualityViewModel ViewDistanceQualitySettings
        {
            get { return viewDistanceQualitySettings; }
            set
            {
                viewDistanceQualitySettings = value;
                OnPropertyChanged("ViewDistanceQualitySettings");
            }
        }

        private Presets currentPreset;

        public Presets CurrentPreset
        {
            get { return currentPreset; }
            set
            {
                currentPreset = value;
                OnPropertyChanged("CurrentPreset");
            }
        }

    }
}
