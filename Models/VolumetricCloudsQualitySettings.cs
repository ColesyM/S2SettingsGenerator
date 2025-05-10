using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.Models
{
    public struct VolumetricCloudsQualitySettings: ISettingsModel
    {
        [IniPropertyAttribute("r.VolumetricCloud.SkyAO")]
        public int r_VolumetricCloud_SkyAO = 1;
        [IniPropertyAttribute("r.VolumetricCloud.SkyAO.MaxResolution")]
        public int r_VolumetricCloud_SkyAO_MaxResolution = 128;
        [IniPropertyAttribute("r.VolumetricCloud.ViewRaySampleMaxCount")]
        public int r_VolumetricCloud_ViewRaySampleMaxCount = 196;
        [IniPropertyAttribute("r.VolumetricCloud.ReflectionRaySampleMaxCount")]
        public int r_VolumetricCloud_ReflectionRaySampleMaxCount = 60;
        [IniPropertyAttribute("r.VolumetricCloud.Shadow.ViewRaySampleMaxCount")]
        public int r_VolumetricCloud_Shadow_ViewRaySampleMaxCount = 4;


        public VolumetricCloudsQualitySettings()
        {

        }
    }
}
