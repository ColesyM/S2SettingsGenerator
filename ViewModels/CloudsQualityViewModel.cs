using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator.ViewModels
{
    public class CloudsQualityViewModel : QualityViewModel<VolumetricCloudsQualitySettings>
    {
        private bool cloudAO;

        public bool CloudAO
        {
            get { return cloudAO; }
            set { 
                cloudAO = value;
                this.OnPropertyChanged("CloudAO");
            }
        }

        private int cloudAOResIndex;

        public int CloudAOResIndex
        {
            get { return cloudAOResIndex; }
            set { 
                cloudAOResIndex = value;
                this.OnPropertyChanged("CloudAOResIndex");
            }
        }

        private int cloudViewRayCount;

        public int CloudViewRayCount
        {
            get { return cloudViewRayCount; }
            set { 
                cloudViewRayCount = value;
                this.OnPropertyChanged("CloudViewRayCount");
            }
        }

        private int cloudReflectionRayCount;

        public int CloudReflectionRayCount
        {
            get { return cloudReflectionRayCount; }
            set { 
                cloudReflectionRayCount = value;
                this.OnPropertyChanged("CloudReflectionRayCount");
            }
        }

        private int cloudShadowRayCount;

        public int CloudShadowRayCount
        {
            get { return cloudShadowRayCount; }
            set { 
                cloudShadowRayCount = value;
                this.OnPropertyChanged("CloudShadowRayCount");
            }
        }


        public override void PopulateSettingsModel()
        {
            Settings = new VolumetricCloudsQualitySettings()
            {
                r_VolumetricCloud_SkyAO = cloudAO ? 1 : 0,
                r_VolumetricCloud_SkyAO_MaxResolution = cloudAOResIndex switch
                {
                    0 => 32,
                    1 => 64,
                    2 => 128,
                    3 => 256,
                    _ => 128
                },
                r_VolumetricCloud_ViewRaySampleMaxCount = cloudViewRayCount,
                r_VolumetricCloud_DistanceToSampleMaxCount = 80,
                r_VolumetricCloud_ReflectionRaySampleMaxCount = cloudReflectionRayCount,
                r_VolumetricCloud_Shadow_ViewRaySampleMaxCount = cloudShadowRayCount
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public CloudsQualityViewModel() : base("Clouds: ")
        {
        }
    }
}