using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class ObjectDetailQualityViewModel : QualityViewModel<ObjectDetailQualitySettings>
    {
        private float preferredObjectDetail;

        public float PreferredObjectDetail
        {
            get { return preferredObjectDetail; }
            set { 
                preferredObjectDetail = value;
                this.OnPropertyChanged("PreferredObjectDetail");
            }
        }

        private float requiredObjectDetail;

        public float RequiredObjectDetail
        {
            get { return requiredObjectDetail; }
            set
            {
                requiredObjectDetail = value;
                this.OnPropertyChanged("RequiredObjectDetail");
            }
        }

        private int nanitePixelsPerEdgeIndex;

        public int NanitePixelsPerEdgeIndex
        {
            get { return nanitePixelsPerEdgeIndex; }
            set { 
                nanitePixelsPerEdgeIndex = value;
                this.OnPropertyChanged("NanitePixelsPerEdgeIndex");
            }
        }

        private int overallDetailIndex;

        public int OverallDetailIndex
        {
            get { return overallDetailIndex; }
            set
            {
                overallDetailIndex = value;
                this.OnPropertyChanged("OverallDetailIndex");
            }
        }

        private int maxAttachesIndex;

        public int MaxAttachesIndex
        {
            get { return maxAttachesIndex; }
            set
            {
                maxAttachesIndex = value;
                this.OnPropertyChanged("MaxAttachesIndex");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new ObjectDetailQualitySettings()
            {
                r_Nanite_ViewMeshLODBias_Offset = preferredObjectDetail,
                r_Nanite_ViewMeshLODBias_Min = requiredObjectDetail,
                r_Nanite_MaxPixelsPerEdge = nanitePixelsPerEdgeIndex switch
                {
                    0 => 4,
                    1 => 3,
                    2 => 2,
                    3 => 1,
                    _ => 1
                },
                r_SkeletalMeshLODBias = 0,
                r_DetailMode = overallDetailIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                mg_CharacterQuality = overallDetailIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 3
                },
                mg_MaxActorWithSimulation = overallDetailIndex switch
                {
                    0 => 10,
                    1 => 10,
                    2 => 15,
                    3 => 15,
                    _ => 15
                },
                mg_MaxAttaches = maxAttachesIndex switch
                {
                    0 => 5,
                    1 => 10,
                    2 => 20,
                    3 => -1,
                    _ => -1
                }
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public ObjectDetailQualityViewModel() : base("Object Detail: ")
        {
        }
    }
}
