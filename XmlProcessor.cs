using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PracticalWork2
{
    [Serializable]
    public class XmlProcessor : IDataProcessor<AntiqueArtifact>  
    {
        public List<AntiqueArtifact> LoadData(string filePath)    // десерилизация из xml
        {
            var serializer = new XmlSerializer(typeof(XmlProcessor));

            using (StreamReader sr = new StreamReader(filePath))
            {
                try
                {
                    return (List<AntiqueArtifact>)serializer.Deserialize(sr);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public void SaveData(List<AntiqueArtifact> data, string filePath)  // серилизация в xml
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(filePath);

                foreach (AntiqueArtifact artifact in data)
                {
                    artifact.Id = Convert.ToInt32(artifact.Id);
                    artifact.Name = Convert.ToString(artifact.Name);
                    artifact.PowerLevel = Convert.ToInt32(artifact.PowerLevel);
                    artifact.Age = Convert.ToInt32(artifact.Age);
                    artifact.OriginRealm = Convert.ToString(artifact.OriginRealm);
                }

                doc.Save(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
