using Hx.Demo.CognitiveServices.Logic.Models;
using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Logic.Interfaces
{
    public interface IImageAnalizer
    {
        Task<FaceAnalyzeResult> FullAnalyze(byte[] imageToAnalyze);
        Task<FaceAnalyzeResult> FaceAnalyze(string imageFilePath);
    }
}
