using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S2SettingsGenerator
{
    /// <summary>
    /// Interaction logic for LockableExpanderHeader.xaml
    /// </summary>
    public partial class LockableExpanderHeader : UserControl
    {
        public LockableExpanderHeader()
        {
            InitializeComponent();
        }

        private void sldrSectionPreset_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var presetIndex = System.Convert.ToInt32(e.NewValue);
            Presets preset = (Presets)presetIndex;

            if (lblCurrentSectionPreset != null)
            {
                lblCurrentSectionPreset.Content = preset.ToString().Replace("_", "");
            }
        }
    }
}
