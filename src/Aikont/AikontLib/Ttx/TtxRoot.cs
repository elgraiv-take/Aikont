using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    [XmlRoot(ElementName = "ttFont")]
    public class TtxRoot
    {
        [XmlAttribute("sfntVersion")]
        public string SfntVersion { get; set; } = "OTTO";

        [XmlElement("CFF")]
        public Cff CffTable { get; set; } = new Cff();

        [XmlElement("cmap")]
        public Cmap CmapTable { get; set; } = new Cmap();

        [XmlElement("GlyphOrder")]
        public GlyphOrder GlyphOrderTable { get; set; } = new GlyphOrder();

        [XmlElement("head")]
        public Head HeadTable { get; set; } = new Head();

        [XmlElement("hhea")]
        public Hhea HheaTable { get; set; } = new Hhea();

        [XmlElement("hmtx")]
        public Hmtx HmtxTable { get; set; } = new Hmtx();

        [XmlElement("maxp")]
        public Maxp MaxpTable { get; set; } = new Maxp();

        [XmlElement("name")]
        public Name NameTable { get; set; } = new Name();

        [XmlElement("OS_2")]
        public Os2 Os2Table { get; set; } = new Os2();

        [XmlElement("post")]
        public Post PostTable { get; set; } = new Post();
    }
}
