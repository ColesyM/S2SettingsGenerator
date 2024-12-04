using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct MotionBlurQualitySettings : ISettingsModel
    {
        public int r_MotionBlurQuality=4;
        public int r_MotionBlur_HalfResGather=0;

        public MotionBlurQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.MotionBlurQuality={r_MotionBlurQuality}");
            sb.AppendLine($"r.MotionBlur.HalfResGather={r_MotionBlur_HalfResGather}");
        }
    }
}
