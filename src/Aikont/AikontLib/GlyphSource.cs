using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class GlyphSource : BindableBase
    {
        private uint _code;
        public uint Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _width;
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        private string _svgFilePath;
        public string SvgFilePath
        {
            get => _svgFilePath;
            set => SetProperty(ref _svgFilePath, value);
        }

        private string _xPath;
        public string XPath
        {
            get => _xPath;
            set => SetProperty(ref _xPath, value);
        }

        private float? _size;
        public float? Size
        {
            get => _size;
            set => SetProperty(ref _size, value);
        }
    }
}
