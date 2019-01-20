using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Cff
    {
        [XmlElement("major")]
        public ValueTag Major { get; set; } = new ValueTag() { Value = "1" };
        [XmlElement("minor")]
        public ValueTag Minor { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("CFFFont")]
        public CffFont Data { get; set; } = new CffFont();

        public class CffFont
        {
            [XmlAttribute("name")]
            public string Name { get; set; } = "NewFont";

            [XmlElement("Private")]
            public Private Private { get; set; } = new Private();

            [XmlArray("CharStrings")]
            [XmlArrayItem("CharString")]
            public List<CharString> CharStrings { get; set; } = new List<CharString>()
            {
                new CharString()
                {
                    Name=".notdef"
                }
            };

        }

        public class Private
        {
            [XmlArray("Subrs")]
            [XmlArrayItem("CharString")]
            public List<CharString> CharStrings { get; set; } = new List<CharString>()
            {
                new CharString(){Data="return"},
            };
        }
    }
}
