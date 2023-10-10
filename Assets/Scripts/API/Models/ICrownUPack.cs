using System;
using System.Collections.Generic;

namespace API.Models
{
    public interface ICrownUPack : ICrownUEntity
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public List<int> Organization { get; set; }
    }
}