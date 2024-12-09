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
        [IniPropertyAttribute("r.MotionBlurQuality")]
        public int r_MotionBlurQuality=4;
        [IniPropertyAttribute("r.MotionBlur.HalfResGather")]
        public int r_MotionBlur_HalfResGather=0;

        public MotionBlurQualitySettings()
        {
        }
    }
}
