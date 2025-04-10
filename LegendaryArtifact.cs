using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PracticalWork2
{
    public class LegendaryArtifact : Artifact
    {
        public string CurseDescription { get; set; }
        public bool IsCursed { get; set; }

        public override void Serialize(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"Name: {Name}, Id: {Id}, PowerLevel: {PowerLevel}, CurseDescription: {CurseDescription}, IsCursed: {IsCursed}");
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
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
