using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class IdentityData
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("sub")]
        public string Sub { get; set; }
    }

    public class Identity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("identity_data")]
        public IdentityData IdentityData { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("last_sign_in_at")]
        public DateTime LastSignInAt { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class AppMetadata
    {
        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("providers")]
        public List<string> Providers { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("aud")]
        public string Aud { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("email_confirmed_at")]
        public DateTime EmailConfirmedAt { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("confirmation_sent_at")]
        public DateTime ConfirmationSentAt { get; set; }

        [JsonProperty("confirmed_at")]
        public DateTime ConfirmedAt { get; set; }

        [JsonProperty("last_sign_in_at")]
        public DateTime LastSignInAt { get; set; }

        [JsonProperty("app_metadata")]
        public AppMetadata AppMetadata { get; set; }

        [JsonProperty("user_metadata")]
        public Dictionary<string, string> UserMetadata { get; set; }

        [JsonProperty("identities")]
        public List<Identity> Identities { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }

    public class UserAssets
    {
        [JsonProperty("characters")]
        public List<int> Characters { get; set; }

        [JsonProperty("objects")]
        public List<int> Objects { get; set; }
    }

    public class PackDetails
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

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class CrownUOpenPackResponse
    {
        [JsonProperty("user")]
        public UserInfo User { get; set; }

        [JsonProperty("userAssets")]
        public UserAssets UserAssets { get; set; }

        [JsonProperty("assets")]
        public List<List<int>> Assets { get; set; }

        [JsonProperty("updateAssets")]
        public string UpdateAssets { get; set; }

        [JsonProperty("pack")]
        public PackDetails Pack { get; set; }

        [JsonProperty("updatePacks")]
        public string UpdatePacks { get; set; }
    }
}