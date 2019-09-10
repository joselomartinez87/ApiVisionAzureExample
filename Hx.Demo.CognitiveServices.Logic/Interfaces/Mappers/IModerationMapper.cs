using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;

namespace Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers
{
    public interface IModerationMapper
    {
        Moderation Map(JToken container);
    }
}
