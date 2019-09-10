using System.Collections.Generic;

namespace Hx.Demo.CognitiveServices.Logic.Models
{
    public class FaceAnalyzeResult
    {
        public List<Face> Faces { get; set; }
        public Moderation Moderation { get; set; }
        public List<JsonResult> JsonResults { get; set; }

        public FaceAnalyzeResult()
        {
            Faces = new List<Face>();
            JsonResults = new List<JsonResult>();
        }
    }
}
