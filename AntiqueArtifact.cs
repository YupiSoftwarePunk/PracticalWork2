using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork2
{
    public class AntiqueArtifact : Artifact
    {
        public int Age { get; set; }
        public string OriginRealm { get; set; }

        public override void Serialize()
        {
            using (FileStream fs = new FileStream("antique_artifact.xml", FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs);
            }
        }


        public AntiqueArtifact(int id, string name, int powerLevel, int age, string originRealm)
            : base(id, name, powerLevel)
        {
            Age = age;
            OriginRealm = originRealm;
        }
    }
}
