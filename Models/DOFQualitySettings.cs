using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct DOFQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.DepthOfFieldQuality")]
        public int r_DepthOfFieldQuality=3;
        [IniPropertyAttribute("r.DOF.Gather.AccumulatorQuality")]
        public int r_DOF_Gather_AccumulatorQuality=1;       //; higher gathering accumulator quality
        [IniPropertyAttribute("r.DOF.Gather.PostfilterMethod")]
        public int r_DOF_Gather_PostfilterMethod=1;          //; Median3x3 postfilering method
        [IniPropertyAttribute("r.DOF.Gather.EnableBokehSettings")]
        public int r_DOF_Gather_EnableBokehSettings=0;       //; no bokeh simulation when gathering
        [IniPropertyAttribute("r.DOF.Gather.RingCount")]
        public int r_DOF_Gather_RingCount = 4;                 //; medium number of samples when gathering
        [IniPropertyAttribute("r.DOF.Scatter.ForegroundCompositing")]
        public int r_DOF_Scatter_ForegroundCompositing=1;    //; additive foreground scattering
        [IniPropertyAttribute("r.DOF.Scatter.BackgroundCompositing")]
        public int r_DOF_Scatter_BackgroundCompositing=2;    //; additive background scattering
        [IniPropertyAttribute("r.DOF.Scatter.EnableBokehSettings")]
        public int r_DOF_Scatter_EnableBokehSettings=1;      //; bokeh simulation when scattering
        [IniPropertyAttribute("r.DOF.Scatter.MaxSpriteRatio")]
        public float r_DOF_Scatter_MaxSpriteRatio = 0.1f;         //; only a maximum of 10% of scattered bokeh
        [IniPropertyAttribute("r.DOF.Recombine.Quality")]
        public int r_DOF_Recombine_Quality = 1;                //; cheap slight out of focus
        [IniPropertyAttribute("r.DOF.Recombine.EnableBokehSettings")]
        public int r_DOF_Recombine_EnableBokehSettings = 0;    //; no bokeh simulation on slight out of focus
        [IniPropertyAttribute("r.DOF.TemporalAAQuality")]
        public int r_DOF_TemporalAAQuality=1;                //; more stable temporal accumulation
        [IniPropertyAttribute("r.DOF.Kernel.MaxForegroundRadius")]
        public float r_DOF_Kernel_MaxForegroundRadius =0.025f;
        [IniPropertyAttribute("r.DOF.Kernel.MaxBackgroundRadius")]
        public float r_DOF_Kernel_MaxBackgroundRadius = 0.025f;

        public DOFQualitySettings()
        {
        }
    }
}
