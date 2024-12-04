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
        public int r_DepthOfFieldQuality=3;
        public int r_DOF_Gather_AccumulatorQuality=1;       //; higher gathering accumulator quality
        public int r_DOF_Gather_PostfilterMethod=1;          //; Median3x3 postfilering method
        public int r_DOF_Gather_EnableBokehSettings=0;       //; no bokeh simulation when gathering
        public int r_DOF_Gather_RingCount = 4;                 //; medium number of samples when gathering
        public int r_DOF_Scatter_ForegroundCompositing=1;    //; additive foreground scattering
        public int r_DOF_Scatter_BackgroundCompositing=2;    //; additive background scattering
        public int r_DOF_Scatter_EnableBokehSettings=1;      //; bokeh simulation when scattering
        public float r_DOF_Scatter_MaxSpriteRatio = 0.1f;         //; only a maximum of 10% of scattered bokeh
        public int r_DOF_Recombine_Quality = 1;                //; cheap slight out of focus
        public int r_DOF_Recombine_EnableBokehSettings = 0;    //; no bokeh simulation on slight out of focus
        public int r_DOF_TemporalAAQuality=1;                //; more stable temporal accumulation
        public float r_DOF_Kernel_MaxForegroundRadius =0.025f;
        public float r_DOF_Kernel_MaxBackgroundRadius = 0.025f;

        public DOFQualitySettings()
        {
        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.DepthOfFieldQuality={r_DepthOfFieldQuality}");
            sb.AppendLine($"r.DOF.Gather.AccumulatorQuality={r_DOF_Gather_AccumulatorQuality}");

            sb.AppendLine($"r.DOF.Gather.PostfilterMethod={r_DOF_Gather_PostfilterMethod}");
            sb.AppendLine($"r.DOF.Gather.EnableBokehSettings={r_DOF_Gather_EnableBokehSettings}");

             sb.AppendLine($"r.DOF.Gather.RingCount={r_DOF_Gather_RingCount}");
            sb.AppendLine($"r.DOF.Scatter.ForegroundCompositing={r_DOF_Scatter_ForegroundCompositing}");
            sb.AppendLine($"r.DOF.Scatter.BackgroundCompositing={r_DOF_Scatter_BackgroundCompositing}");
            sb.AppendLine($"r.DOF.Scatter.EnableBokehSettings={r_DOF_Scatter_EnableBokehSettings}");
            sb.AppendLine($"r.DOF.Scatter.MaxSpriteRatio={r_DOF_Scatter_MaxSpriteRatio}");
            sb.AppendLine($"r.DOF.Recombine.Quality={r_DOF_Recombine_Quality}");
            sb.AppendLine($"r.DOF.Recombine.EnableBokehSettings={r_DOF_Recombine_EnableBokehSettings}");
            sb.AppendLine($"r.DOF.TemporalAAQuality={r_DOF_TemporalAAQuality}");
            sb.AppendLine($"r.DOF.Kernel.MaxForegroundRadius={r_DOF_Kernel_MaxForegroundRadius}");
            sb.AppendLine($"r.DOF.Kernel.MaxBackgroundRadius={r_DOF_Kernel_MaxBackgroundRadius}");
        }
    }
}
