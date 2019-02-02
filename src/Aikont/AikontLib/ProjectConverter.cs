using Elgraiv.Aikont.Ttx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont
{
    public static class ProjectConverter
    {
        public static void Convert(string projectPath, string outPath)
        {
            var project = new AikontProject();
            project.Load(projectPath);
            Convert(project,outPath);
        }

        public static void Convert(AikontProject project,string outPath)
        {
            var ttx = Convert(project);

            var serializer = new XmlSerializer(typeof(TtxRoot));
            using (var stream = new FileStream(outPath, FileMode.Create))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(stream, ttx, ns);

            }
        }

        public static TtxRoot Convert(AikontProject project)
        {
            var ttx = new TtxRoot();

            ttx.NameTable.Copyright = project.MetaData.Copyright;
            ttx.NameTable.FontFamilyName = $"{project.MetaData.Name} {project.MetaData.Style}";
            ttx.NameTable.FontSubfamilyName = project.MetaData.Style;
            ttx.NameTable.FontFullName = $"{project.MetaData.Name} {project.MetaData.Style}";
            ttx.NameTable.FontId = $"{project.MetaData.Name} {project.MetaData.Style} {project.MetaData.Version}";
            ttx.NameTable.Version = project.MetaData.Version;
            ttx.NameTable.PostScriptName = project.MetaData.PostScriptName;
            foreach (var glyph in project.Glyphs)
            {
                var pathConverter = new PathConverter()
                {
                    Scale = project.CommonData.Size / (glyph.Size ?? project.CommonData.DefaultImageSize),
                    YOffset = project.CommonData.Size

                };
                var svgPath = glyph.SvgPathData ?? PathExtractor.ExtractPath(glyph);
                var path = pathConverter.Convert(svgPath);
                ttx.AddGlyph(new Glyph()
                {
                    Name = glyph.Name,
                    Code = string.Format("0x{0:x}", glyph.Code),
                    Width = glyph.Width,
                    Data = path,
                }
                );
            }
            ttx.SetHeight(project.CommonData.Size);

            return ttx;
        }
    }
}
