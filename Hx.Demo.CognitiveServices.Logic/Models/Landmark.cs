using Newtonsoft.Json;

namespace Hx.Demo.CognitiveServices.Logic.Models
{
    public class Landmark
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName ="x")]
        public decimal X { get; set; }

        [JsonProperty(PropertyName = "y")]
        public decimal Y { get; set; }
    }
}