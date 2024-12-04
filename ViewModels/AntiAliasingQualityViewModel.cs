using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace S2SettingsGenerator.ViewModels
{
    public class AntiAliasingQualityViewModel : QualityViewModel<AntiAliasingQualitySettings>
    {
        private int fxAAQualityIndex;

        public int FXAAQualityIndex
        {
            get { return fxAAQualityIndex; }
            set { 
                fxAAQualityIndex = value;
                this.OnPropertyChanged("FXAAQualityIndex");
            }
        }

        private int temporalAAQualityIndex;

        public int TemporalAAQualityIndex
        {
            get { return temporalAAQualityIndex; }
            set
            {
                temporalAAQualityIndex = value;
                OnPropertyChanged("TemporalAAQualityIndex");
            }
        }

        private int tSRRejectionAntiAliasingQualityIndex;

        public int TSRRejectionAntiAliasingQualityIndex
        {
            get { return tSRRejectionAntiAliasingQualityIndex; }
            set
            {
                tSRRejectionAntiAliasingQualityIndex = value;
                OnPropertyChanged("TSRRejectionAntiAliasingQuality");
            }
        }

        public override void PopulateSettingsModel()
        {
            this.Settings = new AntiAliasingQualitySettings()
            {
                r_FXAA_Quality = fxAAQualityIndex switch
                {
                    0 => 0, //Simple
                    1 => 1, //Dither x3
                    2 => 2, //"Dither x5
                    3 => 3, //Dither x8
                    4 => 4, //Dither x12
                    5 => 5, //x12
                    _ => 4
                },
                r_TemporalAA_Quality = temporalAAQualityIndex switch
                {
                    0 => 0, //Low
                    1 => 1, //Medium
                    2 => 2, //High-Antighost
                    3 => 3, //Epic-Antighost
                    _ => 2
                },
                r_TSR_RejectionAntiAliasingQuality = tSRRejectionAntiAliasingQualityIndex switch
                {
                    0 => 0, //Low
                    1 => 1, //Medium
                    2 => 2, //High
                    _ => 1
                },
                r_TSR_History_GrandReprojection = 0
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public AntiAliasingQualityViewModel() : base("Antialiasing: ")
        {
            this.FXAAQualityIndex = 4;
            this.TemporalAAQualityIndex = 2;
            this.TSRRejectionAntiAliasingQualityIndex = 1;
        }

    }
}
