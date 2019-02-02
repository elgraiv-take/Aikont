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
        public NameRecord[] Records { get; set; } = new NameRecord[]
        {
            new NameRecord(0,1,0,0),
            new NameRecord(1,1,0,0),
            new NameRecord(2,1,0,0),
            new NameRecord(3,1,0,0),
            new NameRecord(4,1,0,0),
            new NameRecord(5,1,0,0),
            new NameRecord(6,1,0,0),
            new NameRecord(0,3,1,0),
            new NameRecord(1,3,1,0),
            new NameRecord(2,3,1,0),
            new NameRecord(3,3,1,0),
            new NameRecord(4,3,1,0),
            new NameRecord(5,3,1,0),
            new NameRecord(6,3,1,0),
        };

        [XmlIgnore]
        public string Copyright
        {
            get => Records.First(r => r.NameId == 0).Data;
            set => UpdateRecord(0, value);
        }

        [XmlIgnore]
        public string FontFamilyName
        {
            get => Records.First(r => r.NameId == 1).Data;
            set => UpdateRecord(1, value);
        }

        [XmlIgnore]
        public string FontSubfamilyName
        {
            get => Records.First(r => r.NameId == 2).Data;
            set => UpdateRecord(2, value);
        }

        [XmlIgnore]
        public string FontId
        {
            get => Records.First(r => r.NameId == 3).Data;
            set => UpdateRecord(3, value);
        }

        [XmlIgnore]
        public string FontFullName
        {
            get => Records.First(r => r.NameId == 4).Data;
            set => UpdateRecord(4, value);
        }

        [XmlIgnore]
        public string Version
        {
            get => Records.First(r => r.NameId == 5).Data;
            set => UpdateRecord(5, value);
        }

        [XmlIgnore]
        public string PostScriptName
        {
            get => Records.First(r => r.NameId == 6).Data;
            set => UpdateRecord(6, value);
        }

        private void UpdateRecord(int id,string value)
        {
            foreach (var record in Records.Where(r => r.NameId == id))
            {
                record.Data = value;
            }
        }

        public class NameRecord
        {
            [XmlAttribute(AttributeName = "nameID")]
            public int NameId { get; set; }
            [XmlAttribute(AttributeName = "platformID")]
            public int PlatformId { get; set; }
            [XmlAttribute(AttributeName = "platEncID")]
            public int PlatEncId { get; set; }
            [XmlAttribute(AttributeName = "langID")]
            public int Langage { get; set; }

            public NameRecord(int nameid,int platformId,int platEncId,int langage)
            {
                NameId = nameid;
                PlatformId = platformId;
                PlatEncId = platEncId;
                Langage = langage;
            }
            private NameRecord() { }

            [XmlText]
            public string Data { get; set; } = "dummy";
        }
    }
}
