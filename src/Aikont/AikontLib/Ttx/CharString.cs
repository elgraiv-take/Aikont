using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class CharString
    {
        [XmlAttribute("name")]
        public string Name { get; set; } = string.Empty;
        [XmlText]
        public string Data { get; set; } = "endchar";
    }
}
