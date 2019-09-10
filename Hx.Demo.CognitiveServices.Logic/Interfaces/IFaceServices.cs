using Hx.Demo.CognitiveServices.Logic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Logic.Interfaces
{
    public interface IFaceServices
    {
        Task<List<JsonResult>> LoadImageFaceInformation(string imageFilePath);
        Task<List<JsonResult>> LoadImageInformation(byte[] imageByteData);
        FaceAnalyzeResult ProcessInformation(List<JsonResult> jsonResults);
    }
}