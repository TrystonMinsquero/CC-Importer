using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Models
{
    public class CrownUInventoryResponse
    {
        [JsonProperty("inventory")] public CrownUInventory Inventory { get; set; }
    }

    public class CrownUInventory
    {
        [JsonProperty("characters")] public List<CrownUBaseObject> Characters { get; set; }

        [JsonProperty("objects")] public List<CrownUBaseObject> Objects { get; set; }

        [JsonProperty("packs")] public List<CrownUPack> Packs { get; set; }
    }
}