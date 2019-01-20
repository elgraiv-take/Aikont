using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    public class Glyph
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public string Data { get; set; } = "endchar";
    }
}
