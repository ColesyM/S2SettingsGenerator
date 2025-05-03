using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class ViewDistanceQualityViewModel : QualityViewModel<ViewDistanceQualitySettings>
    {
        private float viewDistance;

        public float ViewDistance
        {
            get { return viewDistance; }
            set
            {
                viewDistance = value;
                this.OnPropertyChanged("ViewDistance");
            }
        }

        private float lightViewDistance;

        public float LightViewDistance
        {
            get { return lightViewDistance; }
            set
            {
                lightViewDistance = value;
                this.OnPropertyChanged("LightViewDistance");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new ViewDistanceQualitySettings()
            {
                r_SkeletalMeshLODBias = 0,
                r_ViewDistanceScale = viewDistance,
                gsc_ForceCompositionStreamingDistance = -1,
                //wp_Runtime_HLOD = 1,
                r_LightMaxDrawDistanceScale = lightViewDistance
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public ViewDistanceQualityViewModel() : base("View Distance: ")
        {
        }
    }
}