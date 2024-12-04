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
       public int r_Streaming_MipBias=0;
       public float r_MipMapLODBias =0;

       public int r_MaxAnisotropy=8;
       public int r_VT_MaxAnisotropy = 8;

       public int r_Streaming_UseFixedPoolSize=1;
       public int r_Streaming_AmortizeCPUToGPUCopy=0;
       public int r_Streaming_MaxNumTexturesToStreamPerFrame=0;
       public int r_Streaming_Boost=1;
       public int r_Streaming_DropMips=0;
       public int r_Streaming_MaxEffectiveScreenSize=0;
       public int r_Streaming_LimitPoolSizeToVRAM = 1;
 
       public int r_Streaming_PoolSize = 3072;
       public int r_VT_PoolSizeScale_Group0=2; //; vk: 384MB(64 * 2 * 3) in total(on DXT1, BC5, BC7)
       public float r_VT_PoolSizeScale_Group1=0.2f; //; 51MB(64 * 0.2 * 4) in total(BC4, B8G8R8A8, FloatRGBA, G8)
       public float r_VT_PoolSizeScale_Group2 = 0.05f; //; 6.5MB total(128 * 0.05) (on RVT pool: DXT5, BC5, DXT1)
 
       public int r_VT_MaxUploadsPerFrame = 128;
       public int r_VT_MaxTilesProducedPerFrame = 128;

        public TextureQualitySettings()
        {

        }

        public void appendLines(StringBuilder sb)
        {
            sb.AppendLine($"r.Streaming.MipBias={r_Streaming_MipBias}");
            sb.AppendLine($"r.MipMapLODBias={r_MipMapLODBias}");

            sb.AppendLine($"r.MaxAnisotropy={r_MaxAnisotropy}");
            sb.AppendLine($"r.VT.MaxAnisotropy={r_VT_MaxAnisotropy}");

            sb.AppendLine($"r.Streaming.UseFixedPoolSize={r_Streaming_UseFixedPoolSize}");
            sb.AppendLine($"r.Streaming.AmortizeCPUToGPUCopy={r_Streaming_AmortizeCPUToGPUCopy}");
            sb.AppendLine($"r.Streaming.MaxNumTexturesToStreamPerFrame={r_Streaming_MaxNumTexturesToStreamPerFrame}");
            sb.AppendLine($"r.Streaming.Boost={r_Streaming_Boost}");
            sb.AppendLine($"r.Streaming.DropMips={r_Streaming_DropMips}");
            sb.AppendLine($"r.Streaming.MaxEffectiveScreenSize={r_Streaming_MaxEffectiveScreenSize}");
            sb.AppendLine($"r.Streaming.LimitPoolSizeToVRAM={r_Streaming_LimitPoolSizeToVRAM}");

            sb.AppendLine($"r.Streaming.PoolSize={r_Streaming_PoolSize}");
            sb.AppendLine($"r.VT.PoolSizeScale.Group0={r_VT_PoolSizeScale_Group0}");
            sb.AppendLine($"r.VT.PoolSizeScale.Group1={r_VT_PoolSizeScale_Group1}");
            sb.AppendLine($"r.VT.PoolSizeScale.Group2={r_VT_PoolSizeScale_Group2}");

            sb.AppendLine($"r.VT.MaxUploadsPerFrame={r_VT_MaxUploadsPerFrame}");
            sb.AppendLine($"r.VT.MaxTilesProducedPerFrame={r_VT_MaxTilesProducedPerFrame}");
        }
    }
}
