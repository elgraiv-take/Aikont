using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class ValueTag
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; } = string.Empty;
    }
}
