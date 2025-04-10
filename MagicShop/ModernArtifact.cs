using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicShop
{
    public class ModernArtifact : Artifact
    { 
        public double TechLevel {  get; set; }
        public string Manufacturer {  get; set; }
        public override string Serialize() => $"Name: {Name} - ModernArtifact\n" +
            $"Power: {PowerLevel}\n" +
            $"TechLevel: {TechLevel}\n" +
            $"Manufacturer: {Manufacturer}";

        
    }
}
