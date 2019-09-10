using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hx.Demo.CognitiveServices.Logic.Models
{
    public class JsonResult
    {
        public string Name { get; set; }
        public string Time { get; set; }
        public JToken Json { get; set; }

        [JsonIgnore]
        public string JsonContent { get; set; }
    }
}