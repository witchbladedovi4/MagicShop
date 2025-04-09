namespace MagicShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AntiqueArtifact artifact = new AntiqueArtifact();
            Console.WriteLine(artifact.ExportToXml());
        }
    }
}
