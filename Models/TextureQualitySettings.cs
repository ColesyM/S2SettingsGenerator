using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.Models;

namespace S2SettingsGenerator
{
    public struct TextureQualitySettings : ISettingsModel
    {
        [IniPropertyAttribute("r.Streaming.MipBias")]
        public int r_Streaming_MipBias=0;
        [IniPropertyAttribute("r.MipMapLODBias")]
        public float r_MipMapLODBias =0;
        [IniPropertyAttribute("r.MaxAnisotropy")]
        public int r_MaxAnisotropy=8;
        [IniPropertyAttribute("r.VT.MaxAnisotropy")]
        public int r_VT_MaxAnisotropy = 8;
        [IniPropertyAttribute("r.Streaming.UseFixedPoolSize")]
        public int r_Streaming_UseFixedPoolSize=1;
        [IniPropertyAttribute("r.Streaming.AmortizeCPUToGPUCopy")]
        public int r_Streaming_AmortizeCPUToGPUCopy=0;
        [IniPropertyAttribute("r.Streaming.MaxNumTexturesToStreamPerFrame")]
        public int r_Streaming_MaxNumTexturesToStreamPerFrame=0;
        [IniPropertyAttribute("r.Streaming.Boost")]
        public int r_Streaming_Boost=1;
        [IniPropertyAttribute("r.Streaming.DropMips")]
        public int r_Streaming_DropMips=0;
        [IniPropertyAttribute("r.Streaming.MaxEffectiveScreenSize")]
        public int r_Streaming_MaxEffectiveScreenSize=0;
        [IniPropertyAttribute("r.Streaming.LimitPoolSizeToVRAM")]
        public int r_Streaming_LimitPoolSizeToVRAM = 1;
        [IniPropertyAttribute("r.Streaming.PoolSize")]
        public int r_Streaming_PoolSize = 3072;
        [IniPropertyAttribute("r.VT.PoolSizeScale.Group0")]
        public int r_VT_PoolSizeScale_Group0=2; //; vk: 384MB(64 * 2 * 3) in total(on DXT1, BC5, BC7)
        [IniPropertyAttribute("r.VT.PoolSizeScale.Group1")]
        public float r_VT_PoolSizeScale_Group1=0.2f; //; 51MB(64 * 0.2 * 4) in total(BC4, B8G8R8A8, FloatRGBA, G8)
        [IniPropertyAttribute("r.VT.PoolSizeScale.Group2")]
        public float r_VT_PoolSizeScale_Group2 = 0.05f; //; 6.5MB total(128 * 0.05) (on RVT pool: DXT5, BC5, DXT1)
        [IniPropertyAttribute("r.VT.MaxUploadsPerFrame")]
        public int r_VT_MaxUploadsPerFrame = 128;
        [IniPropertyAttribute("r.VT.MaxTilesProducedPerFrame")]
        public int r_VT_MaxTilesProducedPerFrame = 128;

        public TextureQualitySettings()
        {
        }
    }
}
