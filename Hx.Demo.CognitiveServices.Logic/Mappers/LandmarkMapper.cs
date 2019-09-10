using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Hx.Demo.CognitiveServices.Logic.Mappers
{
    internal class LandmarkMapper : ILandmarkMapper
    {
        #region ILandmarkMapper Implementation Methods

        public List<Landmark> Map(JToken container)
        {
            List<Landmark> landmarks = new List<Landmark>();

            JToken faceLandmarks = container["faceLandmarks"];

            if (faceLandmarks != null)
            {
                faceLandmarks = faceLandmarks.Value<JToken>();

                foreach (JToken item in faceLandmarks)
                {
                    var currentLandmark = ((JProperty)item);

                    Landmark landmark = new Landmark()
                    {
                        Type = currentLandmark.Name,
                        X = currentLandmark.Value["x"].Value<decimal>(),
                        Y = currentLandmark.Value["y"].Value<decimal>()
                    };

                    landmarks.Add(landmark);
                }
            }

            return landmarks;
        }

        #endregion
    }
}
