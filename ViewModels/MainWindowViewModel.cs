using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S2SettingsGenerator.ViewModels;

namespace S2SettingsGenerator
{
    public class MainWindowViewModel : ViewModel
    {
		public MainWindowViewModel()
		{
			this.aaQualitySettings = new AntiAliasingQualityViewModel();

        }

        private AntiAliasingQualityViewModel aaQualitySettings;

		public AntiAliasingQualityViewModel AAQualitySettings
        {
			get { return aaQualitySettings; }
			set 
			{ 
				aaQualitySettings = value;
				OnPropertyChanged("AAQualitySettings");
			}
		}

        private Presets currentPreset;

        public Presets CurrentPreset
        {
            get { return currentPreset; }
            set
            {
                currentPreset = value;
                OnPropertyChanged("CurrentPreset");
            }
        }

    }
}
