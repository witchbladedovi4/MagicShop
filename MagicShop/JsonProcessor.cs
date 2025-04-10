using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MagicShop
{
    public class JsonProcessor : IDataProcessor<ModernArtifact>
    {
        public List<ModernArtifact> LoadData(string path)
        {
            try
            {
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<ModernArtifact>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ModernArtifact>();
            }
        }

        public void SaveData(List<ModernArtifact> data, string path)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
