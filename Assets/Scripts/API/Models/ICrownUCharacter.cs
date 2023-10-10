using System;
using System.Collections.Generic;

namespace API.Models
{
    public interface ICrownUCharacter : ICrownUBaseObject
    {
        public string CharacterName { get; set; }
    }
}