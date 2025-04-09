using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork2
{
    public class ModernArtifact : Artifact
    {
        public double TechLevel { get; set; }
        public string Manufacturer { get; set; }

        public override void Serialize(string path)
        {
            string json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json);
        }


        public ModernArtifact(int id, string name, int powerLevel, double techLevel, string manufacturer)
            : base(id, name, powerLevel)
        {
            TechLevel = techLevel;
            Manufacturer = manufacturer;
        }
    }
}
