using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MagicShop
{
    public class LegendaryArtifact : Artifact
    {
        public string CurseDescription { get; set; }
        public bool IsCursed { get; set; }
        public override string Serialize() => $"Name: {Name} - LegendaryArtifact\n"  +
            $"Power: {PowerLevel}\n" +
            $"Cures: {IsCursed}\n" +
            $"Cursed: {CurseDescription}";
        
    }
}
