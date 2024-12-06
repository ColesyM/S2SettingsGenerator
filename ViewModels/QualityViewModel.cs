using S2SettingsGenerator.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator.ViewModels
{
    public abstract class QualityViewModel<T> : ViewModel where T: ISettingsModel, new()
    {
        private int presetIndex;

        public int PresetIndex
        {
            get { return presetIndex; }
            set { 
                presetIndex = value;
                OnPropertyChanged("PresetIndex");
                preset = (Presets)presetIndex;
                OnPropertyChanged("Preset");
            }
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public QualityViewModel(string name)
        {
            this.settingsName = name;
            Settings = new T();

            this.PresetIndex = (int)Presets.EPIC;
        }

        protected T Settings { get; set; }

        public required string settingsName;

        public string SettingsName
        {
            get { return settingsName; }
            set
            {
                settingsName = value;
                OnPropertyChanged("SettingsName");
            }
        }

        private bool presetLocked;

        public bool PresetLocked
        {
            get { return presetLocked; }
            set
            {
                presetLocked = value;
                OnPropertyChanged("PresetLocked");
            }
        }

        private Presets preset;

        public Presets Preset
        {
            get { return preset; }
            set
            {
                PresetIndex = (int)value;
            }
        }

        public abstract void PopulateSettingsModel();

        public void AddSettingsStrings(StringBuilder sb)
        {
            sb.AppendLine();
            sb.AppendLine($";--{SettingsName}--");
            Settings.appendLines(sb);
        }
    }
}
