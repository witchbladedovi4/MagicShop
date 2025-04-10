using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShop
{
    public class LegendaryProcessor : IDataProcessor<LegendaryArtifact>
    {
        public List<LegendaryArtifact> LoadData(string path)
        {
            var artifact = new List<LegendaryArtifact>();
            try
            {
                foreach (var i in File.ReadLines(path))
                {
                    var parts = i.Split('|');
                    if (parts.Length != 5) continue;

                    artifact.Add(new LegendaryArtifact
                    {
                        Name = parts[0],
                        PowerLevel = int.Parse(parts[1]),
                        Rarity = Enum.Parse<Rarity>(parts[2]),
                        CurseDescription = parts[3],
                        IsCursed = bool.Parse(parts[4]),
                    });
                }
                return artifact;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return artifact;
            }
        }

        public void SaveData(List<LegendaryArtifact> data, string parh)
        {
            var line = data.Select(x => $"{x.Name} | {x.Rarity} | {x.CurseDescription}|" +
            $"{x.IsCursed}");
            File.WriteAllLines(parh, line);
        }
    }
}
