using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class AikontProject:BindableBase
    {
        public FontMetaData MetaData { get; } = new FontMetaData();
        public CommonData CommonData { get; } = new CommonData();
        public ObservableCollection<GlyphSource> Glyphs { get; } = new ObservableCollection<GlyphSource>();
    }
}
