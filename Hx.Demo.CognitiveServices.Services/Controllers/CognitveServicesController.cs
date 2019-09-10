using Hx.Demo.CognitiveServices.Logic.Interfaces;
using Hx.Demo.CognitiveServices.Logic.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hx.Demo.CognitiveServices.Services.Controllers
{
    public class CognitveServicesController : ApiController
    {
        #region Fields

        private readonly IImageAnalizer imageAnalyzer;

        #endregion

        #region Constructor

        public CognitveServicesController(IImageAnalizer imageAnalyzer)
        {
            this.imageAnalyzer = imageAnalyzer;
        }

        #endregion

        [HttpPost]
        [Route("api/cognitveServices/analyze")]
        [EnableCors(origins:"*",headers:"*", methods:"*")]
        public async Task<IHttpActionResult> Analyze()
        {
            try
            {
                byte[] imageToAnalyze = await Request.Content.ReadAsByteArrayAsync();

                if (imageAnalyzer == null)
                    return BadRequest();

                FaceAnalyzeResult result = await imageAnalyzer.FullAnalyze(imageToAnalyze);

                return Ok(result);
            }
            catch
            {
                return Ok(new JObject());
            }
        }
    }
}
