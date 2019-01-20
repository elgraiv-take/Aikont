using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Head
    {
        [XmlElement("tableVersion")]
        public ValueTag TableVersion { get; set; } = new ValueTag() { Value = "1.0" };
        [XmlElement("fontRevision")]
        public ValueTag FontRevision { get; set; } = new ValueTag() { Value = "0.0" };
        [XmlElement("checkSumAdjustment")]
        public ValueTag CheckSumAdjustment { get; set; } = new ValueTag() { Value = "0x0" };
        [XmlElement("magicNumber")]
        public ValueTag MagicNumber { get; set; } = new ValueTag() { Value = "0x5F0F3CF5" };
        [XmlElement("flags")]
        public ValueTag Flags { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("unitsPerEm")]
        public ValueTag UnitsPerEm { get; set; } = new ValueTag() { Value = "1000" };
        [XmlElement("created")]
        public ValueTag Created { get; set; } = new ValueTag() { Value = "Mon Jan 1 00:00:00 2000" };
        [XmlElement("macStyle")]
        public ValueTag MacStyle { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("lowestRecPPEM")]
        public ValueTag LowestRecPpem { get; set; } = new ValueTag() { Value = "16" };
        [XmlElement("fontDirectionHint")]
        public ValueTag FontDirectionHint { get; set; } = new ValueTag() { Value = "2" };
        [XmlElement("indexToLocFormat")]
        public ValueTag IndexToLocFormat { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("glyphDataFormat")]
        public ValueTag GlyphDataFormat { get; set; } = new ValueTag() { Value = "0" };
    }
}
