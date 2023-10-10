using System;
using System.Collections.Generic;

namespace API.Models
{
    public interface ICrownUEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string AssetData { get; set; }
        public bool IsOwned { get; set; }
        public bool IsCharacter { get; set; }
        public bool IsPack { get; set; }
        public bool GlbModel { get; set; }
        public int FilterId { get; set; }

        public string GetName();

        public EntityType Type { get; }

    }
}