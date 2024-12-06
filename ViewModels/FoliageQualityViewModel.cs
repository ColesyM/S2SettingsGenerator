using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class FoliageQualityViewModel : QualityViewModel<FoliageQualitySettings>
    {
        private int popInIndex;

        public int PopInIndex
        {
            get { return popInIndex; }
            set { 
                popInIndex = value;
                this.OnPropertyChanged("PopInIndex");
            }
        }

        private float foliageLOD;

        public float FoliageLOD
        {
            get { return foliageLOD; }
            set { 
                foliageLOD = value;
                this.OnPropertyChanged("FoliageLOD");
            }
        }

        private bool limitFoliageGeometry;

        public bool LimitFoliageGeometry
        {
            get { return limitFoliageGeometry; }
            set { 
                limitFoliageGeometry = value;
                this.OnPropertyChanged("LimitFoliageGeometry");
            }
        }

        private float grassDistance;

        public float GrassDistance
        {
            get { return grassDistance; }
            set {
                grassDistance = value;
                this.OnPropertyChanged("GrassDistance");
            }
        }

        private float treeDistance;

        public float TreeDistance
        {
            get { return treeDistance; }
            set
            {
                treeDistance = value;
                this.OnPropertyChanged("TreeDistance");
            }
        }

        private float grassDensity;

        public float GrassDensity
        {
            get { return grassDistance; }
            set
            {
                grassDensity = value;
                this.OnPropertyChanged("GrassDensity");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new FoliageQualitySettings()
            {
                foliage_MinimumScreenSize = popInIndex switch
                {
                    0 => 0.005f,
                    1 => 0.0005f,
                    2 => 0.000005f,
                    3 => 0.0000025f,
                    _ => 0.000005f
                },
                foliage_LODDistanceScale = foliageLOD,
                foliage_MaxTrianglesToRender = limitFoliageGeometry ? 133333 : 100000000,
                fg_CullDistanceScale_Grass = grassDistance,
                fg_CullDistanceScale_Trees = treeDistance,
                fg_DensityScale_Grass = grassDensity

            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public FoliageQualityViewModel() : base("Foliage: ")
        {
        }
    }
}
