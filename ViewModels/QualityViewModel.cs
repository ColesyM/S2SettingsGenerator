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
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public QualityViewModel(string name)
        {
            this.settingsName = name;
            Settings = new T();
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

        private Nullable<Presets> preset;

        public Nullable<Presets> Preset
        {
            get { return preset; }
            set
            {
                preset = value;
                OnPropertyChanged("Preset");
                OnPropertyChanged("PresetString");
            }
        }

        public string PresetString
        {
            get { return (preset.HasValue ? preset.Value.ToString() : "Unset"); }
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
