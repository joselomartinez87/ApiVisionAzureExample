using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hx.Demo.CognitiveServices.Logic.Mappers
{
    internal class CelebritiesMapper : ICelebritiesMapper
    {
        #region Fields

        private readonly IBoxMapper _boxMapper;

        #endregion

        #region Constructor

        public CelebritiesMapper(IBoxMapper boxMapper)
        {
            _boxMapper = boxMapper;
        }

        #endregion

        #region ICelebritiesMapper Implementation Methods

        public void Map(JToken container, List<Face> faces)
        {
            JToken categoriesNode = GetCategories(container);

            if (categoriesNode.HasValues)
            {
                foreach (JToken category in categoriesNode)
                {
                    JToken detail = category["detail"];

                    if (category["detail"] != null && category["detail"].Value<JToken>()["celebrities"] != null)
                    {
                        IEnumerable<JToken> celebritiesNode = category["detail"].Value<JToken>()["celebrities"].Value<JArray>();

                        foreach (JToken celebrity in celebritiesNode)
                        {
                            JToken faceRectangle = celebrity["faceRectangle"].Value<JToken>();
                            Box celebirtyBox = _boxMapper.Map(faceRectangle);

                            Face face = faces
                                .Where(FaceFilter(celebirtyBox))
                                .Select(f => f)
                                .FirstOrDefault();

                            if (face != null)
                            {
                                face.CelebrityName = celebrity["name"].Value<string>();
                                face.CelebrityScore = celebrity["confidence"].Value<decimal>();
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        private JToken GetCategories(JToken faceAnlysis)
        {
            JArray categories = new JArray();
            JToken catergoriesNode = faceAnlysis["categories"];

            if (catergoriesNode != null)
                categories = faceAnlysis["categories"].Value<JArray>();

            return categories;
        }

        private static Func<Face, bool> FaceFilter(Box celebirtyBox)
        {
            return face => face.Box.Height.Equals(celebirtyBox.Height) &&
                face.Box.Left.Equals(celebirtyBox.Left) &&
                face.Box.Top.Equals(celebirtyBox.Top) &&
                face.Box.Width.Equals(celebirtyBox.Width);
        }

        #endregion
    }
}
