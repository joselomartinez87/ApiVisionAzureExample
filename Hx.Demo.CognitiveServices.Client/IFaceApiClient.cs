using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Client
{
    public interface IFaceApiClient
    {
        Task<string> MakeDetectRequest(string imageFilePath);
        Task<string> MakeDetectRequest(byte[] byteData);
        Task<string> MakeGetListRequest(string imageFilePath);
    }
}