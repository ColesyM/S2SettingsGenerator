using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2SettingsGenerator
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class IniPropertyAttribute : System.Attribute
    {
        public string IniProperty { get; set; }
        public IniPropertyAttribute(string iniProperty)
        {
            this.IniProperty = iniProperty;
        }
    }
}
