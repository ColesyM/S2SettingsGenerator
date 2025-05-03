using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.Models
{
    public struct FSRSettings : ISettingsModel
    {
        [IniPropertyAttribute("r.Velocity.EnableVertexDeformation")]
        public int r_Velocity_EnableVertexDeformation = 1;
        [IniPropertyAttribute("r.Velocity.EnableLandscapeGrass")]
        public bool r_Velocity_EnableLandscapeGrass = true;
        [IniPropertyAttribute("r.FidelityFX.FSR3.QualityMode")]
        public int r_FidelityFX_FSR3_QualityMode = 0;
        [IniPropertyAttribute("r.FidelityFX.FSR3.ForceLandscapeHISMMobility")]
        public int r_FidelityFX_FSR3_ForceLandscapeHISMMobility = 0;
        [IniPropertyAttribute("r.FidelityFX.FSR3.AutoExposure")]
        public int r_FidelityFX_FSR3_AutoExposure = 0;
        [IniPropertyAttribute("r.FidelityFX.FSR3.UseNativeDX12")]
        public int r_FidelityFX_FSR3_UseNativeDX12 = 1;
        [IniPropertyAttribute("r.FidelityFX.FSR3.AdjustMipBias")]
        public int r_FidelityFX_FSR3_AdjustMipBias = 1;
        [IniPropertyAttribute("r.FidelityFX.FSR3.Sharpness")]
        public float r_FidelityFX_FSR3_Sharpness = 0.1f;
        [IniPropertyAttribute("r.FidelityFX.FSR3.UseSSRExperimentalDenoiser")]
        public int r_FidelityFX_FSR3_UseSSRExperimentalDenoiser = 1;
        [IniPropertyAttribute("r.FidelityFX.FSR3.UseRHI")]
        public int r_FidelityFX_FSR3_UseRHI = 1;
        [IniPropertyAttribute("r.FidelityFX.FSR3.DeDither")]
        public int r_FidelityFX_FSR3_DeDither = 1;

        public FSRSettings()
        {
        }
    }
}
