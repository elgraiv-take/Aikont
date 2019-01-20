using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class GlyphOrder
    {
        [XmlElement(ElementName = "GlyphID")]
        public List<GlyphId> Ids { get; set; } = new List<GlyphId>()
        {
            new GlyphId(){Name=".notdef"}
        };

        public class GlyphId
        {
            [XmlAttribute(AttributeName ="name")]
            public string Name { get; set; } = string.Empty;
        }
    }
}
