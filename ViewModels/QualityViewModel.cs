using S2SettingsGenerator.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
            if (Settings == null)
            {
                sb.AppendLine($";--ERROR EXPORTING {SettingsName}--");
                return;
            }

            sb.AppendLine();
            sb.AppendLine($";--{SettingsName}--");

            foreach (FieldInfo prop in Settings.GetType().GetFields())
            {
                var iniAttribute = prop.GetCustomAttribute<IniPropertyAttribute>(false);

                if (iniAttribute != null)
                {
                    var typeOfField = prop.FieldType.Name;
                    string fieldValueStr;
                    Debug.WriteLine(typeOfField);
                    switch (typeOfField)
                    {
                        case "Single":
                            var preciseFloatStr = $"{(float)prop.GetValue(Settings)!:F7}".TrimEnd(['0']);
                            fieldValueStr = preciseFloatStr.EndsWith('.') ? $"{preciseFloatStr}0" : preciseFloatStr;
                            break;
                        case "Int32":
                        default:
                            fieldValueStr = $"{prop.GetValue(Settings)}";
                            break;
                    }

                    if (iniAttribute.IniProperty.Contains('='))
                    {
                        throw new CustomAttributeFormatException($"ini property should not container = {iniAttribute.IniProperty}");
                    }

                    if (iniAttribute.IniProperty.Contains('_'))
                    {
                        throw new CustomAttributeFormatException($"ini property should not container _ {iniAttribute.IniProperty}");
                    }

                    var expectedIni = prop.Name.Replace('_', '.');

                    if (expectedIni != iniAttribute.IniProperty)
                    {
                        throw new CustomAttributeFormatException($"{expectedIni} != {iniAttribute.IniProperty}");
                    }

                    sb.AppendLine($"{iniAttribute.IniProperty}={fieldValueStr}");
                }
            }
        }
    }
}
