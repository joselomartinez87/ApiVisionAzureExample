using Hx.Demo.CognitiveServices.Common;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hx.Demo.CognitiveServices.Client
{
    public class VisionApiClient : IVisionApiClient
    {
        #region Fields

        private readonly string subscriptionKey;
        private readonly string visionApiBaseEndPoint;
        private readonly IImageServices imageService;

        #endregion

        #region Constructor

        public VisionApiClient(IImageServices imageService)
        {
            subscriptionKey = ConfigurationManager.AppSettings["subscriptionKey"];
            visionApiBaseEndPoint = ConfigurationManager.AppSettings["visionApiEndPoint"];

            this.imageService = imageService;
        }

        #endregion

        #region IVisionApiClient Implementation Methods

        public async Task<string> MakeAnalysisRequest(string imageFilePath)
        {
            byte[] byteData = imageService.GetImageAsByteArray(imageFilePath);

            string requestParameters = "visualFeatures=Categories,Tags,Description,Faces,ImageType,Color,Adult";
            string uri = $"{visionApiBaseEndPoint}/analyze?{requestParameters}";

            return await MakeRequest(byteData, uri);
        }

        public async Task<string> MakeAnalysisRequest(byte[] byteData)
        {
            string requestParameters = "visualFeatures=Categories,Tags,Description,Faces,ImageType,Color,Adult";
            string uri = $"{visionApiBaseEndPoint}/analyze?{requestParameters}";

            return await MakeRequest(byteData, uri);
        }

        #endregion

        private async Task<string> MakeRequest(byte[] byteData, string uri)
        {
            string jsonResponse = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                    using (var content = new ByteArrayContent(byteData))
                    {
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                        using (HttpResponseMessage response = await client.PostAsync(uri, content))
                        {
                            if (response.IsSuccessStatusCode)
                                jsonResponse = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("\n" + e.Message);
            }

            return jsonResponse;
        }
    }
}
