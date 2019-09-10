using StructureMap.Configuration.DSL;

namespace Hx.Demo.CognitiveServices.Client
{
    public class ClientRegistry : Registry
    {
        public ClientRegistry()
        {
            For<IFaceApiClient>().Use<FaceApiClient>();
            For<IVisionApiClient>().Use<VisionApiClient>();
        }
    }
}
