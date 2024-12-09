using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct AntiAliasingQualitySettings: ISettingsModel
    {
        [IniPropertyAttribute("r.FXAA.Quality")]
        public int r_FXAA_Quality = 4;

        [IniPropertyAttribute("r.TemporalAA.Quality")]
        public int r_TemporalAA_Quality = 2;

        [IniPropertyAttribute("r.TSR.RejectionAntiAliasingQuality")]
        public int r_TSR_RejectionAntiAliasingQuality = 1;

        [IniPropertyAttribute("r.TSR.History.GrandReprojection")]
        public int r_TSR_History_GrandReprojection = 0;

        public AntiAliasingQualitySettings()
        {
        }
    }
}
