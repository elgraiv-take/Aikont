using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elgraiv.Aikont
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AikontProject:BindableBase
    {
        [JsonProperty]
        public ProjectSettings Settings { get; } = new ProjectSettings();
        [JsonProperty]
        public FontMetaData MetaData { get; } = new FontMetaData();
        [JsonProperty]
        public CommonData CommonData { get; } = new CommonData();
        [JsonProperty]
        public ObservableCollection<GlyphSource> Glyphs { get; } = new ObservableCollection<GlyphSource>();


        public void Save(string path)
        {
            var serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using(var writer=new StreamWriter(path))
            {
                serializer.Serialize(writer, this);
            }
        }
        public void Load(string path)
        {
            var serializer = new JsonSerializer();
            using(var reader=new StreamReader(path))
            {
                serializer.Populate(reader, this);
            }
        }
    }
}
