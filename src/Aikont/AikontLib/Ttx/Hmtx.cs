using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Hmtx
    {
        [XmlElement("mtx")]
        public List<Mtx> HmtxTable { get; set; } = new List<Mtx>()
        {
            new Mtx(){Name=".notdef"}
        };
        public class Mtx
        {
            [XmlAttribute("name")]
            public string Name { get; set; } = string.Empty;
            [XmlAttribute("width")]
            public int Width { get; set; } = 256;
            [XmlAttribute("lsb")]
            public int Lsb { get; set; } = 0;
        }
    }
}
