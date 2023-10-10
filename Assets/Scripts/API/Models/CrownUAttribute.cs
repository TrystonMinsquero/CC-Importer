using Newtonsoft.Json;

namespace API.Models
{
    public class CrownUAttribute
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("trait_type")]
        public string TraitType { get; set; }
    }
}