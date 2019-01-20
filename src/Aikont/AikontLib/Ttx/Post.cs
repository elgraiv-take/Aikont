using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Post
    {
        [XmlElement("formatType")]
        public ValueTag FormatType { get; set; } = new ValueTag() { Value = "3.0" };
        [XmlElement("italicAngle")]
        public ValueTag ItalicAngle { get; set; } = new ValueTag() { Value = "0.0" };
        [XmlElement("underlinePosition")]
        public ValueTag UnderlinePosition { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("underlineThickness")]
        public ValueTag UnderlineThickness { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("isFixedPitch")]
        public ValueTag IsFixedPitch { get; set; } = new ValueTag() { Value = "0" };


        [XmlElement("minMemType42")]
        public ValueTag MinMemType42 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("maxMemType42")]
        public ValueTag MaxMemType42 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("minMemType1")]
        public ValueTag MinMemType1 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("maxMemType1")]
        public ValueTag MaxMemType1 { get; set; } = new ValueTag() { Value = "0" };
    }
}
