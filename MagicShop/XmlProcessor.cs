using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicShop
{
    public class XmlProcessor : IDataProcessor<AntiqueArtifact>
    {
        public List<AntiqueArtifact> LoadData(string path)
        {
            try
            {
                var serialize = new XmlSerializer(typeof(List<AntiqueArtifact>));
                using var reader = new StreamReader(path);
                return (List<AntiqueArtifact>)serialize.Deserialize(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<AntiqueArtifact>();
            }
        }

        public void SaveData(List<AntiqueArtifact> data, string path)
        {

        }
    }
}
