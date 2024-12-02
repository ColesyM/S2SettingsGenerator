using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    internal struct AntiAliasingQualitySettings
    {
        public int r_FXAA_Quality = 4;
        public int r_TemporalAA_Quality = 2;
        public int r_TSR_RejectionAntiAliasingQuality = 1;
        public int r_TSR_History_GrandReprojection = 0;

        public AntiAliasingQualitySettings()
        {
        }
        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.FXAA.r_FXAA_Quality={r_FXAA_Quality}");
            sb.AppendLine($"r.TemporalAA.Quality={r_TemporalAA_Quality}");

            sb.AppendLine($"r.TSR.RejectionAntiAliasingQuality={r_TSR_RejectionAntiAliasingQuality}");
            sb.AppendLine($"r.TSR.History.GrandReprojection={r_TSR_History_GrandReprojection}");
        }

    }
}
