using Elgraiv.Aikont.Ttx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Elgraiv.Aikont.Cli
{

    class Program
    {
        static void Main(string[] args)
        {
            Test(args);
        }

        public static void Test(string[] args)
        {
            var converter = new PathConverter()
            {
                Scale = 4,
                YOffset = 1000,
            };
            var svg="M139.183,64.943L173.406,119.377C173.406,119.377 180.143,77.608 184.455,63.865C188.766,50.122 201.162,26.139 217.061,25.061C232.96,23.983 243.2,38.535 241.044,47.697C238.888,56.859 223.528,210.728 219.486,218.004C215.444,225.28 175.293,224.202 175.023,213.962C174.754,203.722 139.453,193.482 126.518,171.655C118.014,184.633 93.103,202.644 90.408,211.806C87.714,220.968 51.335,224.472 49.448,208.842C47.562,193.213 23.04,77.069 18.189,66.291C13.339,55.512 19.806,45.541 32.202,39.613C44.598,33.684 54.568,39.343 61.844,54.434C67.234,70.872 83.672,126.383 83.672,126.383L105.499,64.943L139.183,64.943ZM108.733,126.922C114.548,113.987 116.547,96.472 125.709,95.663C134.872,94.855 135.835,117.502 142.417,132.312C149.962,149.288 169.903,180.278 171.251,184.32C148.345,174.888 125.171,149.288 125.171,149.288C125.171,149.288 100.918,180.278 89.6,180.547C86.905,160.876 105.166,134.856 108.733,126.922Z";
            var path = converter.Convert(svg);

            var ttx = new TtxRoot();
            ttx.AddGlyph(new Glyph()
            {
                Code = "0x57",
                Name = "dummy",
                Data = path,
                Width = 1000,
            });


            var serializer = new XmlSerializer(typeof(TtxRoot));
            using (var stream = new FileStream(args[0], FileMode.Create))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                serializer.Serialize(stream, ttx, ns);

            }
        }
    }
}
