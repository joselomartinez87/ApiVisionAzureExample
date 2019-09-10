using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;

namespace Hx.Demo.CognitiveServices.Logic.Mappers
{
    internal class ModerationMapper : IModerationMapper
    {
        #region IModerationMapper Implementation Methods

        public Moderation Map(JToken container)
        {
            Moderation moderation = new Moderation();
            JToken adult = container["adult"];

            if (adult != null)
            {
                adult = adult.Value<JToken>();

                moderation.IsAdultContent = adult["isAdultContent"].Value<bool>();
                moderation.IsSpicyContent = adult["isRacyContent"].Value<bool>();
                moderation.AdultScore = adult["adultScore"].Value<decimal>();
                moderation.SpicyScore = adult["racyScore"].Value<decimal>();
            }
                
            return moderation;
        }

        #endregion
    }
}
