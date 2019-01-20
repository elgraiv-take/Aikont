using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Name
    {
        [XmlElement("namerecord")]
        public NameRecord[] Records = new NameRecord[]
        {
            new NameRecord(){NameId=0,PlatformId=3,PlatEncId=1,Langage=0},
            new NameRecord(){NameId=1,PlatformId=3,PlatEncId=1,Langage=0},
            new NameRecord(){NameId=2,PlatformId=3,PlatEncId=1,Langage=0},
            new NameRecord(){NameId=3,PlatformId=3,PlatEncId=1,Langage=0},
            new NameRecord(){NameId=4,PlatformId=3,PlatEncId=1,Langage=0},
            new NameRecord(){NameId=5,PlatformId=3,PlatEncId=1,Langage=0},
            new NameRecord(){NameId=6,PlatformId=3,PlatEncId=1,Langage=0},
        };
        public class NameRecord
        {
            [XmlAttribute(AttributeName = "nameID")]
            public int NameId { get; set; } = 0;
            [XmlAttribute(AttributeName = "platformID")]
            public int PlatformId { get; set; } = 0;
            [XmlAttribute(AttributeName = "platEncID")]
            public int PlatEncId { get; set; } = 0;
            [XmlAttribute(AttributeName = "langID")]
            public int Langage { get; set; } = 0;
            [XmlText]
            public string Data { get; set; } = "dummy";
        }
    }
}
