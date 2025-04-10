using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticalWork2
{
    public class AntiqueArtifact : Artifact
    {
        public int Age { get; set; }
        public string OriginRealm { get; set; }


        public override void Serialize(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AntiqueArtifact));
                serializer.Serialize(fs, this);
            }
        }


        public override string ExportToXml()
        {
            XmlSerializer xmlConverter = new XmlSerializer(typeof(AntiqueArtifact));
            StringBuilder xmlBuilder = new StringBuilder();

            using (TextWriter textWriter = new StringWriter(xmlBuilder))
            {
                xmlConverter.Serialize(textWriter, this);
            }

            return xmlBuilder.ToString();
        }


        public override string ExportToJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
