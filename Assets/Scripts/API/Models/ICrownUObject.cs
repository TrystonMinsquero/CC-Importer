using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace API.Models
{
    public interface ICrownUObject : ICrownUBaseObject
    {
        public string ObjectName { get; set; }
    }
}