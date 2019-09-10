using System.Collections.Generic;

namespace Hx.Demo.CognitiveServices.Logic.Models
{
    public class Face
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string CelebrityName { get; set; }
        public decimal CelebrityScore { get; set; }

        public Box Box { get; set; }
        public List<Emotion> Emotions { get; set; }
        public List<Landmark> Landmarks { get; set; }

        public Face()
        {
            Emotions = new List<Emotion>();
            Landmarks = new List<Landmark>();
        }
    }
}