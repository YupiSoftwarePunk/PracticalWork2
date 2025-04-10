using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticalWork2.Artifact;

namespace PracticalWork2
{
    public class LegendaryProcessor : IDataProcessor<LegendaryArtifact>
    {
        public List<LegendaryArtifact> LoadData(string filePath)
        {

            try
            {
                List<LegendaryArtifact> data = new List<LegendaryArtifact>();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    var parts = line.Split('|');
                    data.Add(new LegendaryArtifact
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        PowerLevel = int.Parse(parts[2]),
                        rarity = Enum.Parse<Rarity>(parts[3]),
                        CurseDescription = parts[4],
                        IsCursed = bool.Parse(parts[5])
                    }
                    );
                }

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public void SaveData(List<LegendaryArtifact> data, string filePath)
        {
            try
            {
                foreach (var i in data)
                {
                    i.Serialize(filePath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
