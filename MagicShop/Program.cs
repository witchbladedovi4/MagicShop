using Newtonsoft.Json;
using System.ComponentModel;

namespace MagicShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ShopManager = new ShopManager();
            ShopManager.LoadAllData();
            Console.WriteLine("AJAJAJJA");
            Console.WriteLine($"Загружено {ShopManager.Artifacts.Count} артифактов");
            while (true)
            {
                Console.WriteLine("\nМеню:" +
                    "\n1)Показать все артифакты" +
                    "\n2)Найти проклятые артифакты (Сила > 50)" +
                    "\n3)Сгрупировать по раритетности" +
                    "\n4)Показать артифакты по силе" +
                    "\n5)Сгененировать report.txt" +
                    "\n6)Экпортировать JSON" +
                    "\n7)Выход");
                var chose = Console.ReadLine();
                switch ( chose )
                {
                    case "1":
                        ListArtifacts(ShopManager.Artifacts);
                        break;

                    case "2":
                        var cursed = ShopManager.FindCursedAtrifacts(); 
                        Console.WriteLine($"Найдено {cursed.Count} проклятых артефактов:");
                        foreach (var item in cursed)
                        {
                            Console.WriteLine($"- {item.Name} (Сила: {item.PowerLevel}, Проклятие: {item.CurseDescription})");
                        }

                        File.WriteAllText("cursed_artifacts.json",
                            JsonConvert.SerializeObject(cursed, Formatting.Indented));
                       
                        break;
                    case "3":
                        var byRarity = ShopManager.GroupByRarity();
                        foreach (var group in byRarity)
                        {
                            Console.WriteLine($"{group.Key}: {group.Value} шт.");
                        }
                        break;

                    case "4":

                            var top = ShopManager.TopByPower();
                            Console.WriteLine($"Топ  артефактов по силе:");
                            foreach (var item in top)
                            {
                                Console.WriteLine($"- {item.Name} (Сила: {item.PowerLevel}, Редкость: {item.Rarity})");
                            }
                        
                        break;
                    case "5":

                        ShopManager.GenerateReport();
                        Console.WriteLine("Отчет сохранен в файл report.txt");
                        break;

                    case "6":
                        File.WriteAllText("artifacts.json",
                            JsonConvert.SerializeObject(ShopManager.Artifacts, Formatting.Indented));
                        Console.WriteLine("Результаты сохранены в cursed_artifacts.json");
                        break;
                    case "7":
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
                static void ListArtifacts(IEnumerable<Artifact> artifacts)
                {
                    Console.WriteLine("\nАртифакты:");
                    foreach (var artifact in artifacts)
                    {
                        Console.WriteLine(artifact.Serialize()+'\n');
                    }
                    Console.WriteLine($"Всего: {artifacts.Count()}");
                }
            }
        }
    }
}
