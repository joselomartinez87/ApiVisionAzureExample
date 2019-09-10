using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;

namespace Hx.Demo.CognitiveServices.Logic.Mappers
{
    class BoxMapper : IBoxMapper
    {
        public Box Map(JToken container)
        {
            return new Box()
            {
                Top = container["top"].Value<int>(),
                Left = container["left"].Value<int>(),
                Width = container["width"].Value<int>(),
                Height = container["height"].Value<int>()
            };
        }
    }
}
