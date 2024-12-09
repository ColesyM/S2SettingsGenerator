using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct SkyQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.SkyAtmosphere.AerialPerspectiveLUT.FastApplyOnOpaque")]
        public int r_SkyAtmosphere_AerialPerspectiveLUT_FastApplyOnOpaque=1; //; Always have FastSkyLUT 1 in this case to avoid wrong sky
        [IniPropertyAttribute("r.SkyAtmosphere.AerialPerspectiveLUT.SampleCountMaxPerSlice")]
        public int r_SkyAtmosphere_AerialPerspectiveLUT_SampleCountMaxPerSlice=4;
        [IniPropertyAttribute("r.SkyAtmosphere.AerialPerspectiveLUT.DepthResolution")]
        public float r_SkyAtmosphere_AerialPerspectiveLUT_DepthResolution=16.0f;
        [IniPropertyAttribute("r.SkyAtmosphere.FastSkyLUT")]
        public int r_SkyAtmosphere_FastSkyLUT = 1;
        [IniPropertyAttribute("r.SkyAtmosphere.FastSkyLUT.SampleCountMin")]
        public float r_SkyAtmosphere_FastSkyLUT_SampleCountMin =4.0f;
        [IniPropertyAttribute("r.SkyAtmosphere.FastSkyLUT.SampleCountMax")]
        public float r_SkyAtmosphere_FastSkyLUT_SampleCountMax =128.0f;
        [IniPropertyAttribute("r.SkyAtmosphere.SampleCountMin")]
        public float r_SkyAtmosphere_SampleCountMin = 4.0f;
        [IniPropertyAttribute("r.SkyAtmosphere.SampleCountMax")]
        public float r_SkyAtmosphere_SampleCountMax = 128.0f;
        [IniPropertyAttribute("r.SkyAtmosphere.TransmittanceLUT.UseSmallFormat")]
        public int r_SkyAtmosphere_TransmittanceLUT_UseSmallFormat=0;
        [IniPropertyAttribute("r.SkyAtmosphere.TransmittanceLUT.SampleCount")]
        public float r_SkyAtmosphere_TransmittanceLUT_SampleCount =10.0f;
        [IniPropertyAttribute("r.SkyAtmosphere.MultiScatteringLUT.SampleCount")]
        public float r_SkyAtmosphere_MultiScatteringLUT_SampleCount =15.0f;
        [IniPropertyAttribute("r.SkyLight.RealTimeReflectionCapture")]
        public int r_SkyLight_RealTimeReflectionCapture = 1;
        [IniPropertyAttribute("r.SkyLight.RealTimeReflectionCapture.TimeSlice.SkyCloudCubeFacePerFrame")]
        public int r_SkyLight_RealTimeReflectionCapture_TimeSlice_SkyCloudCubeFacePerFrame=6;

        public SkyQualitySettings()
        {
        }
    }
}
