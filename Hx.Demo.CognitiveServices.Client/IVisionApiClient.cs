using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Client
{
    public interface IVisionApiClient
    {
        Task<string> MakeAnalysisRequest(string imageFilePath);
        Task<string> MakeAnalysisRequest(byte[] byteData);
    }
}