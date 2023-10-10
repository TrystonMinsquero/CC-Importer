using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Models
{
    public class CrownUBaseObject : ICrownUObject, ICrownUCharacter
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("object_name")]
        public string ObjectName { get; set; }
        
        [JsonProperty("character_name")]
        public string CharacterName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("job")]
        public int Job { get; set; }

        [JsonProperty("rarity")]
        public int Rarity { get; set; }

        [JsonProperty("asset_data")]
        public string AssetData { get; set; }

        [JsonProperty("attributes")]
        public List<CrownUAttribute> Attributes { get; set; }

        [JsonProperty("royalty_owners")]
        public List<string> RoyaltyOwners { get; set; }

        [JsonProperty("collaborators")]
        public List<string> Collaborators { get; set; }

        [JsonProperty("cid")]
        public string Cid { get; set; }

        [JsonProperty("organization")]
        public int Organization { get; set; }

        [JsonProperty("image_data")]
        public string ImageData { get; set; }

        [JsonProperty("isPack")]
        public bool IsPack { get; set; }

        [JsonProperty("filterId")]
        public int FilterId { get; set; }

        [JsonProperty("isCharacter")]
        public bool IsCharacter { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isOwned")]
        public bool IsOwned { get; set; }

        [JsonProperty("glbModel")]
        public bool GlbModel { get; set; }
        
        public virtual string GetName()
        {
            if (IsCharacter) return !string.IsNullOrEmpty(CharacterName) ? CharacterName : Name;
            if(!IsPack) return !string.IsNullOrEmpty(ObjectName) ? ObjectName : Name;
            return Name;
        }

        public virtual EntityType Type => IsCharacter ? EntityType.Character : EntityType.Object;
    }
}