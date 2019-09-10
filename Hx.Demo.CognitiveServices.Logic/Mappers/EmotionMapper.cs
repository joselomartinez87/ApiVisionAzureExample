using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Hx.Demo.CognitiveServices.Logic.Mappers
{
    class EmotionMapper : IEmotionMapper
    {
        #region Constants

        public const string KEY = "emotion";

        #endregion

        #region Fields

        private List<string> _emotionLabels;

        #endregion

        #region Constructor

        public EmotionMapper()
        {
            _emotionLabels = new List<string> { "anger", "contempt", "disgust", "fear", "happiness", "neutral", "sadness", "surprise" };
        }

        #endregion

        #region IEmotionMapper Implementation Methods

        public List<Emotion> Map(JToken container)
        {
            List<Emotion> emotions = new List<Emotion>();
            JToken currentEmotion = container[KEY].Value<JToken>();

            foreach (string emation in _emotionLabels)
            {
                emotions.Add(GetEmotion(currentEmotion, emation));
            }

            return emotions;
        }

        #endregion

        #region Private Methods

        private static Emotion GetEmotion(JToken currentEmotion, string emotion)
        {
            double emotionScore = currentEmotion[emotion].Value<double>();

            Emotion emotionObj = new Emotion()
            {
                Type = emotion,
                Confidence = emotionScore
            };

            return emotionObj;
        }

        #endregion
    }
}
