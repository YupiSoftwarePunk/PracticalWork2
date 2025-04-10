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
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    foreach (AntiqueArtifact artifact in data)
                    {
                        artifact.Serialize(filePath);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
