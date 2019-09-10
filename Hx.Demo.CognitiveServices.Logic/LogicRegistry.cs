using Hx.Demo.CognitiveServices.Logic.Interfaces;
using Hx.Demo.CognitiveServices.Logic.Interfaces.Mappers;
using Hx.Demo.CognitiveServices.Logic.Mappers;
using StructureMap.Configuration.DSL;

namespace Hx.Demo.CognitiveServices.Logic
{
    public class LogicRegistry : Registry
    {
        public LogicRegistry()
        {
            For<IImageAnalizer>().Use<ImageAnalizer>();
            For<IFaceServices>().Use<FaceServices>();
            For<IFaceMapper>().Use<FaceMapper>();
            For<IEmotionMapper>().Use<EmotionMapper>();
            For<IBoxMapper>().Use<BoxMapper>();
            For<ILandmarkMapper>().Use<LandmarkMapper>();
            For<IModerationMapper>().Use<ModerationMapper>();
            For<ICelebritiesMapper>().Use<CelebritiesMapper>();
        }
    }
}
