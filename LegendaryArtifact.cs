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

        public override void Serialize(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"Name: {Name}, Id: {Id}, PowerLevel: {PowerLevel}, CurseDescription: {CurseDescription}, IsCursed: {IsCursed}");
            }
        }

    }
}
