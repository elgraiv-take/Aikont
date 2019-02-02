using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class FontMetaData:BindableBase
    {

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _style;
        public string Style
        {
            get => _style;
            set => SetProperty(ref _style, value);
        }

        private string _copyright;
        public string Copyright
        {
            get => _copyright;
            set => SetProperty(ref _copyright, value);
        }

        private string _version;
        public string Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }
        private string _postScriptName;
        public string PostScriptName
        {
            get => _postScriptName;
            set => SetProperty(ref _postScriptName, value);
        }
    }
}
