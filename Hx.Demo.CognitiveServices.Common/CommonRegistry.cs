using StructureMap.Configuration.DSL;

namespace Hx.Demo.CognitiveServices.Common
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<IImageServices>().Use<ImageServices>();
        }
    }
}
