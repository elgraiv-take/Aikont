using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Cmap
    {
        [XmlElement("tableVersion")]
        public ValueVersion TableVersion { get; set; } = new ValueVersion() { Version = "0" };
        public class ValueVersion
        {
            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; } = string.Empty;
        }

        [XmlElement("cmap_format_4")]
        public CmapArray[] CmapFormat4 { get; set; } = new CmapArray[]
        {
            new CmapArray()
            {
                PlatformId = 0,
                PlatEncId = 3,
                Langage = 0,
            },
            new CmapArray()
            {
                PlatformId = 3,
                PlatEncId = 1,
                Langage = 0,
            },
        };

        public class CmapArray
        {
            [XmlAttribute(AttributeName = "platformID")]
            public int PlatformId { get; set; } = 0;
            [XmlAttribute(AttributeName = "platEncID")]
            public int PlatEncId { get; set; } = 0;
            [XmlAttribute(AttributeName = "language")]
            public int Langage { get; set; } = 0;

            [XmlElement("map")]
            public List<Map> Items { get; set; } = new List<Map>();
        }

        public class Map
        {
            [XmlAttribute("code")]
            public string Code { get; set; } = string.Empty;
            [XmlAttribute("name")]
            public string Name { get; set; } = string.Empty;
        }
    }
}
