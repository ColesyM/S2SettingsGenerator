using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.ViewModels;

namespace S2SettingsGenerator
{
    public class MainWindowViewModel : ViewModel
    {
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
