using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class MotionBlurQualityViewModel : QualityViewModel<MotionBlurQualitySettings>
    {
        private int motionBlurQualityIndex;

        public int MotionBlurQualityIndex
        {
            get { return motionBlurQualityIndex; }
            set
            {
                motionBlurQualityIndex = value;
                this.OnPropertyChanged("MotionBlurQualityIndex");
            }
        }

        private bool fasterMotionBlur;

        public bool FasterMotionBlur
        {
            get { return fasterMotionBlur; }
            set
            {
                fasterMotionBlur = value;
                this.OnPropertyChanged("FasterMotionBlur");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new MotionBlurQualitySettings()
            {
                r_MotionBlurQuality = motionBlurQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                r_MotionBlur_HalfResGather = fasterMotionBlur ? 1 : 0

            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public MotionBlurQualityViewModel() : base("Motion Blur: ")
        {
        }
    }
}