using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Ttx
{
    public class Os2
    {
        [XmlElement("version")]
        public ValueTag Version { get; set; } = new ValueTag() { Value = "4" };
        [XmlElement("xAvgCharWidth")]
        public ValueTag AvgCharWidth { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usWeightClass")]
        public ValueTag WeightClass { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usWidthClass")]
        public ValueTag WidthClass { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("fsType")]
        public ValueTag Type { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("fsSelection")]
        public ValueTag Selection { get; set; } = new ValueTag() { Value = "0" };


        [XmlElement("ySubscriptXSize")]
        public ValueTag SubscriptXSize { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySubscriptYSize")]
        public ValueTag SubscriptYSize { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySubscriptXOffset")]
        public ValueTag SubscriptXOffset { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySubscriptYOffset")]
        public ValueTag ySubscriptYOffset { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySuperscriptXSize")]
        public ValueTag SuperscriptXSize { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySuperscriptYSize")]
        public ValueTag SuperscriptYSize { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySuperscriptXOffset")]
        public ValueTag SuperscriptXOffset { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ySuperscriptYOffset")]
        public ValueTag SuperscriptYOffset { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("yStrikeoutSize")]
        public ValueTag StrikeoutSize { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("yStrikeoutPosition")]
        public ValueTag StrikeoutPosition { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("sFamilyClass")]
        public ValueTag FamilyClass { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("ulUnicodeRange1")]
        public ValueTag UnicodeRange1 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ulUnicodeRange2")]
        public ValueTag UnicodeRange2 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ulUnicodeRange3")]
        public ValueTag UnicodeRange3 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ulUnicodeRange4")]
        public ValueTag UnicodeRange4 { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("achVendID")]
        public ValueTag VendID { get; set; } = new ValueTag() { Value = "" };


        [XmlElement("usFirstCharIndex")]
        public ValueTag FirstCharIndex { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usLastCharIndex")]
        public ValueTag LastCharIndex { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usDefaultChar")]
        public ValueTag DefaultChar { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usBreakChar")]
        public ValueTag BreakChar { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usMaxContext")]
        public ValueTag MaxContext { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("sTypoAscender")]
        public ValueTag TypoAscender { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("sTypoDescender")]
        public ValueTag TypoDescender { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("sTypoLineGap")]
        public ValueTag TypoLineGap { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("usWinAscent")]
        public ValueTag WinAscent { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("usWinDescent")]
        public ValueTag WinDescent { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("ulCodePageRange1")]
        public ValueTag CodePageRange1 { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("ulCodePageRange2")]
        public ValueTag CodePageRange2 { get; set; } = new ValueTag() { Value = "0" };


        [XmlElement("sxHeight")]
        public ValueTag Height { get; set; } = new ValueTag() { Value = "0" };
        [XmlElement("sCapHeight")]
        public ValueTag CapHeight { get; set; } = new ValueTag() { Value = "0" };

        [XmlElement("panose")]
        public Panose PanoseTable { get; set; } = new Panose();

        public class Panose
        {
            [XmlElement("bFamilyType")]
            public ValueTag FamilyType { get; set; } = new ValueTag() { Value = "0" };

            [XmlElement("bSerifStyle")]
            public ValueTag SerifStyle { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bWeight")]
            public ValueTag Weight { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bProportion")]
            public ValueTag Proportion { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bContrast")]
            public ValueTag Contrast { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bStrokeVariation")]
            public ValueTag StrokeVariation { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bArmStyle")]
            public ValueTag ArmStyle { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bLetterForm")]
            public ValueTag LetterForm { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bMidline")]
            public ValueTag Midline { get; set; } = new ValueTag() { Value = "0" };
            [XmlElement("bXHeight")]
            public ValueTag XHeight { get; set; } = new ValueTag() { Value = "0" };
        }
    }
}
