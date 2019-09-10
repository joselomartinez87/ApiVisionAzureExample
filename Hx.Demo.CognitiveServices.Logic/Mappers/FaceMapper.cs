using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Hx.Demo.CognitiveServices.Logic.Mappers
{
    internal class FaceMapper : IFaceMapper
    {
        #region Fields

        private readonly IBoxMapper _boxMapper;
        private readonly IEmotionMapper _emotionMapper;
        private readonly ILandmarkMapper _landmarkMapper;

        #endregion

        #region Constructor

        public FaceMapper(
            IBoxMapper boxMapper,
            IEmotionMapper emotionMapper,
            ILandmarkMapper landmarkMapper)
        {
            _boxMapper = boxMapper;
            _emotionMapper = emotionMapper;
            _landmarkMapper = landmarkMapper;
        }

        #endregion

        #region IFaceMapper Implementation Methods

        public List<Face> Map(JToken container)
        {
            List<Face> faces = new List<Face>();

            foreach (JToken face in container)
            {
                JToken faceRectangle = face["faceRectangle"].Value<JToken>();
                JToken faceAttributes = face["faceAttributes"].Value<JToken>();

                Face currentFace = new Face
                {
                    Age = faceAttributes["age"].Value<int>(),
                    Gender = faceAttributes["gender"].Value<string>(),
                    Box = _boxMapper.Map(faceRectangle),
                    Emotions = _emotionMapper.Map(faceAttributes),
                    Landmarks = _landmarkMapper.Map(face)
                };

                faces.Add(currentFace);
            }

            return faces;
        }

        #endregion
    }
}
