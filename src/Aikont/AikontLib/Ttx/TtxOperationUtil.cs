using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont.Ttx
{
    public static class TtxOperationUtil
    {
        public static void AddGlyph(this TtxRoot root, Glyph glyph)
        {
            foreach(var format in root.CmapTable.CmapFormat4)
            {
                format.Items.Add(
                new Cmap.Map()
                {
                    Code = glyph.Code,
                    Name = glyph.Name
                }
                );
            }
            root.HmtxTable.HmtxTable.Add(
                new Hmtx.Mtx()
                {
                    Name = glyph.Name,
                    Lsb = 0,
                    Width = glyph.Width,
                }
                );
            root.CffTable.Data.CharStrings.Add(
                new CharString()
                {
                    Name = glyph.Name,
                    Data = glyph.Data
                }
                );
            root.GlyphOrderTable.Ids.Add(
                new GlyphOrder.GlyphId()
                {
                    Name = glyph.Name
                }
                );
        }
    }
}
