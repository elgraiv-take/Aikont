using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Maxp
    {
        [XmlElement(ElementName = "tableVersion")]
        public ValueTag TableVersion { get; set; } = new ValueTag() { Value = "0x5000" };
    }
}
