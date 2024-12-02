using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    internal struct SkyQualitySettings
    {
        public int r_SkyAtmosphere_AerialPerspectiveLUT_FastApplyOnOpaque=1; //; Always have FastSkyLUT 1 in this case to avoid wrong sky
        public int r_SkyAtmosphere_AerialPerspectiveLUT_SampleCountMaxPerSlice=4;
        public float r_SkyAtmosphere_AerialPerspectiveLUT_DepthResolution=16.0f;
        public int r_SkyAtmosphere_FastSkyLUT = 1;
        public float r_SkyAtmosphere_FastSkyLUT_SampleCountMin =4.0f;
        public float r_SkyAtmosphere_FastSkyLUT_SampleCountMax =128.0f;
        public float r_SkyAtmosphere_SampleCountMin = 4.0f;
        public float r_SkyAtmosphere_SampleCountMax = 128.0f;
        public int r_SkyAtmosphere_TransmittanceLUT_UseSmallFormat=0;
        public float r_SkyAtmosphere_TransmittanceLUT_SampleCount =10.0f;
        public float r_SkyAtmosphere_MultiScatteringLUT_SampleCount =15.0f;
        public int r_SkyLight_RealTimeReflectionCapture = 1;
        public int r_SkyLight_RealTimeReflectionCapture_TimeSlice_SkyCloudCubeFacePerFrame=6;

        public SkyQualitySettings()
        {

        }
        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.SkyAtmosphere.AerialPerspectiveLUT.FastApplyOnOpaque={r_SkyAtmosphere_AerialPerspectiveLUT_FastApplyOnOpaque}");
            sb.AppendLine($"r.AerialPerspectiveLUT.SampleCountMaxPerSlice={r_SkyAtmosphere_AerialPerspectiveLUT_SampleCountMaxPerSlice}");
            sb.AppendLine($"r.AerialPerspectiveLUT.DepthResolution={r_SkyAtmosphere_AerialPerspectiveLUT_DepthResolution}");
            sb.AppendLine($"r.SkyAtmosphere.FastSkyLUT={r_SkyAtmosphere_FastSkyLUT}");
            sb.AppendLine($"r.SkyAtmosphere.FastSkyLUT.SampleCountMin={r_SkyAtmosphere_FastSkyLUT_SampleCountMin}");
            sb.AppendLine($"r.SkyAtmosphere.FastSkyLUT.ampleCountMax={r_SkyAtmosphere_FastSkyLUT_SampleCountMax}");
            sb.AppendLine($"r.SkyAtmosphereSampleCountMin.={r_SkyAtmosphere_SampleCountMin}");
            sb.AppendLine($"r.SkyAtmosphere.SampleCountMax={r_SkyAtmosphere_SampleCountMax}");
            sb.AppendLine($"r.SkyAtmosphere.TransmittanceLUT.UseSmallFormat={r_SkyAtmosphere_TransmittanceLUT_UseSmallFormat}");
            sb.AppendLine($"r.SkyAtmosphere.TransmittanceLUT.SampleCount={r_SkyAtmosphere_TransmittanceLUT_SampleCount}");
            sb.AppendLine($"r.SkyAtmosphere.MultiScatteringLUT.SampleCount={r_SkyAtmosphere_MultiScatteringLUT_SampleCount}");
            sb.AppendLine($"r.SkyLight.RealTimeReflectionCapture={r_SkyLight_RealTimeReflectionCapture}");
            sb.AppendLine($"r.SkyLight.RealTimeReflectionCapture.TimeSlice.SkyCloudCubeFacePerFrame={r_SkyLight_RealTimeReflectionCapture_TimeSlice_SkyCloudCubeFacePerFrame}");
        }

    }
}
