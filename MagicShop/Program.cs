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
                    "\n7)Экпортировать XML" +
                    "\n8)Выход");
                var chose = Console.ReadLine();
                switch ( chose )
                {
                    case "1":
                        ListArtifacts(ShopManager.Artifacts);
                        break;
                        
                }
                static void ListArtifacts(IEnumerable<Artifact> artifacts)
                {
                    Console.WriteLine("\nАртифакты:");
                    foreach (var artifact in artifacts)
                    {
                        Console.WriteLine(artifact.Serialize());
                    }
                    Console.WriteLine($"Всего: {artifacts.Count()}");
                }
            }
        }
    }
}
