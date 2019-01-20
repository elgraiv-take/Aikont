using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Hhea
    {
        [XmlElement("tableVersion")]
        public ValueTag TableVersion { get; set; } = new ValueTag() { Value = "0x00010000" };
        [XmlElement("ascent")]
        public ValueTag Ascent { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("descent")]
        public ValueTag Descent { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("lineGap")]
        public ValueTag LineGap { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("caretSlopeRise")]
        public ValueTag CaretSlopeRise { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("caretSlopeRun")]
        public ValueTag CaretSlopeRun { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("caretOffset")]
        public ValueTag CaretOffset { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("reserved0")]
        public ValueTag Reserved0 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("reserved1")]
        public ValueTag Reserved1 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("reserved2")]
        public ValueTag Reserved2 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("reserved3")]
        public ValueTag Reserved3 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("metricDataFormat")]
        public ValueTag MetricDataFormat { get; set; } = new ValueTag() { Value = "0" };
    }
}
