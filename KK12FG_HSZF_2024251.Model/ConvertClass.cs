using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace KK12FG_HSZF_2024251.Model
{
    public class RootObject
    {
        [JsonProperty("animal")]
        public List<Animal> Animals { get; set; }
    }
}