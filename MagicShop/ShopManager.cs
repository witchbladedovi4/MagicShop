using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShop
{
    public class ShopManager
    {
        public List<Artifact> Artifacts { get; } = [];

        private void LoadData<T>(IDataProcessor<T> dataProcessor, string path)
            where T : Artifact
        {
            try
            {
                var data = dataProcessor.LoadData(path);
                if (data != null)
                {
                    if (data.Any())
                    {
                        Artifacts.AddRange(data.Cast<Artifact>());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
       
        public void LoadAllData()
        {
            try
            {
                LoadData(new XmlProcessor(), "Antique.xml");
                LoadData(new JsonProcessor(), "Modern.json");
                LoadData(new LegendaryProcessor(), "Legends.txt");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
        public void GenerateReport()
        {
            var report = new StringBuilder();
            report.AppendLine("Отчет по артефактам:");

            var byRarity = GroupByRarity();
            foreach (var rarity in byRarity)
            {
                report.AppendLine($"\nРедкость: {rarity.Key}");
                report.AppendLine($"\nРедкость: {rarity.Value}");

                var avgPower = Artifacts
                    .Where(a => a.Rarity == rarity.Key)
                    .Average(a => a.PowerLevel);
                report.AppendLine($"Максимальная сила: {avgPower}");

                var maxPower = Artifacts
                        .Where(a => a.Rarity == rarity.Key)
                        .Average(a => a.PowerLevel);
                report.AppendLine($"Максимальная сила: {maxPower}");
            }
            File.WriteAllText("report.txt", report.ToString());
        }
        public List<LegendaryArtifact> FindCursedAtrifacts()
        {
            return Artifacts.OfType<LegendaryArtifact>()
                .Where(a => a.IsCursed && a.PowerLevel > 50)
                .ToList();
        }

        public Dictionary<Rarity, int> GroupByRarity()
        {
            return Artifacts.GroupBy(x => x.Rarity)
                .ToDictionary(a => a.Key, a => a.Count());
        }

        public List<Artifact> TopByPower(int count)
        {
            return Artifacts.OrderByDescending(a => a.PowerLevel)
                .Take(count)
                .ToList ();
        }
    }
}
