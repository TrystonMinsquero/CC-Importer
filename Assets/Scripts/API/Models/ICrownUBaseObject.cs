using System.Collections.Generic;

namespace API.Models
{
    // Parent of Both Character and Object, but not Pack (can't think of a better name)
    public interface ICrownUBaseObject : ICrownUEntity
    {
        public string Description { get; set; }
        public int Organization { get; set; }
        public int Rarity { get; set; }
        public List<string> Collaborators { get; set; }
        public List<string> RoyaltyOwners { get; set; }
        public List<CrownUAttribute> Attributes { get; set; }
        public string Cid { get; set; }
        public string ImageData { get; set; }
        public int Job { get; set; }
    }
}