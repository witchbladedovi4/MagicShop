using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace MagicShop
{
    public class AntiqueArtifact : Artifact
    {
        public int Age {  get; set; }
        public string OriginRealm {  get; set; }

        public override string Serialize() => $"Name: {Name} - AntiqueArtifact\n" +
            $"Power: {PowerLevel}\n" +
            $"Age: {Age}\n" +
            $"OriginRealm: {OriginRealm}";
        
    }
}
