using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork2
{
    public class LegendaryArtifact : Artifact
    {
        public string CurseDescription { get; set; }
        public bool IsCursed { get; set; }

        string path = "Legendary_artifact.txt";
        public override void Serialize()
        {
            using (StreamWriter sw = new StreamWriter(path, true))  // true - Означает что текст добавляется в конец уже написанного текста
            {
                sw.WriteLine();
            }
        }

        public LegendaryArtifact(int id, string name, int powerLevel, string curseDescription, bool isCursed, string path)
            : base(id, name, powerLevel)
        {
            CurseDescription = curseDescription;
            IsCursed = isCursed;
            this.path = path;
        }
    }
}
