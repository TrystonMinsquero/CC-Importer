using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Models
{
    public class CrownUPack : ICrownUPack
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("asset_data")]
        public string AssetData { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("organization")]
        public List<int> Organization { get; set; }

        [JsonProperty("job")]
        public List<int> Job { get; set; }

        [JsonProperty("isPack")]
        public bool IsPack { get; set; }

        [JsonProperty("filterId")]
        public int FilterId { get; set; }
        
        [JsonProperty("isOwned")]
        public bool IsOwned { get; set; }

        [JsonProperty("isCharacter")]
        public bool IsCharacter { get; set; }

        [JsonProperty("glbModel")]
        public bool GlbModel { get; set; }
        public string GetName() => Name;
        public EntityType Type => EntityType.Pack;
    }
}