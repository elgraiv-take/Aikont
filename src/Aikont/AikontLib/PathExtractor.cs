using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Elgraiv.Aikont
{
    public static class PathExtractor
    {
        public static string ExtractPath(GlyphSource source)
        {
            if (string.IsNullOrWhiteSpace(source.SvgFilePath))
            {
                return null;
            }
            if (!File.Exists(source.SvgFilePath))
            {
                return null;
            }
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(source.SvgFilePath);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"FAILED to load SVG file {source.SvgFilePath}:{e}");
                return null;
            }
            var root = xmlDoc.DocumentElement;
            if (!string.IsNullOrWhiteSpace(source.ObjectId))
            {
                root = Search(root, source.ObjectId);
            }
            var pathElement = root;
            if (pathElement.Name != "path")
            {
                pathElement = root.GetElementsByTagName("path").Cast<XmlElement>().FirstOrDefault();
            }
            return pathElement?.GetAttribute("d");
        }
        private static XmlElement Search(XmlElement element,string id)
        {
            if (element.GetAttribute("id") == id)
            {
                return element;
            }
            foreach(var child in element.ChildNodes)
            {
                if(child is XmlElement childElement)
                {
                    var result = Search(childElement, id);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }
    }

}
