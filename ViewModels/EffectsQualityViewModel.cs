using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public class EffectsQualityViewModel : QualityViewModel<EffectsQualitySettings>
    {
        private int refractionQualityIndex;

        public int RefractionQualityIndex
        {
            get { return refractionQualityIndex; }
            set { 
                refractionQualityIndex = value;
                this.OnPropertyChanged("RefractionQualityIndex");
            }
        }

        private float emitterSpawnRate;

        public float EmitterSpawnRate
        {
            get { return emitterSpawnRate; }
            set { 
                emitterSpawnRate = value;
                this.OnPropertyChanged("EmitterSpawnRate");
            }
        }

        private int particleLightingIndex;

        public int ParticleLightingIndex
        {
            get { return particleLightingIndex; }
            set { 
                particleLightingIndex = value;
                this.OnPropertyChanged("ParticleLightingIndex");
            }
        }

        private int particleQualityIndex;

        public int ParticleQualityIndex
        {
            get { return particleQualityIndex; }
            set
            {
                particleQualityIndex = value;
                this.OnPropertyChanged("ParticleQualityIndex");
            }
        }

        private int particleSimulation;

        public int ParticleSimulation
        {
            get { return particleSimulation; }
            set { 
                particleSimulation = value;
                this.OnPropertyChanged("ParticleSimulation");
            }
        }

        private bool particleRefractionAA;

        public bool ParticleRefractionAA
        {
            get { return particleRefractionAA; }
            set { 
                particleRefractionAA = value;
                this.OnPropertyChanged("ParticleRefractionAA");
            }
        }

        public override void PopulateSettingsModel()
        {
            Settings = new EffectsQualitySettings()
            {
                r_RefractionQuality = refractionQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 2
                },
                r_EmitterSpawnRateScale = emitterSpawnRate,
                r_ParticleLightQuality = particleLightingIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    _ => 2
                },
                fx_Niagara_QualityLevel = particleQualityIndex switch
                {
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    3 => 3,
                    _ => 3,
                },
                fx_Niagara_MaxAdvanceTicks = particleSimulation,
                r_Refraction_Blur_TemporalAA = particleRefractionAA ? 1 : 0
            };
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public EffectsQualityViewModel() : base("Effects: ")
        {
        }
    }
}