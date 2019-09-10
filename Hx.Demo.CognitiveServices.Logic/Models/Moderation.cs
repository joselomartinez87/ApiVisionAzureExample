namespace Hx.Demo.CognitiveServices.Logic.Models
{
    public class Moderation
    {
        public bool IsAdultContent { get; set; }
        public bool IsSpicyContent { get; set; }
        public decimal AdultScore { get; set; }
        public decimal SpicyScore { get; set; }
    }
}